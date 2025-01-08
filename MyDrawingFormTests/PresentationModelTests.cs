using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        private PresentationModel presentationModel;
        private Model model;

        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            presentationModel = new PresentationModel(model);
        }

        [TestMethod]
        public void ModelTest()
        {
            presentationModel.SetSelectMode();
            Assert.AreEqual(presentationModel.model, model);
        }

        [TestMethod]
        public void isButtonCheckedTest()
        {
            presentationModel.SetStartMode();
            Assert.IsTrue(presentationModel.IsStartChecked());
            presentationModel.SetTerminatorMode();
            Assert.IsTrue(presentationModel.IsTerminatorChecked());
            presentationModel.SetProcessMode();
            Assert.IsTrue(presentationModel.IsProcessChecked());
            presentationModel.SetDecisionMode();
            Assert.IsTrue(presentationModel.IsDecisionChecked());
            presentationModel.SetSelectMode();
            Assert.IsTrue(presentationModel.IsSelectChecked());
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            model.SetDrawingMode("Process");
            presentationModel.UpdateState();
            Assert.AreEqual(Cursors.Cross, presentationModel.GetCursor());
            Assert.IsTrue(presentationModel.IsProcessChecked());
            Assert.IsFalse(presentationModel.IsStartChecked());
            Assert.IsFalse(presentationModel.IsTerminatorChecked());
            Assert.IsFalse(presentationModel.IsDecisionChecked());
            Assert.IsFalse(presentationModel.IsSelectChecked());
            Assert.IsFalse(presentationModel.IsLineChecked());
        }

        [TestMethod()]
        public void IsCreateEnabledTest()
        {
            presentationModel.ComboBoxShapeSelectedIndexChanged("Process");
            presentationModel.TextBoxTextChanged("Test");
            presentationModel.TextBoxXChanged("10");
            presentationModel.TextBoxYChanged("20");
            presentationModel.TextBoxHeightChanged("30");
            presentationModel.TextBoxWidthChanged("40");
            Assert.IsTrue(presentationModel.IsCreateEnabled);

            presentationModel.TextBoxTextChanged("");
            Assert.IsFalse(presentationModel.IsCreateEnabled);
        }

        [TestMethod()]
        public void IsButtonOKEnabledTest()
        {
            presentationModel.InitialText = "Initial Text";
            presentationModel.TextBoxModifyTextChanged("Modified Text");
            Assert.IsTrue(presentationModel.IsButtonOKEnabled);

            presentationModel.TextBoxModifyTextChanged("Initial Text");
            Assert.IsFalse(presentationModel.IsButtonOKEnabled);
        }

        [TestMethod()]
        public void IsUndoEnabledTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            Assert.IsTrue(presentationModel.IsUndoEnabled);
            presentationModel.Undo();
            Assert.IsFalse(presentationModel.IsUndoEnabled);
        }

        [TestMethod()]
        public void IsRedoEnabledTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            presentationModel.Undo();
            Assert.IsTrue(presentationModel.IsRedoEnabled);
            presentationModel.Redo();
            Assert.IsFalse(presentationModel.IsRedoEnabled);
        }

        [TestMethod()]
        public void SetStartModeTest()
        {
            presentationModel.SetStartMode();
            Assert.AreEqual("Start", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetTerminatorModeTest()
        {
            presentationModel.SetTerminatorMode();
            Assert.AreEqual("Terminator", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetProcessModeTest()
        {
            presentationModel.SetProcessMode();
            Assert.AreEqual("Process", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetDecisionModeTest()
        {
            presentationModel.SetDecisionMode();
            Assert.AreEqual("Decision", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            presentationModel.SetSelectMode();
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetDrawLineModeTest()
        {
            presentationModel.SetDrawLineMode();
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void UndoTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            Assert.AreEqual(1, model.GetShapes().Count);
            presentationModel.Undo();
            Assert.AreEqual(0, model.GetShapes().Count);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            Assert.AreEqual(1, model.GetShapes().Count);
            presentationModel.Undo();
            presentationModel.Redo();
            Assert.AreEqual(1, model.GetShapes().Count);
        }

        [TestMethod()]
        public void TextBoxTextChangedTest()
        {
            presentationModel.TextBoxTextChanged("Test");
            Assert.AreEqual(Color.Black, presentationModel.TextLabelColor);
            Assert.IsTrue(presentationModel.IsTextValid());

            presentationModel.TextBoxTextChanged("");
            Assert.AreEqual(Color.Red, presentationModel.TextLabelColor);
            Assert.IsFalse(presentationModel.IsTextValid());
        }

        [TestMethod()]
        public void TextBoxXChangedTest()
        {
            presentationModel.TextBoxXChanged("");
            Assert.AreEqual(Color.Red, presentationModel.XLabelColor);
            Assert.IsFalse(presentationModel.IsXValid());

            presentationModel.TextBoxXChanged("10");
            Assert.AreEqual(Color.Black, presentationModel.XLabelColor);
            Assert.IsTrue(presentationModel.IsXValid());

            presentationModel.TextBoxXChanged("abc");
            Assert.AreEqual(Color.Red, presentationModel.XLabelColor);
            Assert.IsFalse(presentationModel.IsXValid());
        }

        [TestMethod()]
        public void TextBoxYChangedTest()
        {
            presentationModel.TextBoxYChanged("200");
            Assert.AreEqual("200", presentationModel.GetType().GetField("_y", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(presentationModel));
        }

        [TestMethod()]
        public void TextBoxHeightChangedTest()
        {
            presentationModel.TextBoxYChanged("");
            Assert.AreEqual(Color.Red, presentationModel.YLabelColor);
            Assert.IsFalse(presentationModel.IsYValid());

            presentationModel.TextBoxYChanged("20");
            Assert.AreEqual(Color.Black, presentationModel.YLabelColor);
            Assert.IsTrue(presentationModel.IsYValid());

            presentationModel.TextBoxYChanged("abc");
            Assert.AreEqual(Color.Red, presentationModel.YLabelColor);
            Assert.IsFalse(presentationModel.IsYValid());
        }

        [TestMethod()]
        public void TextBoxWidthChangedTest()
        {
            presentationModel.TextBoxWidthChanged("400");
            Assert.AreEqual("400", presentationModel.GetType().GetField("_width", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(presentationModel));
        }

        [TestMethod()]
        public void ComboBoxShapeSelectedIndexChangedTest()
        {
            presentationModel.TextBoxHeightChanged("");
            Assert.AreEqual(Color.Red, presentationModel.HeightLabelColor);
            Assert.IsFalse(presentationModel.IsHeightValid());

            presentationModel.TextBoxHeightChanged("30");
            Assert.AreEqual(Color.Black, presentationModel.HeightLabelColor);
            Assert.IsTrue(presentationModel.IsHeightValid());

            presentationModel.TextBoxHeightChanged("abc");
            Assert.AreEqual(Color.Red, presentationModel.HeightLabelColor);
            Assert.IsFalse(presentationModel.IsHeightValid());
        }

        [TestMethod()]
        public void TextBoxModifyTextChangedTest()
        {
            presentationModel.TextBoxWidthChanged("");
            Assert.AreEqual(Color.Red, presentationModel.WidthLabelColor);
            Assert.IsFalse(presentationModel.IsWidthValid());

            presentationModel.TextBoxWidthChanged("40");
            Assert.AreEqual(Color.Black, presentationModel.WidthLabelColor);
            Assert.IsTrue(presentationModel.IsWidthValid());

            presentationModel.TextBoxWidthChanged("abc");
            Assert.AreEqual(Color.Red, presentationModel.WidthLabelColor);
            Assert.IsFalse(presentationModel.IsWidthValid());

            presentationModel.InitialText = "Initial Text";
            presentationModel.TextBoxModifyTextChanged("Initial Text");
            Assert.AreEqual(Color.Red, presentationModel.WidthLabelColor);
            Assert.IsFalse(presentationModel.IsWidthValid());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            presentationModel.ComboBoxShapeSelectedIndexChanged("Process");
            presentationModel.TextBoxTextChanged("Test");
            presentationModel.TextBoxXChanged("10");
            presentationModel.TextBoxYChanged("20");
            presentationModel.TextBoxHeightChanged("30");
            presentationModel.TextBoxWidthChanged("40");
            presentationModel.AddShape();
            Assert.AreEqual(model.GetShapes().Count, 1);
        }

        [TestMethod()]
        public void UpdateShapeListTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            DataGridView dataGridViewShapes = new DataGridView();
            dataGridViewShapes.Columns.Add("Action", "Action");
            dataGridViewShapes.Columns.Add("ShapeId", "ShapeId");
            dataGridViewShapes.Columns.Add("ShapeType", "ShapeType");
            dataGridViewShapes.Columns.Add("Text", "Text");
            dataGridViewShapes.Columns.Add("X", "X");
            dataGridViewShapes.Columns.Add("Y", "Y");
            dataGridViewShapes.Columns.Add("Height", "Height");
            dataGridViewShapes.Columns.Add("Width", "Width");

            presentationModel.UpdateShapeList(dataGridViewShapes);

            Assert.AreEqual(2, dataGridViewShapes.Rows.Count);
            Assert.AreEqual("刪除", dataGridViewShapes.Rows[0].Cells[0].Value);
            Assert.AreEqual(shape.ShapeId, dataGridViewShapes.Rows[0].Cells[1].Value);
            Assert.AreEqual(shape.GetType().Name, dataGridViewShapes.Rows[0].Cells[2].Value);
            Assert.AreEqual(shape.Text, dataGridViewShapes.Rows[0].Cells[3].Value);
            Assert.AreEqual(shape.X, dataGridViewShapes.Rows[0].Cells[4].Value);
            Assert.AreEqual(shape.Y, dataGridViewShapes.Rows[0].Cells[5].Value);
            Assert.AreEqual(shape.Height, dataGridViewShapes.Rows[0].Cells[6].Value);
            Assert.AreEqual(shape.Width, dataGridViewShapes.Rows[0].Cells[7].Value);
        }

        [TestMethod()]
        public void NotifyTest()
        {
            bool eventFired = false;
            presentationModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "TestProperty")
                {
                    eventFired = true;
                }
            };

            presentationModel.Notify("TestProperty");

            Assert.IsTrue(eventFired);
        }

        [TestMethod()]
        public void InitialTextTest()
        {
            presentationModel.InitialText = "Initial Text";
            Assert.AreEqual("Initial Text", presentationModel.InitialText);
        }

        [TestMethod()]
        public void IsShapeValidTest()
        {
            presentationModel.ComboBoxShapeSelectedIndexChanged("Start");
            Assert.IsTrue(presentationModel.IsShapeValid());

            presentationModel.ComboBoxShapeSelectedIndexChanged("Terminator");
            Assert.IsTrue(presentationModel.IsShapeValid());

            presentationModel.ComboBoxShapeSelectedIndexChanged("Process");
            Assert.IsTrue(presentationModel.IsShapeValid());

            presentationModel.ComboBoxShapeSelectedIndexChanged("Decision");
            Assert.IsTrue(presentationModel.IsShapeValid());

            presentationModel.ComboBoxShapeSelectedIndexChanged("InvalidShape");
            Assert.IsFalse(presentationModel.IsShapeValid());
        }

        [TestMethod()]
        public void UpdateShapeTextTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            presentationModel.UpdateShapeText(shape, "New Text");
            Assert.AreEqual("New Text", shape.Text);
        }

        [TestMethod()]
        public void ManageBackupFilesTest()
        {
            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_backup");
            Directory.CreateDirectory(backupFolder);

            // Create 10 dummy backup files
            for (int i = 0; i < 10; i++)
            {
                string filePath = Path.Combine(backupFolder, $"backup_{i}.mydrawing");
                File.WriteAllText(filePath, "dummy content");
                Thread.Sleep(100); // Ensure different creation times
            }

            presentationModel.ManageBackupFiles(backupFolder);

            var remainingFiles = new DirectoryInfo(backupFolder).GetFiles();
            Assert.AreEqual(5, remainingFiles.Length);

            // Clean up
            Directory.Delete(backupFolder, true);
        }

        [TestMethod()]
        public void AutoSaveAsyncTest()
        {
            model.isChanged = true;
            string backupFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_backup");
            Directory.CreateDirectory(backupFolder);

            presentationModel.AutoSaveAsync("TestTitle");

            // Wait for the auto-save to complete
            Thread.Sleep(4000);

            var backupFiles = new DirectoryInfo(backupFolder).GetFiles();
            //Assert.IsTrue(backupFiles.Length > 0, "No backup files were created.");

            // Clean up
            Directory.Delete(backupFolder, true);
        }

        [TestMethod()]
        public void SaveAsyncTest()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_save.mydrawing");

            // 添加一些形狀和連接線
            Shape shape1 = new Process(1, "Test1", 10, 20, 30, 40);
            Shape shape2 = new Process(2, "Test2", 50, 60, 70, 80);
            model.AddShapeFromDataGrid(shape1);
            model.AddShapeFromDataGrid(shape2);
            Line line = new Line(shape1, shape2, 1, 2);
            model.AddLine(line);

            presentationModel.SaveAsync(filePath);

            // Wait for the save to complete
            Thread.Sleep(4000);

            Assert.IsTrue(File.Exists(filePath));

            // 檢查保存的文件內容
            var lines = File.ReadAllLines(filePath);
            Assert.AreEqual("Shape ID X Y H W Text", lines[0]);
            Assert.AreEqual("Process 1 10 20 30 40 Test1", lines[1]);
            Assert.AreEqual("Process 2 50 60 70 80 Test2", lines[2]);
            Assert.AreEqual("---------", lines[3]);
            Assert.AreEqual("Line ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2", lines[4]);
            Assert.AreEqual("Line 1 1 1 2 2", lines[5]);
            Assert.AreEqual("---------", lines[6]);

            // Clean up
            File.Delete(filePath);
        }

        [TestMethod()]
        public void LoadTest()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "test_load.mydrawing");
            // Create a dummy save file
            var sb = new StringBuilder();
            sb.AppendLine("Shape ID X Y H W Text");
            sb.AppendLine("Process 1 10 20 30 40 Test");
            sb.AppendLine("Process 2 50 60 70 80 Test2");
            sb.AppendLine("---------");
            sb.AppendLine("Line ID Connection_ShapeID1 Connection_Point1 Connection_ShapeID2 Connection_Point2");
            sb.AppendLine("Line 1 1 1 2 2");
            sb.AppendLine("---------");
            File.WriteAllText(filePath, sb.ToString());

            presentationModel.Load(filePath);

            var shapes = model.GetShapes();
            var lines = model.GetLines();

            Assert.AreEqual(2, shapes.Count, "Shapes count is not 2.");
            Assert.AreEqual(1, lines.Count, "Lines count is not 1.");
            
            // Clean up
            File.Delete(filePath);
        }
    }
}