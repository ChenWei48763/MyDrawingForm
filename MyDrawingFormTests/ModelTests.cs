using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingFormTests;
using System.Collections.Generic;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private Model model;
        IState mockState = new MockState();

        [TestInitialize]
        public void Setup()
        {
            this.model = new Model();
        }

        [TestMethod()]
        public void EnterPointerStateTest()
        {
            model.EnterPointerState();
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void EnterDrawingStateTest()
        {
            model.SetDrawingMode("Process");
            Assert.AreEqual("Process", model.GetDrawingMode());
        }

        [TestMethod()]
        public void NotifyModelChangedTest()
        {
            bool isNotified = false;
            model.ModelChanged += () => isNotified = true;
            model.NotifyModelChanged();
            Assert.IsTrue(isNotified);
        }

        [TestMethod()]
        public void PointerPressedTest()
        {
            mockState.Initialize(model);
            model.currentState = mockState;
            model.PointerPressed(20, 40);
            MockState state = (MockState)model.currentState;
            Assert.AreEqual(state.MouseDownX, 20);
            Assert.AreEqual(state.MouseDownY, 40);
        }

        [TestMethod()]
        public void PointerMovedTest()
        {
            mockState.Initialize(model);
            model.currentState = mockState;
            model.PointerMoved(40, 60);
            MockState state = (MockState)model.currentState;
            Assert.AreEqual(state.MouseMoveX, 40);
            Assert.AreEqual(state.MouseMoveY, 60);
        }

        [TestMethod()]
        public void PointerReleasedTest()
        {
            mockState.Initialize(model);
            model.currentState = mockState;
            model.PointerReleased(60, 80);
            MockState state = (MockState)model.currentState;
            Assert.AreEqual(state.MouseUpX, 60);
            Assert.AreEqual(state.MouseUpY, 80);
        }

        [TestMethod()]
        public void DrawTest()
        {
            mockState.Initialize(model);
            model.currentState = mockState;
            IGraphics graphics = new MockGraphic();
            model.Draw(graphics);
            MockState state = (MockState)model.currentState;
            Assert.IsTrue(state.isOnPaintCalled);
        }

        [TestMethod()]
        public void GetShapesTest()
        {
            model.AddShape("Process", "test", 10, 20, 30, 40);
            Assert.IsNotNull(model.GetShapes());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            model.AddShape("Process", "Test", 10, 20, 30, 40);
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Process", shapes[0].ShapeName);
            Assert.AreEqual("", model.GetDrawingMode());

        }

        [TestMethod()]
        public void GetDrawingModeTest()
        {
            model.SetDrawingMode("Process");
            Assert.AreEqual("Process", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetDrawingModeTest()
        {
            model.SetDrawingMode("Process");
            Assert.AreEqual("Process", model.GetDrawingMode());
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            model.SetSelectMode();
            Assert.AreEqual("", model.GetDrawingMode());
        }
    }
}