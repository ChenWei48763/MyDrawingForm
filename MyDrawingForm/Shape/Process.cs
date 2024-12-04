using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawingForm
{
    public class Process : Shape
    {
        public Process(int id, string text, float x, float y, float height, float width)
            : base("Process", id, text, x, y, height, width) { }

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
            graphics.DrawRectangle(adjustedX, adjustedY, adjustedHeight, adjustedWidth);
            graphics.DrawString(Text, TextX, TextY);
        }
        public override bool IsPointInShape(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle((int)X, (int)Y, (int)Width, (int)Height));
            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
