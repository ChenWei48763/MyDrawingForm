using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public abstract class Shape
    {
        public int ShapeId { get; set; }
        public string ShapeName { get; set; }
        public string Text { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public Shape(string name, int id, string text, float x, float y, float height, float width)
        {
            ShapeName = name;
            ShapeId = id;
            Text = text;
            X = x;
            Y = y;
            Height = height;
            Width = width;
        }

        public void Normalize()
        {
            if (Height < 0)
            {
                Y += Height;
                Height = -Height;
            }

            if (Width < 0)
            {
                X += Width;
                Width = -Width;
            }
        }

        public abstract void Draw(IGraphics graphics);
        public abstract bool IsPointInShape(float x, float y);
        public void DrawBoundingBox(IGraphics graphics)
        {
            graphics.DrawBoundingBox(X, Y, Height, Width);
        }
        public void DrawTextBoundingBox(IGraphics graphics)
        {
            graphics.DrawTextBoundingBox(X + Width / 3, Y + Height / 3, 20, 60);
        }
    }
}
