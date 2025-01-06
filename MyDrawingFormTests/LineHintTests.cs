using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using MyDrawingForm;
using MyDrawingFormTests;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class LineHintTests
    {
        [TestMethod()]
        public void LineHintConstructorTest()
        {
            LineHint lineHint = new LineHint(10, 20, 30, 40);

            Assert.AreEqual(10, lineHint.StartX);
            Assert.AreEqual(20, lineHint.StartY);
            Assert.AreEqual(30, lineHint.EndX);
            Assert.AreEqual(40, lineHint.EndY);
        }

        [TestMethod()]
        public void RenderTest()
        {
            LineHint lineHint = new LineHint(10, 20, 30, 40);
            IGraphics graphics = new MockGraphic();

            lineHint.Render(graphics);
        }
    }
}
