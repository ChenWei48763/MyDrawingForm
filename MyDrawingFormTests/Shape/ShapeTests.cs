using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using MyDrawingFormTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class ShapeTests
    {
        [TestMethod()]
        public void NormalizeTest()
        {
            Shape shape = new Process(0, "test", 10, 20, 30, 40);
            shape.Normalize();
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);

            shape = new Process(0, "test", 10, 20, -30, -40);
            shape.Normalize();
            Assert.AreEqual(-30, shape.X);
            Assert.AreEqual(-10, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
        }

        [TestMethod()]
        public void DrawBoundingBoxTest()
        {
            Shape shape = new Process(0, "test", 10, 20, 30, 40);
            IGraphics graphics = new MockGraphic();
            shape.DrawBoundingBox(graphics);
        }

        [TestMethod()]
        public void DrawConnectorTest()
        {
            Shape shape = new Process(0, "test", 10, 20, 30, 40);
            IGraphics graphics = new MockGraphic();
            shape.DrawConnector(graphics);
        }

        [TestMethod()]
        public void IsPointInCircleTest()
        {
            Shape shape = new Process(0, "test", 10, 20, 30, 40);
            bool result = shape.IsPointInCircle(10, 20, 15, 20, 10);
            Assert.IsTrue(result);

            result = shape.IsPointInCircle(20, 30, 10, 20, 10);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void UpdateTextTest()
        {
            Shape shape = new Process(0, "test", 10, 20, 30, 40);
            shape.UpdateText("new text");
            Assert.AreEqual("new text", shape.Text);
        }
    }
}