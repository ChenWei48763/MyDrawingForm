using System;
using System.Collections.Generic;
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
        private static readonly ShapeFactory shapeFactory = new ShapeFactory();

        public List<Shape> GetShapes()
        {
            return shapeList;
        }

        public Shape CreateShape(string shapeName, string text, float x, float y, float height, float width)
        {
            int id;
            if (shapeList.Count == 0)
            {
                id = 0;
            }
            else
            {
                id = shapeList[shapeList.Count - 1].ShapeId + 1;
            }
            return shapeFactory.Create(shapeName, id, text, x, y, height, width);
        }
        public void AddNewShape(string shape, string name, float x, float y, float height, float width)
        {
            shapeList.Add(CreateShape(shape, name, x, y, height, width));
        }

        public void DeleteShape(int id)
        {
            for (int i = 0; i < shapeList.Count; i++)
            {
                if (shapeList[i].ShapeId == id)
                {
                    shapeList.RemoveAt(i);
                    break;
                }
            }
        }
    }
}