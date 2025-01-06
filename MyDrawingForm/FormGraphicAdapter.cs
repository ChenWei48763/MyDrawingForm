using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    class FormGraphicAdapter : IGraphics
    {
        Graphics _graphics;
        private readonly Pen _pen = new Pen(Color.Black, 2);
        private readonly Font _font = new Font("Arial", 10);
        private readonly Brush _brush = new SolidBrush(Color.Black);

        public FormGraphicAdapter(Graphics graphics)
        {
            this._graphics = graphics;
        }

        public void ClearAll()
        {
            // OnPaint時會自動清除畫面，因此不需實作
        }

        public void DrawLine(float x1, float y1, float x2, float y2)
        {
            _graphics.DrawLine(_pen, x1, y1, x2, y2);
        }

        public void DrawRectangle(float x, float y, float height, float width)
        {
            _graphics.DrawRectangle(_pen, x, y, width, height);
        }

        public void DrawEllipse(float x, float y, float height, float width)
        {
            _graphics.DrawEllipse(_pen, x, y, width, height);
        }

        public void DrawArc(float x, float y, float height, float width, float startAngle, float sweepAngle)
        {
            try
            {
                _graphics.DrawArc(_pen, x, y, width, height, startAngle, sweepAngle);
            }
            catch (Exception)
            {
                Console.WriteLine("高度或寬度為負值");
            }
        }

        public void DrawString(string text, float x, float y)
        {
            _graphics.DrawString(text, _font, _brush, x, y);
        }

        public void DrawPolygon(float x, float y, float height, float width)
        {
            Point[] points = new Point[4];
            points[0] = new Point((int)(x + height / 2), (int)y);
            points[1] = new Point((int)(x + height), (int)(y + width / 2));
            points[2] = new Point((int)(x + height / 2), (int)(y + width));
            points[3] = new Point((int)x, (int)(y + width / 2));
            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawBoundingBox(float x, float y, float height, float width)
        {
            using (Pen redPen = new Pen(Color.Red, 3))
            {
                _graphics.DrawRectangle(redPen, x, y, width, height);
            }
        }

        public void DrawTextBoundingBox(float x, float y, float height, float width)
        {
            using (Pen redPen = new Pen(Color.Red, 2))
            {
                _graphics.DrawRectangle(redPen, x, y, width, height);
            }
        }

        public void DrawFilledEllipse(float x, float y, float height, float width)
        {
            using (Brush brush = new SolidBrush(Color.Orange))
            {
                _graphics.FillEllipse(brush, x, y, width, height);
            }
        }

        public void DrawDot(int x, int y, int width, int height)
        {
            _graphics.FillRectangle(new SolidBrush(Color.Black), x, y, width, height);
        }
    }
}
