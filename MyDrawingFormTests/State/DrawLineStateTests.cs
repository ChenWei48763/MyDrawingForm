using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests;
using System.Collections.Generic;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class DrawLineStateTests
    {
        private DrawLineState _drawLineState;
        private Model _model;
        private PrivateObject _pState;

        [TestInitialize]
        public void Setup()
        {
            _drawLineState = new DrawLineState();
            _model = new Model();
            _drawLineState.Initialize(_model);
            _pState = new PrivateObject(_drawLineState);
        }

        [TestMethod]
        public void InitializeTest()
        {
            Shape shape1 = new Process(1, "test1", 10, 20, 30, 40);
            Shape shape2 = new Process(2, "test2", 50, 60, 70, 80);
            _model.AddShape(shape1);
            _model.AddShape(shape2);
            _drawLineState.Initialize(_model);
            _drawLineState.Initialize(_model);
            Assert.IsNull(_pState.GetFieldOrProperty("_startShape"));
            Assert.IsNull(_pState.GetFieldOrProperty("_endShape"));
            Assert.IsNull(_pState.GetFieldOrProperty("_hoverShape"));
            Assert.IsNull(_pState.GetFieldOrProperty("_lineHint"));
        }

        [TestMethod]
        public void OnPaintTest()
        {
            var graphicsMock = new MockGraphic();
            Shape shape = new Process(1, "test", 10, 20, 30, 40);
            _model.AddShape(shape);
            _model.AddLine(new Line(shape, shape, 1, 2));

            _drawLineState.OnPaint(graphicsMock);

            // 測試 _lineHint 和 _hoverShape
            _pState.SetFieldOrProperty("_lineHint", new LineHint(10, 20, 30, 40));
            _pState.SetFieldOrProperty("_hoverShape", shape);
            _drawLineState.OnPaint(graphicsMock);
        }

        [TestMethod]
        public void MouseDownTest()
        {
            Shape shape1 = new Process(1, "test1", 10, 20, 30, 40);
            Shape shape2 = new Process(2, "test2", 50, 60, 70, 80);
            _model.AddShape(shape1);
            _model.AddShape(shape2);

            // 點擊 shape1 的上方連接器
            _drawLineState.MouseDown(25, 20);
            Assert.IsNotNull(_pState.GetFieldOrProperty("_lineHint"));

            // 點擊 shape2 的上方連接器
            _drawLineState.MouseDown(85, 60);
            Assert.IsNull(_pState.GetFieldOrProperty("_lineHint"));

            // 測試 if 條件不成立的情況
            _drawLineState.MouseDown(5, 5);
            Assert.IsNull(_pState.GetFieldOrProperty("_startShape"));

            // 測試 else 條件的情況
            _drawLineState.MouseDown(25, 20);
            _drawLineState.MouseDown(25, 20);
            var lineHint = (LineHint)_pState.GetFieldOrProperty("_lineHint");
            Assert.AreEqual(25, lineHint.EndX);
            Assert.AreEqual(20, lineHint.EndY);

            // 測試 else if 條件不成立的情況
            _drawLineState.MouseDown(25, 20);
            _drawLineState.MouseDown(25, 20);
            Assert.IsNull(_pState.GetFieldOrProperty("_endShape"));
        }

        [TestMethod]
        public void MouseMoveTest()
        {
            Shape shape = new Process(1, "test", 10, 20, 30, 40);
            _model.AddShape(shape);

            _drawLineState.MouseMove(25, 35);
            Assert.AreEqual(shape, _pState.GetFieldOrProperty("_hoverShape"));

            _pState.SetFieldOrProperty("_lineHint", new LineHint(10, 20, 30, 40));
            _drawLineState.MouseMove(50, 60);
            var lineHint = (LineHint)_pState.GetFieldOrProperty("_lineHint");
            Assert.AreEqual(50, lineHint.EndX);
            Assert.AreEqual(60, lineHint.EndY);
        }

        [TestMethod]
        public void MouseUpTest()
        {
            Shape shape1 = new Process(1, "test1", 10, 20, 30, 40);
            Shape shape2 = new Process(2, "test2", 50, 60, 70, 80);
            _model.AddShape(shape1);
            _model.AddShape(shape2);

            // 點擊 shape1 的上方連接器
            _drawLineState.MouseDown(25, 20);
            _drawLineState.MouseMove(85, 60);
            // 點擊 shape2 的上方連接器
            _drawLineState.MouseUp(85, 60);

            var lines = _model.GetLines();
            Assert.AreEqual(1, lines.Count);
            Assert.AreEqual(shape1, lines[0].FromShape);
            Assert.AreEqual(shape2, lines[0].ToShape);

            // 測試 _lineHint 為 null 的情況
            _drawLineState.MouseUp(85, 60);
            Assert.IsNull(_pState.GetFieldOrProperty("_lineHint"));
            Assert.IsNull(_pState.GetFieldOrProperty("_startShape"));
            Assert.IsNull(_pState.GetFieldOrProperty("_endShape"));

            // 測試 if 條件不成立的情況
            _drawLineState.MouseDown(25, 20);
            _drawLineState.MouseMove(25, 20);
            _drawLineState.MouseUp(25, 20);
            Assert.IsNull(_pState.GetFieldOrProperty("_endShape"));

            // 測試 else 條件的情況
            _drawLineState.MouseDown(25, 20);
            _drawLineState.MouseMove(25, 20);
            _drawLineState.MouseUp(25, 20);
            Assert.IsNull(_pState.GetFieldOrProperty("_endShape"));
        }
    }
}
















