using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class PointerStateTests
    {
        private PointerState _pointerState;
        private Model _model;

        [TestInitialize]
        public void Setup()
        {
            _pointerState = new PointerState();
            _model = new Model();
            _pointerState.Initialize(_model);
        }

        [TestMethod]
        public void InitializeTest()
        {
            _pointerState.Initialize(_model);
            Assert.AreEqual(0, _pointerState.selectedShapes.Count);
        }

        [TestMethod]
        public void MouseDownTest()
        {
            _model.AddShape("Process", "test", 10, 20, 30, 40);
            var shape = _model.GetShapes()[0];

            // 測試點擊形狀內部
            _pointerState.MouseDown(15, 25);
            Assert.AreEqual(1, _pointerState.selectedShapes.Count);
            Assert.AreEqual(shape, _pointerState.selectedShapes[0]);

            // 測試點擊形狀外部
            _pointerState.MouseDown(5, 5);
            Assert.AreEqual(1, _pointerState.selectedShapes.Count);

            // 測試點擊文字框上的小球
            shape.TextX = 10 + 30 / 3;
            shape.TextY = 20 + 40 / 3;
            _pointerState.MouseDown(shape.TextX + 35, shape.TextY - 6);
            Assert.AreEqual(1, _pointerState.selectedShapes.Count);
            Assert.AreEqual(shape, _pointerState.selectedShapes[0]);
            Assert.IsTrue(_pointerState._isTextHandlePressed);
        }

        [TestMethod]
        public void AddSelectedShapeTest()
        {
            _model.AddShape("Process", "test", 10, 20, 30, 40);
            var shape = _model.GetShapes()[0];

            _pointerState.AddSelectedShape(shape);
            Assert.AreEqual(1, _pointerState.selectedShapes.Count);
            Assert.AreEqual(shape, _pointerState.selectedShapes[0]);

            _pointerState.AddSelectedShape(shape);
            Assert.AreEqual(1, _pointerState.selectedShapes.Count); // 應該不會重複添加
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            _model.AddShape("Process", "test", 10, 20, 30, 40);
            var shape = _model.GetShapes()[0];

            // 測試移動整個形狀
            _pointerState.MouseDown(15, 25);
            _pointerState.MouseMove(25, 35);
            Assert.AreEqual(20, shape.X);
            Assert.AreEqual(30, shape.Y);

            // 測試移動文字框上的小球
            shape.TextX = 10 + 30 / 3;
            shape.TextY = 20 + 40 / 3;
            _pointerState.MouseDown(shape.TextX + 35, shape.TextY - 6);
            _pointerState.MouseMove(shape.TextX + 10, shape.TextY + 10);
            Assert.AreEqual(-5, shape.TextX);
            Assert.AreEqual(49, shape.TextY);

            // 無效狀態測試
            _pointerState.MouseUp(25, 35);
            _pointerState.MouseMove(35, 45);
            Assert.AreEqual(20, shape.X); // 應該不會改變
            Assert.AreEqual(30, shape.Y); // 應該不會改變
        }

        [TestMethod]
        public void MouseUpTest()
        {
            _model.AddShape("Process", "test", 10, 20, 30, 40);
            var shape = _model.GetShapes()[0];

            _pointerState.MouseDown(15, 25);
            _pointerState.MouseMove(25, 35);
            _pointerState.MouseUp(25, 35);

            // 檢查 _isPressed 是否被設置為 false
            _pointerState.MouseMove(35, 45);
            Assert.AreEqual(20, shape.X); // 應該不會改變
            Assert.AreEqual(30, shape.Y); // 應該不會改變
        }

        [TestMethod]
        public void OnPaintTest()
        {
            var graphicsMock = new MockGraphic();
            _model.AddShape("Process", "test", 10, 20, 30, 40);
            var shape = _model.GetShapes()[0];

            // 測試未選中形狀的情況
            _pointerState.OnPaint(graphicsMock);

            // 測試選中形狀的情況
            _pointerState.AddSelectedShape(shape);
            _pointerState.OnPaint(graphicsMock);

            // 測試選中形狀為 null 的情況
            _pointerState.selectedShapes.Add(null);
            _pointerState.OnPaint(graphicsMock);

            // 檢查是否調用了繪圖方法
            // 這裡可以根據 MockGraphic 的實現來檢查是否調用了繪圖方法
        }
    }
}
