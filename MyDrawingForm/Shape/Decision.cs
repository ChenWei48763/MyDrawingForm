using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawingForm
{
    public class Decision : Shape
    {
        public Decision(int id, string text, float x, float y, float height, float width)
            : base("Decision", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawPolygon(X, Y, Width, Height);
            graphics.DrawString(Text, TextX, TextY);
        }

        public override bool IsPointInShape(float x, float y)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] points = new Point[4];
            points[0] = new Point((int)X + (int)Width / 2, (int)Y);
            points[1] = new Point((int)X + (int)Width, (int)Y + (int)Height / 2);
            points[2] = new Point((int)X + (int)Width / 2, (int)Y + (int)Height);
            points[3] = new Point((int)X, (int)Y + (int)Height / 2);
            path.AddPolygon(points);
            return path.IsVisible(new Point((int)x, (int)y));
        }
    }
}
