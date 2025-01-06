using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class LineTests
    {
        [TestMethod()]
        public void LineConstructorTest()
        {
            Shape fromShape = new Process(1, "from", 10, 20, 30, 40);
            Shape toShape = new Process(2, "to", 50, 60, 70, 80);
            Line line = new Line(fromShape, toShape, 1, 2);

            Assert.AreEqual(fromShape, line.FromShape);
            Assert.AreEqual(toShape, line.ToShape);
            Assert.AreEqual(1, line.FromConnector);
            Assert.AreEqual(2, line.ToConnector);
        }

        [TestMethod()]
        public void DrawTest()
        {
            Shape fromShape = new Process(1, "from", 10, 20, 30, 40);
            Shape toShape = new Process(2, "to", 50, 60, 70, 80);
            Line line = new Line(fromShape, toShape, 1, 2);
            IGraphics graphics = new MockGraphic();

            line.Draw(graphics);
        }

        [TestMethod()]
        public void GetConnectorCoordinatesTest()
        {
            Shape shape = new Process(1, "test", 10, 20, 30, 40);
            Line line = new Line(shape, shape, 1, 2);

            var coordinates = line.GetConnectorCoordinates(shape, 1);
            Assert.AreEqual((shape.X + shape.Width / 2, shape.Y), coordinates);

            coordinates = line.GetConnectorCoordinates(shape, 2);
            Assert.AreEqual((shape.X, shape.Y + shape.Height / 2), coordinates);

            coordinates = line.GetConnectorCoordinates(shape, 3);
            Assert.AreEqual((shape.X + shape.Width / 2, shape.Y + shape.Height), coordinates);

            coordinates = line.GetConnectorCoordinates(shape, 4);
            Assert.AreEqual((shape.X + shape.Width, shape.Y + shape.Height / 2), coordinates);
        }
    }
}
