using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class ShapeFactoryTests
    {
        ShapeFactory factory = new ShapeFactory();
        [TestMethod]
        public void CreateTest()
        {
            Shape shape = factory.Create("Start", 1, "test", 10, 20, 30, 40);
            Assert.AreEqual(1, shape.ShapeId);
            Assert.AreEqual("Start", shape.ShapeName);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
            shape = factory.Create("Process", 2, "test", 10, 20, 30, 40);
            Assert.AreEqual(2, shape.ShapeId);
            Assert.AreEqual("Process", shape.ShapeName);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
            shape = factory.Create("Decision", 3, "test", 10, 20, 30, 40);
            Assert.AreEqual(3, shape.ShapeId);
            Assert.AreEqual("Decision", shape.ShapeName);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
            shape = factory.Create("Terminator", 4, "test", 10, 20, 30, 40);
            Assert.AreEqual(4, shape.ShapeId);
            Assert.AreEqual("Terminator", shape.ShapeName);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateInvalidShapeTest()
        {
            factory.Create("InvalidShape", 1, "Test", 10, 20, 30, 40);
        }
    }
}
