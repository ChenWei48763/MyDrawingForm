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
            graphics.DrawRectangle(X, Y, Height, Width);
            graphics.DrawString(Text, X + Math.Abs(Width) / 3, Y + Math.Abs(Height) / 3);
        }
        public override bool IsPointInShape(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle((int)X, (int)Y, (int)Height, (int)Width));
            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
