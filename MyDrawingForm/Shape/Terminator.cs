using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class Terminator : Shape
    {
        public Terminator(int id, string text, float x, float y, float height, float width)
            : base("Terminator", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            Normalize();
            // 繪製左半圓
            graphics.DrawArc(X, Y, Height, Height, 90, 180);
            // 繪製右半圓
            graphics.DrawArc(X + Width - Height, Y, Height, Height, 270, 180);
            // 繪製上方直線
            graphics.DrawLine(X + Height / 2, Y, X + Width - Height / 2, Y);
            // 繪製下方直線
            graphics.DrawLine(X + Height / 2, Y + Height, X + Width - Height / 2, Y + Height);
            // 繪製文字
            graphics.DrawString(Text, X + Width / 3, Y + Height / 3);
        }

        public override bool IsPointInShape(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(X, Y, Height, Height, 90, 180); // 左半圓
            path.AddLine(X + Height / 2, Y, X + Width + Height / 2, Y); // 上方直線
            path.AddArc(X + Width, Y, Height, Height, 270, 180); // 右半圓
            path.AddLine(X + Width + Height / 2, Y + Height, X + Height / 2, Y + Height); // 下方直線
            path.CloseFigure();
            return path.IsVisible(new PointF(x, y));
        }
    }
}
