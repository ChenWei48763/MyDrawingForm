using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyDrawingForm
{
    public interface IState
    {
        void Initialize(Model m);
        void OnPaint(IGraphics g);
        void MouseDown(int x, int y);
        void MouseMove(int x, int y);
        void MouseUp(int x, int y);
    }
}
