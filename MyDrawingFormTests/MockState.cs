using System;
using System.ComponentModel;
using MyDrawingForm;

namespace MyDrawingFormTests
{
    public class MockState : IState
    {
        Model _model;
        public float MouseDownX { get; private set; }
        public float MouseDownY { get; private set; }
        public float MouseMoveX { get; private set; }
        public float MouseMoveY { get; private set; }
        public float MouseUpX { get; private set; }
        public float MouseUpY { get; private set; }
        public bool isOnPaintCalled = false;

        public void Initialize(Model m)
        {
            this._model = m;
        }

        public void OnPaint(IGraphics g)
        {
            isOnPaintCalled = true;
        }

        public void MouseDown(int x, int y)
        {
            MouseDownX = x;
            MouseDownY = y;
        }

        public void MouseMove(int x, int y)
        {
            MouseMoveX = x;
            MouseMoveY = y;
        }

        public void MouseUp(int x, int y)
        {
            MouseUpX = x;
            MouseUpY = y;
        }
    }
}


