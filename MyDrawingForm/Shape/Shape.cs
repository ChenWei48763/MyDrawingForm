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
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float TextX { get; set; }
        public float TextY { get; set; }

        public Shape(string name, int id, string text, float x, float y, float height, float width)
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

        public bool IsPointInTextHandle(float x, float y)
        {
            const float handleRadius = 4;
            float handleX = TextX + 35; // 小點的X座標在文字框的中間
            float handleY = TextY - handleRadius / 2; // 小點的Y座標在文字框的正上方
            return (x - handleX) * (x - handleX) + (y - handleY) * (y - handleY) <= handleRadius * handleRadius;
        }

        public void DrawBoundingBox(IGraphics graphics)
        {
            graphics.DrawBoundingBox(X, Y, Height, Width);
        }

        public void DrawTextBoundingBox(IGraphics graphics)
        {
            const float textWidth = 70;
            const float textHeight = 20;
            graphics.DrawTextBoundingBox(TextX, TextY, textHeight, textWidth);
            DrawTextHandle(graphics);
        }

        public void DrawTextHandle(IGraphics graphics)
        {
            const float handleRadius = 4;
            float handleX = TextX + 35; // 小點的X座標在文字框的中間
            float handleY = TextY - handleRadius; // 小點的Y座標在文字框的正上方
            graphics.DrawFilledEllipse(handleX - handleRadius, handleY, handleRadius * 2, handleRadius * 2);
        }

        public void UpdateText(string newText)
        {
            Text = newText;
        }
    }
}
