using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.ComponentModel;
using System.Windows;

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
            Assert.IsTrue(_presentationModel.IsTextValid());
        }

        [TestMethod]
        public void TextBoxXChangedTest()
        {
            _presentationModel.TextBoxXChanged("10");
            Assert.IsTrue(_presentationModel.IsXValid());
        }

        [TestMethod]
        public void TextBoxYChangedTest()
        {
            _presentationModel.TextBoxYChanged("20");
            Assert.IsTrue(_presentationModel.IsYValid());
        }

        [TestMethod]
        public void TextBoxHeightChangedTest()
        {
            _presentationModel.TextBoxHeightChanged("30");
            Assert.IsTrue(_presentationModel.IsHeightValid());
        }

        [TestMethod]
        public void TextBoxWidthChangedTest()
        {
            _presentationModel.TextBoxWidthChanged("40");
            Assert.IsTrue(_presentationModel.IsWidthValid());
        }

        [TestMethod]
        public void ComboBoxShapeSelectedIndexChangedTest()
        {
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Process");
            Assert.IsTrue(_presentationModel.IsShapeValid());
        }

        [TestMethod]
        public void CreateBlockChangedTest()
        {
            _presentationModel.TextBoxTextChanged("Test");
            _presentationModel.TextBoxXChanged("10");
            _presentationModel.TextBoxYChanged("20");
            _presentationModel.TextBoxHeightChanged("30");
            _presentationModel.TextBoxWidthChanged("40");
            _presentationModel.ComboBoxShapeSelectedIndexChanged("Process");

            _presentationModel.CreateBlockChanged();
            Assert.IsTrue(_presentationModel.IsCreateEnabled);
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
    }
}
