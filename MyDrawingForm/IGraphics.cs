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
        void DrawLine(int x1, int y1, int x2, int y2);
        void DrawRectangle(int x, int y, int height, int width);
        void DrawEllipse(int x, int y, int height, int width);
        void DrawArc(int x, int y, int height, int width, int startAngle, int sweepAngle);
        void DrawString(string text, int x, int y);
        void DrawPolygon(int x, int y, int height, int width);
        void DrawBoundingBox(int x, int y, int height, int width);
        void DrawTextBoundingBox(int x, int y, int height, int width);
        void DrawFilledEllipse(int x, int y, int height, int width);
        void DrawDot(int x, int y, int height, int width);
    }
}
