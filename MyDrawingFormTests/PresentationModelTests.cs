using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.ComponentModel;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class PresentationModelTests
    {
        private PresentationModel _presentationModel;
        private Model _model;

        [TestInitialize]
        public void Setup()
        {
            _model = new Model();
            _presentationModel = new PresentationModel(_model);
        }

        [TestMethod]
        public void ModelTest()
        {
            _presentationModel.SetSelectMode();
            Assert.AreEqual(_presentationModel.model, _model);
        }

        [TestMethod]
        public void isButtonCheckedTest()
        {
            _presentationModel.SetStartMode();
            Assert.IsTrue(_presentationModel.IsStartChecked());
            _presentationModel.SetTerminatorMode();
            Assert.IsTrue(_presentationModel.IsTerminatorChecked());
            _presentationModel.SetProcessMode();
            Assert.IsTrue(_presentationModel.IsProcessChecked());
            _presentationModel.SetDecisionMode();
            Assert.IsTrue(_presentationModel.IsDecisionChecked());
            _presentationModel.SetSelectMode();
            Assert.IsTrue(_presentationModel.IsSelectChecked());
        }

        [TestMethod]
        public void SetStartModeTest()
        {
            _presentationModel.SetStartMode();
            Assert.AreEqual("Start", _model.GetDrawingMode());
        }

        [TestMethod]
        public void SetTerminatorModeTest()
        {
            _presentationModel.SetTerminatorMode();
            Assert.AreEqual("Terminator", _model.GetDrawingMode());
        }

        [TestMethod]
        public void SetProcessModeTest()
        {
            _presentationModel.SetProcessMode();
            Assert.AreEqual("Process", _model.GetDrawingMode());
        }

        [TestMethod]
        public void SetDecisionModeTest()
        {
            _presentationModel.SetDecisionMode();
            Assert.AreEqual("Decision", _model.GetDrawingMode());
        }

        [TestMethod]
        public void SetSelectModeTest()
        {
            _presentationModel.SetSelectMode();
            Assert.AreEqual("", _model.GetDrawingMode());
        }

        [TestMethod]
        public void TextBoxTextChangedTest()
        {
            _presentationModel.TextBoxTextChanged("Test");
            Assert.AreEqual(Color.Black, _presentationModel.TextLabelColor);
            Assert.IsTrue(_presentationModel.IsTextValid());

            _presentationModel.TextBoxTextChanged("");
            Assert.AreEqual(Color.Red, _presentationModel.TextLabelColor);
            Assert.IsFalse(_presentationModel.IsTextValid());
        }

        [TestMethod]
        public void TextBoxXChangedTest()
        {
            _presentationModel.TextBoxXChanged("");
            Assert.AreEqual(Color.Red, _presentationModel.XLabelColor);
            Assert.IsFalse(_presentationModel.IsXValid());

            _presentationModel.TextBoxXChanged("10");
            Assert.AreEqual(Color.Black, _presentationModel.XLabelColor);
            Assert.IsTrue(_presentationModel.IsXValid());

            _presentationModel.TextBoxXChanged("abc");
            Assert.AreEqual(Color.Red, _presentationModel.XLabelColor);
            Assert.IsFalse(_presentationModel.IsXValid());
        }

        [TestMethod]
        public void TextBoxYChangedTest()
        {
            _presentationModel.TextBoxYChanged("");
            Assert.AreEqual(Color.Red, _presentationModel.YLabelColor);
            Assert.IsFalse(_presentationModel.IsYValid());

            _presentationModel.TextBoxYChanged("20");
            Assert.AreEqual(Color.Black, _presentationModel.YLabelColor);
            Assert.IsTrue(_presentationModel.IsYValid());

            _presentationModel.TextBoxYChanged("abc");
            Assert.AreEqual(Color.Red, _presentationModel.YLabelColor);
            Assert.IsFalse(_presentationModel.IsYValid());
        }

        [TestMethod]
        public void TextBoxHeightChangedTest()
        {
            _presentationModel.TextBoxHeightChanged("");
            Assert.AreEqual(Color.Red, _presentationModel.HeightLabelColor);
            Assert.IsFalse(_presentationModel.IsHeightValid());

            _presentationModel.TextBoxHeightChanged("30");
            Assert.AreEqual(Color.Black, _presentationModel.HeightLabelColor);
            Assert.IsTrue(_presentationModel.IsHeightValid());

            _presentationModel.TextBoxHeightChanged("abc");            
            Assert.AreEqual(Color.Red, _presentationModel.HeightLabelColor);
            Assert.IsFalse(_presentationModel.IsHeightValid());

        }

        [TestMethod]
        public void TextBoxWidthChangedTest()
        {
            _presentationModel.TextBoxWidthChanged("");
            Assert.AreEqual(Color.Red, _presentationModel.WidthLabelColor);
            Assert.IsFalse(_presentationModel.IsWidthValid());

            _presentationModel.TextBoxWidthChanged("40");
            Assert.AreEqual(Color.Black, _presentationModel.WidthLabelColor);
            Assert.IsTrue(_presentationModel.IsWidthValid());

            _presentationModel.TextBoxWidthChanged("abc");
            Assert.AreEqual(Color.Red, _presentationModel.WidthLabelColor);
            Assert.IsFalse(_presentationModel.IsWidthValid());
        }

        [TestMethod]
        public void ComboBoxShapeSelectedIndexChangedTest()
        {
            _presentationModel.ComboBoxShapeSelectedIndexChanged("test");
            Assert.IsFalse(_presentationModel.IsShapeValid());
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Start");
            Assert.IsTrue(_presentationModel.IsShapeValid());
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Process");
            Assert.IsTrue(_presentationModel.IsShapeValid());
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Decision");
            Assert.IsTrue(_presentationModel.IsShapeValid());
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Terminator");
            Assert.IsTrue(_presentationModel.IsShapeValid());
        }

        [TestMethod]
        public void CreateBlockChangedTest()
        {
            // 設置有效的輸入
            _presentationModel.TextBoxTextChanged("Test");
            _presentationModel.TextBoxXChanged("10");
            _presentationModel.TextBoxYChanged("20");
            _presentationModel.TextBoxHeightChanged("30");
            _presentationModel.TextBoxWidthChanged("40");
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Process");

            _presentationModel.CreateBlockChanged();
            Assert.IsTrue(_presentationModel.IsCreateEnabled);

            // 設置無效的輸入
            _presentationModel.TextBoxTextChanged("");
            _presentationModel.CreateBlockChanged();
            Assert.IsFalse(_presentationModel.IsCreateEnabled);

            _presentationModel.TextBoxTextChanged("Test");
            _presentationModel.TextBoxXChanged("-10");
            _presentationModel.CreateBlockChanged();
            Assert.IsFalse(_presentationModel.IsCreateEnabled);

            _presentationModel.TextBoxXChanged("10");
            _presentationModel.TextBoxYChanged("-20");
            _presentationModel.CreateBlockChanged();
            Assert.IsFalse(_presentationModel.IsCreateEnabled);

            _presentationModel.TextBoxYChanged("20");
            _presentationModel.TextBoxHeightChanged("0");
            _presentationModel.CreateBlockChanged();
            Assert.IsFalse(_presentationModel.IsCreateEnabled);

            _presentationModel.TextBoxHeightChanged("30");
            _presentationModel.TextBoxWidthChanged("0");
            _presentationModel.CreateBlockChanged();
            Assert.IsFalse(_presentationModel.IsCreateEnabled);

            _presentationModel.TextBoxWidthChanged("40");
            _presentationModel.ComboBoxShapeSelectedIndexChanged("InvalidShape");
            _presentationModel.CreateBlockChanged();
            Assert.IsFalse(_presentationModel.IsCreateEnabled);
        }

        [TestMethod]
        public void AddShapeTest()
        {
            _presentationModel.TextBoxTextChanged("Test");
            _presentationModel.TextBoxXChanged("10");
            _presentationModel.TextBoxYChanged("20");
            _presentationModel.TextBoxHeightChanged("30");
            _presentationModel.TextBoxWidthChanged("40");
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Process");

            _presentationModel.AddShape();
            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Process", shapes[0].ShapeName);
        }

        [TestMethod]
        public void UpdateStateTest()
        {
            _presentationModel.SetStartMode();
            _presentationModel.UpdateState();
            Assert.IsTrue(_presentationModel.IsStartChecked());
            _presentationModel.SetSelectMode();
            _presentationModel.UpdateState();
            Assert.IsTrue(_presentationModel.IsSelectChecked());
        }

        [TestMethod]
        public void NotifyTest()
        {
            bool eventFired = false;
            _presentationModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "IsCreateEnabled")
                {
                    eventFired = true;
                }
            };

            _presentationModel.TextBoxTextChanged("Test");
            Assert.IsTrue(eventFired);
        }

        [TestMethod]
        public void GetCursorTest()
        {
            // 設置為 Start 模式後應為 Cross
            _presentationModel.SetStartMode();
            _presentationModel.UpdateState();
            Assert.AreEqual(Cursors.Cross, _presentationModel.GetCursor());

            // 設置為 Select 模式後應為 Default
            _presentationModel.SetSelectMode();
            _presentationModel.UpdateState();
            Assert.AreEqual(Cursors.Default, _presentationModel.GetCursor());
        }
    }
}
