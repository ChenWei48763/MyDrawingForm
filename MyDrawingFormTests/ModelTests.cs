using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingFormTests;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
        public void EnterDrawLineStateTest()
        {
            model.SetDrawLineMode();
            Assert.AreEqual("", model.GetDrawingMode());
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
            model.AddShape(new Process(1, "test", 10, 20, 30, 40));
            Assert.IsNotNull(model.GetShapes());
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            model.AddShape(new Process(1, "test", 10, 20, 30, 40));
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual("Process", shapes[0].ShapeName);
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void RemoveShapeTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShape(shape);
            model.RemoveShape(shape);
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod()]
        public void AddShapeFromDataGridTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(shape, shapes[0]);
        }

        [TestMethod()]
        public void RemoveShapeFromDataGridTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            model.RemoveShapeFromDataGrid(shape);
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod()]
        public void UpdateShapeListTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            var shapeList = model.GetShapes();
            Assert.AreEqual(1, shapeList.Count);
            Assert.AreEqual(shape, shapeList[0]);
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

            model.UpdateShapeList(dataGridViewShapes);

            Assert.AreEqual(3, dataGridViewShapes.Rows.Count);
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

        [TestMethod()]
        public void SetDrawLineModeTest()
        {
            model.SetDrawLineMode();
            Assert.AreEqual("", model.GetDrawingMode());
        }

        [TestMethod()]
        public void UndoTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            model.Undo();
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod()]
        public void RedoTest()
        {
            Shape shape = new Process(1, "Test", 10, 20, 30, 40);
            model.AddShapeFromDataGrid(shape);
            model.Undo();
            model.Redo();
            List<Shape> shapes = model.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(shape, shapes[0]);
        }

        [TestMethod()]
        public void AddLineTest()
        {
            Shape shape1 = new Process(1, "Test1", 10, 20, 30, 40);
            Shape shape2 = new Process(2, "Test2", 50, 60, 70, 80);
            Line line = new Line(shape1, shape2, 1, 2);
            model.AddLine(line);
            List<Line> lines = model.GetLines();
            Assert.AreEqual(1, lines.Count);
            Assert.AreEqual(line, lines[0]);
        }

        [TestMethod()]
        public void RemoveLineTest()
        {
            Shape shape1 = new Process(1, "Test1", 10, 20, 30, 40);
            Shape shape2 = new Process(2, "Test2", 50, 60, 70, 80);
            Line line = new Line(shape1, shape2, 1, 2);
            model.AddLine(line);
            model.RemoveLine(line);
            List<Line> lines = model.GetLines();
            Assert.AreEqual(0, lines.Count);
        }
    }
}