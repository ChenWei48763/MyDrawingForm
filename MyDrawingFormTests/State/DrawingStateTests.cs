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

            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count);

            _drawingState.MouseDown(-10, -20);
            shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            _model.SetDrawingMode("Process");
            _drawingState.MouseDown(10, 20);
            _drawingState.MouseMove(5, 15);

            var shapes = _model.GetShapes();
            Assert.AreEqual(0, shapes.Count);

            _drawingState.MouseUp(5, 15);
            shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(5, shapes[0].X);
            Assert.AreEqual(15, shapes[0].Y);
            Assert.AreEqual(5, shapes[0].Width);
            Assert.AreEqual(5, shapes[0].Height);

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

            var shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(10, shapes[0].X);
            Assert.AreEqual(20, shapes[0].Y);
            Assert.AreEqual(20, shapes[0].Width);
            Assert.AreEqual(20, shapes[0].Height);

            _drawingState.MouseUp(30, 40);
            shapes = _model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
        }

        [TestMethod]
        public void OnPaintTest()
        {
            var graphicsMock = new MockGraphic();
            _model.SetDrawingMode("Start");
            _drawingState.MouseDown(10, 20);
            _drawingState.MouseMove(30, 40);
            _drawingState.OnPaint(graphicsMock);
            _drawingState.MouseUp(30, 40);
            _drawingState.OnPaint(graphicsMock);

            _model.AddShape(new Start(1, "test", 10, 20, 20, 20));
            _model.AddShape(new Terminator(2, "test", 10, 20, 20, 20));
            _model.AddShape(new Process(3, "test", 10, 20, 20, 20));
            _model.AddShape(new Decision(4, "test", 10, 20, 20, 20));
            _model.AddLine(new Line(new Process(1, "from", 10, 20, 30, 40), new Process(2, "to", 50, 60, 70, 80), 1, 2));
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
