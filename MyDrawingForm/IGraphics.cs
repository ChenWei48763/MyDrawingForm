using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyDrawingForm
{
    public interface IGraphics
    {
        void ClearAll();
        void DrawLine(float x1, float y1, float x2, float y2);
        void DrawRectangle(float x, float y, float height, float width);
        void DrawEllipse(float x, float y, float height, float width);
        void DrawArc(float x, float y, float height, float width, float startAngle, float sweepAngle);
        void DrawString(string text, float x, float y);
        void DrawPolygon(float x, float y, float height, float width);
        void DrawBoundingBox(float x, float y, float height, float width);
        void DrawTextBoundingBox(float x, float y, float height, float width);
        void DrawFilledEllipse(float x, float y, float height, float width);
        void DrawDot(int x, int y, int height, int width);
    }
}
