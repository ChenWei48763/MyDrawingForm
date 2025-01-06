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

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
        }

        public void DrawRectangle(float x, float y, float height, float width)
        {
        }

        public void DrawEllipse(float x, float y, float height, float width)
        {
        }

        public void DrawArc(float x, float y, float height, float width, float startAngle, float sweepAngle)
        {
        }

        public void DrawString(string text, float x, float y)
        {
        }

        public void DrawPolygon(float x, float y, float height, float width)
        {
        }

        public void DrawBoundingBox(float x, float y, float height, float width)
        {
        }

        public void DrawTextBoundingBox(float x, float y, float height, float width)
        {
        }
        public void DrawFilledEllipse(float x, float y, float height, float width)
        {
        }
        public void DrawDot(int x, int y, int height, int width)
        {

        }
    }
}

