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
            Shape shape = new MyDrawingForm.Process(0, "test", 10, 20, 30, 40);
            shape.Normalize();
            Assert.AreEqual(10, shape.X);
            Assert.AreEqual(20, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);

            shape = new MyDrawingForm.Process(0, "test", 10, 20, -30, -40);
            shape.Normalize();
            Assert.AreEqual(-30, shape.X);
            Assert.AreEqual(-10, shape.Y);
            Assert.AreEqual(30, shape.Height);
            Assert.AreEqual(40, shape.Width);
        }

        [TestMethod()]
        public void DrawBoundingBoxTest()
        {
            Shape shape = new MyDrawingForm.Process(0, "test", 10, 20, 30, 40);
            IGraphics graphics = new MockGraphic();
            shape.DrawBoundingBox(graphics);
        }
    }
}