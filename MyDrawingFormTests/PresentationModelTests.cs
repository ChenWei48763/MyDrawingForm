using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.ComponentModel;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
    }
}
