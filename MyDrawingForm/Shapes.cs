using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDrawingForm
{
    // 表示圖形的類別
    internal class Shapes
    {
        public List<Shape> shapeList = new List<Shape>();
        public List<Line> lineList = new List<Line>();
        private static readonly ShapeFactory shapeFactory = new ShapeFactory();

        public List<Shape> GetShapes()
        {
            return shapeList;
        }

        public List<Line> GetLines()
        {
            return lineList;
        }

        public Shape GetNewShape(string shape, string name, int x, int y, int height, int width)
        {
            int id;
            if (shapeList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = shapeList.Last().ShapeId + 1;
            }
            return shapeFactory.Create(shape, id, name, x, y, height, width);
        }

        public void AddShape(Shape s)
        {
            shapeList.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            shapeList.Remove(s);
        }
    }
}