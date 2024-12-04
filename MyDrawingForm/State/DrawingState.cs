using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class DrawingState : IState
    {
        Model _m;
        Shape _previewShape;
        PointerState _pointerState;
        private static Random random = new Random();
        private float _firstPointX;
        private float _firstPointY;
        private bool _isPressed;
        private const string CHAR_SET = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public DrawingState(PointerState pointerState)
        {
            this._pointerState = pointerState;
        }

        public void Initialize(Model m)
        {
            this._m = m;
            _isPressed = false;
            _previewShape = null;
        }

        public void MouseDown(float x, float y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
            _previewShape = _m.shapes.CreateShape(_m.GetDrawingMode(), "", x, y, 0, 0);
        }

        public void MouseMove(float x, float y)
        {
            if (_isPressed && _previewShape != null)
            {
                _previewShape.Width = x - _firstPointX;
                _previewShape.Height = y - _firstPointY;
                _m.NotifyModelChanged();
            }
        }

        public void MouseUp(float x, float y)
        {
            _isPressed = false;
            if (_previewShape == null)
            {
                return;
            }
            else
            {
                _previewShape.Normalize();
                _previewShape.TextX = _previewShape.X + _previewShape.Width / 3;
                _previewShape.TextY = _previewShape.Y + _previewShape.Height / 3;
                _m.AddShape(_m.GetDrawingMode(), GenerateRandomText(8), _previewShape.X, _previewShape.Y, _previewShape.Height, _previewShape.Width);
                _m.EnterPointerState();
                _pointerState.AddSelectedShape(_previewShape);
                _previewShape = null;
            }
        }

        public void OnPaint(IGraphics graphics)
        {
            foreach (Shape shape in _m.GetShapes())
            {
                shape.Draw(graphics);
            }
            if (_isPressed)
            {
                _previewShape.Draw(graphics);
            }
        }

        public static string GenerateRandomText(int length)
        {
            char[] chars = CHAR_SET.ToCharArray();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                text.Append(chars[random.Next(chars.Length)]);
            }
            return text.ToString();
        }
    }
}
