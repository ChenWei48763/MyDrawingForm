using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MyDrawingForm
{
    public abstract class Shape
    {
        public int ShapeId { get; set; }
        public string ShapeName { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int TextX { get; set; }
        public int TextY { get; set; }

        public Shape(string name, int id, string text, int x, int y, int height, int width)
        {
            ShapeName = name;
            ShapeId = id;
            Text = text;
            X = x;
            Y = y;
            Height = height;
            Width = width;
            TextX = X + Width / 3;
            TextY = Y + Height / 3;
        }

        public void Normalize()
        {
            if (Height < 0)
            {
                Height = -Height;
                Y -= Height;
            }

            if (Width < 0)
            {
                Width = -Width;
                X -= Width;
            }
        }

        public abstract void Draw(IGraphics graphics);
        public abstract bool IsPointInShape(int x, int y);

        public bool IsPointInTextHandle(int x, int y)
        {
            const int handleRadius = 4;
            int handleX = TextX + 35;
            int handleY = TextY - handleRadius / 2;
            return (x - handleX) * (x - handleX) + (y - handleY) * (y - handleY) <= handleRadius * handleRadius;
        }

        public void DrawBoundingBox(IGraphics graphics)
        {
            graphics.DrawBoundingBox(X, Y, Height, Width);
        }

        public void DrawTextBoundingBox(IGraphics graphics)
        {
            graphics.DrawTextBoundingBox(TextX, TextY, 20, Text.Length * 10);
            DrawTextHandle(graphics);
        }

        public void DrawTextHandle(IGraphics graphics)
        {
            const int handleRadius = 4;
            int handleX = TextX + 35;
            int handleY = TextY - handleRadius;
            graphics.DrawFilledEllipse(handleX - handleRadius, handleY, handleRadius * 2, handleRadius * 2);
        }

        public void DrawConnector(IGraphics graphics)
        {
            graphics.DrawDot((X + Width / 2) - 5, Y - 5, 10, 10);
            graphics.DrawDot(X - 5, (Y + Height / 2) - 5, 10, 10);
            graphics.DrawDot((X + Width / 2) - 5, (Y + Height) - 5, 10, 10);
            graphics.DrawDot((X + Width) - 5, (Y + Height / 2) - 5, 10, 10);
        }

        public abstract int GetConnectorNumber(int x, int y);

        public bool IsPointInCircle(int px, int py, int cx, int cy, int radius)
        {
            return (px - cx) * (px - cx) + (py - cy) * (py - cy) <= radius * radius;
        }

        public void UpdateText(string newText)
        {
            Text = newText;
        }
    }
}
