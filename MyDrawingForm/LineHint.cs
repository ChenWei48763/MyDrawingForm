using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class LineHint
    {
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }

        public LineHint(int startX, int startY, int endX, int endY)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
        }

        public void Render(IGraphics graphics)
        {
            graphics.DrawLine(StartX, StartY, EndX, EndY);
        }
    }
}