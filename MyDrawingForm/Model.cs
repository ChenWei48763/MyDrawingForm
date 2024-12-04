using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MyDrawingForm
{
    public class Model
    {
        internal Shapes shapes = new Shapes();
        public event ModelChangedEventHandler ModelChanged;
        public delegate void ModelChangedEventHandler();
        private string _mode = "";

        IState pointerState;
        IState drawingState;
        public IState currentState;
        public Model()
        {
            pointerState = new PointerState();
            drawingState = new DrawingState((PointerState)pointerState);
            currentState = pointerState;
        }

        public void EnterPointerState()
        {
            pointerState.Initialize(this);
            currentState = pointerState;
        }

        public void EnterDrawingState()
        {
            drawingState.Initialize(this);
            currentState = drawingState;
        }

        public void NotifyModelChanged()
        {
            if (ModelChanged != null)
                ModelChanged();
        }

        public void PointerPressed(float x, float y)
        {
            currentState.MouseDown(x, y);
        }

        public void PointerMoved(float x, float y)
        {
            currentState.MouseMove(x, y);
        }

        public void PointerReleased(float x, float y)
        {
            currentState.MouseUp(x, y);
        }

        public void Draw(IGraphics graphics)
        {
            currentState.OnPaint(graphics);
        }

        public List<Shape> GetShapes()
        {
            return shapes.GetShapes();
        }

        public void AddShape(string shapeName, string text, float x, float y, float height, float width)
        {
            shapes.AddNewShape(shapeName, text, x, y, height, width);
            SetSelectMode();
            NotifyModelChanged();
        }

        public string GetDrawingMode()
        {
            return _mode;
        }

        public void SetDrawingMode(string mode)
        {
            _mode = mode;
            EnterDrawingState();
            NotifyModelChanged();
        }

        public void SetSelectMode()
        {
            _mode = "";
            EnterPointerState();
            NotifyModelChanged();
        }
    }
}
