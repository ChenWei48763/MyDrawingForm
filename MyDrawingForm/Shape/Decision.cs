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
        public Decision(int id, string text, int x, int y, int height, int width)
            : base("Decision", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawPolygon(X, Y, Width, Height);
            graphics.DrawString(Text, TextX, TextY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            Point[] points = new Point[4];
            points[0] = new Point(X + Width / 2, Y);
            points[1] = new Point(X + Width, Y + Height / 2);
            points[2] = new Point(X + Width / 2, Y + Height);
            points[3] = new Point(X, Y + Height / 2);
            path.AddPolygon(points);
            return path.IsVisible(new Point(x, y));
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