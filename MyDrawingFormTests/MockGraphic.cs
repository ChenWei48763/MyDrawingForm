using System;
using System.Drawing;
using MyDrawingForm;

namespace MyDrawingFormTests
{
    public class MockGraphic : IGraphics
    {

        public void ClearAll()
        {
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
        }

        public void DrawRectangle(int x, int y, int height, int width)
        {
        }

        public void DrawEllipse(int x, int y, int height, int width)
        {
        }

        public void DrawArc(int x, int y, int height, int width, int startAngle, int sweepAngle)
        {
        }

        public void DrawString(string text, int x, int y)
        {
        }

        public void DrawPolygon(int x, int y, int height, int width)
        {
        }

        public void DrawBoundingBox(int x, int y, int height, int width)
        {
        }

        public void DrawTextBoundingBox(int x, int y, int height, int width)
        {
        }
        public void DrawFilledEllipse(int x, int y, int height, int width)
        {
        }
        public void DrawDot(int x, int y, int height, int width)
        {

        }
    }
}

