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
            float adjustedX = X;
            float adjustedY = Y;
            float adjustedWidth = Width;
            float adjustedHeight = Height;

            // 調整 X 和 Width
            if (Width < 0)
            {
                adjustedX += Width;
                adjustedWidth = -Width;
            }

            // 調整 Y 和 Height
            if (Height < 0)
            {
                adjustedY += Height;
                adjustedHeight = -Height;
            }
            // 繪製左半圓
            graphics.DrawArc(adjustedX, adjustedY, adjustedHeight, adjustedHeight, 90, 180);
            // 繪製右半圓
            graphics.DrawArc(adjustedX + adjustedWidth - adjustedHeight, adjustedY, adjustedHeight, adjustedHeight, 270, 180);
            // 繪製上方直線
            graphics.DrawLine(adjustedX + adjustedHeight / 2, adjustedY, adjustedX + adjustedWidth - adjustedHeight / 2, adjustedY);
            // 繪製下方直線
            graphics.DrawLine(adjustedX + adjustedHeight / 2, adjustedY + adjustedHeight, adjustedX + adjustedWidth - adjustedHeight / 2, adjustedY + adjustedHeight);
            // 繪製文字
            graphics.DrawString(Text, TextX, TextY);
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
