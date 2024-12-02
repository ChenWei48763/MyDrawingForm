using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MyDrawingForm
{
    // 用來創建和管理圖形的工廠類別
    internal class ShapeFactory
    {
        public Shape Create(string shapeName, int id, string text, float x, float y, float height, float width)
        {
            switch (shapeName)
            {
                case "Terminator":
                    return new Terminator(id, text, x, y, height, width);
                case "Start":
                    return new Start(id, text, x, y, height, width);
                case "Process":
                    return new Process(id, text, x, y, height, width);
                case "Decision":
                    return new Decision(id, text, x, y, height, width);
                default:
                    throw new ArgumentException("Invalid shape type");
            }
        }
    }
}
