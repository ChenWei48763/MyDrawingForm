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
        void MouseDown(float x, float y);
        void MouseMove(float x, float y);
        void MouseUp(float x, float y);
    }
}
