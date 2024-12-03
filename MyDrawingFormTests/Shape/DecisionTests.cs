using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass]
    public class DecisionTests
    {
        [TestMethod()]
        public void DecisionTest()
        {
            Shape shape = new Decision(1, "test", 10, 20, 30, 40);
            Assert.AreEqual(1, shape.ShapeId);
            Assert.AreEqual("Decision", shape.ShapeName);
            Assert.AreEqual("test", shape.Text);
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
        }

        [TestMethod()]
        public void DrawTest()
        {
            IGraphics graphics = new MockGraphic();
            Shape shape = new Decision(1, "test", 10, 20, 30, 40);
            shape.Draw(graphics);
        }

        [TestMethod()]
        public void IsPointInShapeTest()
        {
            Shape shape = new Decision(1, "test", 10, 20, 30, 40);
            Assert.AreEqual(true, shape.IsPointInShape(20, 30));
            Assert.AreEqual(false, shape.IsPointInShape(10, 10));
        }
    }
}
