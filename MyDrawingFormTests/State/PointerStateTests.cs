using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class PointerStateTests
    {
        private PointerState _pointerState;
        private Model _model;
        private PrivateObject _pState;

        [TestInitialize]
        public void Setup()
        {
            _pointerState = new PointerState();
            _model = new Model();
            _pointerState.Initialize(_model);
            _pState = new PrivateObject(_pointerState);
        }

        [TestMethod]
        public void InitializeTest()
        {
            _pointerState.Initialize(_model);
            Assert.IsNull(_pointerState.selectedShape);
        }

        [TestMethod]
        public void MouseDownTest()
        {
            _model.AddShape(new Process(1, "test", 10, 20, 30, 40));
            var shape1 = _model.GetShapes()[0];

            _pointerState.MouseDown(15, 25);
            Assert.AreEqual(shape1, _pointerState.selectedShape);

            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(shape1, _pointerState.selectedShape);

            shape1.TextX = 10 + 30 / 3;
            shape1.TextY = 20 + 40 / 3;
            _pointerState.MouseDown(shape1.TextX + 35, shape1.TextY - 6);
            Assert.AreEqual(shape1, _pointerState.selectedShape);
            Assert.IsTrue((bool)_pState.GetFieldOrProperty("_isTextHandlePressed"));

            //// 測試雙擊文字句柄
            //_pointerState.MouseDown(shape1.TextX + 35, shape1.TextY - 6);
            //_pointerState.MouseDown(shape1.TextX + 35, shape1.TextY - 6);
            //Assert.IsFalse((bool)_pState.GetFieldOrProperty("_isOnceClickOnTextHandle"));
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            _model.AddShape(new Process(1, "test", 10, 20, 30, 40));
            var shape2 = _model.GetShapes()[0];

            _pointerState.MouseDown(15, 25);
            _pointerState.MouseMove(25, 35);
            Assert.AreEqual(20, shape2.X);
            Assert.AreEqual(30, shape2.Y);

            shape2.TextX = 10 + 30 / 3;
            shape2.TextY = 20 + 40 / 3;
            _pointerState.MouseDown(shape2.TextX + 35, shape2.TextY - 6);
            _pointerState.MouseMove(shape2.TextX + 10, shape2.TextY + 10);
            Assert.AreEqual(-5, shape2.TextX);
            Assert.AreEqual(49, shape2.TextY);

            _pointerState.MouseUp(25, 35);
            _pointerState.MouseMove(35, 45);
            Assert.AreEqual(20, shape2.X);
            Assert.AreEqual(30, shape2.Y);
        }

        [TestMethod]
        public void MouseUpTest()
        {
            _model.AddShape(new Process(1, "test", 10, 20, 30, 40));
            var shape3 = _model.GetShapes()[0];

            _pointerState.MouseDown(15, 25);
            _pointerState.MouseMove(25, 35);
            _pointerState.MouseUp(25, 35);

            _pointerState.MouseMove(35, 45);
            Assert.AreEqual(20, shape3.X);
            Assert.AreEqual(30, shape3.Y);

            // 測試 _isPressed 和 _isTextHandlePressed 是否被設置為 false
            Assert.IsFalse((bool)_pState.GetFieldOrProperty("_isPressed"));
            Assert.IsFalse((bool)_pState.GetFieldOrProperty("_isTextHandlePressed"));
        }

        [TestMethod]
        public void OnPaintTest()
        {
            var graphicsMock = new MockGraphic();
            Shape shape4 = new Process(1, "test", 10, 20, 30, 40);
            _model.AddShape(shape4);
            _model.AddLine(new Line(shape4, shape4, 1, 2));

            _pointerState.OnPaint(graphicsMock);

            // 測試選中形狀的情況
            _pointerState.MouseDown(15, 25);
            _pointerState.OnPaint(graphicsMock);

            // 測試選中形狀為 null 的情況
            _pointerState.selectedShape = null;
            _pointerState.OnPaint(graphicsMock);

            // 檢查是否調用了繪圖方法
            // 這裡可以根據 MockGraphic 的實現來檢查是否調用了繪圖方法
        }

        [TestMethod]
        public void DoubleClickTextHandleTest()
        {
            bool doubleClickEventFired = false;
            _pointerState.OnTextHandleDoubleClick += (shape) => doubleClickEventFired = true;

            _model.AddShape(new Process(1, "test", 10, 20, 30, 40));
            var shape5 = _model.GetShapes()[0];
            shape5.TextX = 10 + 30 / 3;
            shape5.TextY = 20 + 40 / 3;

            // 模擬雙擊文字句柄
            _pointerState.MouseDown(shape5.TextX + 35, shape5.TextY - 6);
            _pointerState.MouseDown(shape5.TextX + 35, shape5.TextY - 6);

            Assert.IsTrue(doubleClickEventFired);
        }
    }
}
