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
        public Terminator(int id, string text, int x, int y, int height, int width)
            : base("Terminator", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            int width = Width;
            int height = Height;

            if (width < height)
            {
                height = width;
            }
            // 繪製左半圓
            graphics.DrawArc(X, Y, height, height, 90, 180);
            // 繪製右半圓
            graphics.DrawArc(X + width - height, Y, height, height, 270, 180);
            // 繪製上方直線
            graphics.DrawLine(X + height / 2, Y, X + width - height / 2, Y);
            // 繪製下方直線
            graphics.DrawLine(X + height / 2, Y + height, X + width - height / 2, Y + height);
            // 繪製文字
            graphics.DrawString(Text, TextX, TextY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(X, Y, Height, Height, 90, 180); // 左半圓
            path.AddLine(X + Height / 2, Y, X + Width - Height / 2, Y); // 上方直線
            path.AddArc(X + Width - Height, Y, Height, Height, 270, 180); // 右半圓
            path.AddLine(X + Width - Height / 2, Y + Height, X + Height / 2, Y + Height); // 下方直線
            path.CloseFigure();
            return path.IsVisible(new PointF(x, y));
        }

        public override int GetConnectorNumber(int x, int y)
        {
            const int connectorRadius = 10;

            // 上方連接器
            if (IsPointInCircle(x, y, X + Width / 2, Y, connectorRadius))
            {
                return 1;
            }
            // 左方連接器
            if (IsPointInCircle(x, y, X, Y + Height / 2, connectorRadius))
            {
                return 2;
            }
            // 下方連接器
            if (IsPointInCircle(x, y, X + Width / 2, Y + Height, connectorRadius))
            {
                return 3;
            }
            // 右方連接器
            if (IsPointInCircle(x, y, X + Width, Y + Height / 2, connectorRadius))
            {
                return 4;
            }

            // 如果點不在任何連接器上，返回 -1
            return -1;
        }
    }
}
