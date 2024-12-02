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

        public void MouseDown(float x, float y)
        {
            MouseDownX = x;
            MouseDownY = y;
        }

        public void MouseMove(float x, float y)
        {
            MouseMoveX = x;
            MouseMoveY = y;
        }

        public void MouseUp(float x, float y)
        {
            MouseUpX = x;
            MouseUpY = y;
        }
    }
}


