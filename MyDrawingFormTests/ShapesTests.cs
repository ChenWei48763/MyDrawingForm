using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System.Collections.Generic;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ShapesTests
    {
        private Shapes _shapes;
        private ShapeFactory _shapeFactory;

        [TestInitialize]
        public void Setup()
        {
            _shapes = new Shapes();
            _shapeFactory = new ShapeFactory();
        }

        [TestMethod]
        public void GetShapesTest()
        {
            var shapes = _shapes.GetShapes();
            Assert.IsNotNull(shapes);
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void GetLinesTest()
        {
            var lines = _shapes.GetLines();
            Assert.IsNotNull(lines);
            Assert.AreEqual(0, lines.Count);
        }

        [TestMethod]
        public void GetNewShapeTest()
        {
            // 測試 shapeList 為空的情況
            var shape = _shapes.GetNewShape("Process", "test", 10, 20, 30, 40);
            Assert.IsNotNull(shape);
            Assert.AreEqual("Process", shape.ShapeName);
            Assert.AreEqual(1, shape.ShapeId);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);

            // 測試 shapeList 不為空的情況
            _shapes.AddShape(shape);
            var newShape = _shapes.GetNewShape("Process", "test2", 50, 60, 70, 80);
            Assert.IsNotNull(newShape);
            Assert.AreEqual("Process", newShape.ShapeName);
            Assert.AreEqual(2, newShape.ShapeId);
            Assert.AreEqual("test2", newShape.Text);
            Assert.AreEqual(50, newShape.X);
            Assert.AreEqual(60, newShape.Y);
            Assert.AreEqual(70, newShape.Height);
            Assert.AreEqual(80, newShape.Width);
        }

        [TestMethod]
        public void AddShapeTest()
        {
            var shape = _shapeFactory.Create("Process", 1, "test", 10, 20, 30, 40);
            _shapes.AddShape(shape);
            var shapes = _shapes.GetShapes();
            Assert.AreEqual(1, shapes.Count);
            Assert.AreEqual(shape, shapes[0]);
        }

        [TestMethod]
        public void RemoveShapeTest()
        {
            var shape = _shapeFactory.Create("Process", 1, "test", 10, 20, 30, 40);
            _shapes.AddShape(shape);
            _shapes.RemoveShape(shape);
            var shapes = _shapes.GetShapes();
            Assert.AreEqual(0, shapes.Count);
        }

        [TestMethod]
        public void GetShapeByIdTest()
        {
            var shape1 = _shapeFactory.Create("Process", 1, "test1", 10, 20, 30, 40);
            var shape2 = _shapeFactory.Create("Process", 2, "test2", 50, 60, 70, 80);
            _shapes.AddShape(shape1);
            _shapes.AddShape(shape2);

            var retrievedShape1 = _shapes.GetShape(1);
            var retrievedShape2 = _shapes.GetShape(2);
            var retrievedShape3 = _shapes.GetShape(3); // 不存在的 ID

            Assert.IsNotNull(retrievedShape1);
            Assert.AreEqual(shape1, retrievedShape1);

            Assert.IsNotNull(retrievedShape2);
            Assert.AreEqual(shape2, retrievedShape2);

            Assert.IsNull(retrievedShape3);
        }
    }
}