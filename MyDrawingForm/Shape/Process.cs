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
        public Process(int id, string text, int x, int y, int height, int width)
            : base("Process", id, text, x, y, height, width) { }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(X, Y, Height, Width);
            graphics.DrawString(Text, TextX, TextY);
        }

        public override bool IsPointInShape(int x, int y)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new Rectangle(X, Y, Width, Height));
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
