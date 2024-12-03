using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class DrawingStateTests
    {
        private DrawingState _drawingState;
        private Model _model;
        private PointerState _pointerState;

        [TestInitialize]
        public void Setup()
        {
            _pointerState = new PointerState();
            _drawingState = new DrawingState(_pointerState);
            _model = new Model();
            _drawingState.Initialize(_model);
        }

        [TestMethod]
        public void MouseDownTest()
        {
            _model.SetDrawingMode("Process");
            _drawingState.MouseDown(10, 20);

            // 檢查 Model 的狀態
            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count); // MouseDown 不應該添加形狀

            // 無效座標測試
            _drawingState.MouseDown(-10, -20);
            shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count); // MouseDown 不應該添加形狀
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            _model.SetDrawingMode("Process");
            _drawingState.MouseDown(10, 20);
            _drawingState.MouseMove(30, 40);

            // 檢查 Model 的狀態
            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count); // MouseMove 不應該添加形狀

            // 測試 _isPressed 為 false 的情況
            _drawingState.MouseUp(30, 40);
            _drawingState.MouseMove(50, 60);
            shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);

            // 測試 _previewShape 為 null 的情況
            _drawingState = new DrawingState(_pointerState);
            _drawingState.Initialize(_model);
            _drawingState.MouseMove(30, 40);
            shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
        }

        [TestMethod]
        public void MouseUpTest()
        {
            _model.SetDrawingMode("Process");
            _drawingState.MouseDown(10, 20);
            _drawingState.MouseMove(30, 40);
            _drawingState.MouseUp(30, 40);

            // 檢查 Model 的狀態
            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(10, shapes[0].X);
            Assert.AreEqual(20, shapes[0].Y);
            Assert.AreEqual(20, shapes[0].Width);
            Assert.AreEqual(20, shapes[0].Height);

            // 無效狀態測試
            _drawingState.MouseUp(30, 40);
            shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count); // 應該還是只有一個形狀
        }

        [TestMethod]
        public void OnPaintTest()
        {
            var graphicsMock = new MockGraphic();
            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(10, 20);
            _drawingState.MouseMove(30, 40);
            _drawingState.OnPaint(graphicsMock); // 測試 _isPressed 為 true 的情況
            _drawingState.MouseUp(30, 40);
            _drawingState.OnPaint(graphicsMock); // 測試 _isPressed 為 false 的情況

            _model.AddShape("Start", "test", 10, 20, 20, 20);
            _model.AddShape("Terminator", "test", 10, 20, 20, 20);
            _model.AddShape("Process", "test", 10, 20, 20, 20);
            _model.AddShape("Decision", "test", 10, 20, 20, 20);
            _drawingState.OnPaint(graphicsMock);
        }

        [TestMethod]
        public void GenerateRandomTextTest()
        {
            var randomText = DrawingState.GenerateRandomText(8);
            Assert.AreEqual(8, randomText.Length);
        }
    }
}
