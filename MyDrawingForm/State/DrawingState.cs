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
        private int _firstPointX;
        private int _firstPointY;
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

        public void MouseDown(int x, int y)
        {
            if (x > 0 && y > 0)
            {
                _firstPointX = x;
                _firstPointY = y;
                _isPressed = true;
            }
            _previewShape = _m.GetShape(_m.GetDrawingMode(), "", x, y, 0, 0);
        }

        public void MouseMove(int x, int y)
        {
            if (_isPressed && _previewShape != null)
            {
                int newWidth = x - _firstPointX;
                int newHeight = y - _firstPointY;

                bool shouldRedraw = false;

                if (newWidth < 0)
                {
                    if (_previewShape.X != x || _previewShape.Width != -newWidth)
                    {
                        _previewShape.X = x;
                        _previewShape.Width = -newWidth;
                        shouldRedraw = true;
                    }
                }
                else
                {
                    if (_previewShape.X != _firstPointX || _previewShape.Width != newWidth)
                    {
                        _previewShape.X = _firstPointX;
                        _previewShape.Width = newWidth;
                        shouldRedraw = true;
                    }
                }

                if (newHeight < 0)
                {
                    if (_previewShape.Y != y || _previewShape.Height != -newHeight)
                    {
                        _previewShape.Y = y;
                        _previewShape.Height = -newHeight;
                        shouldRedraw = true;
                    }
                }
                else
                {
                    if (_previewShape.Y != _firstPointY || _previewShape.Height != newHeight)
                    {
                        _previewShape.Y = _firstPointY;
                        _previewShape.Height = newHeight;
                        shouldRedraw = true;
                    }
                }

                if (shouldRedraw)
                {
                    _m.NotifyModelChanged();
                }
            }
        }

        public void MouseUp(int x, int y)
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
                _previewShape.Text = GenerateRandomText(8);
                _m.commandManager.Execute(new AddCommand(_m, _previewShape));
                _m.EnterPointerState();
                _pointerState.selectedShape = _previewShape;
                _previewShape = null;
                _m.NotifyModelChanged();
            }
        }

        public void OnPaint(IGraphics graphics)
        {
            foreach (Shape shape in _m.GetShapes())
            {
                shape.Draw(graphics);
            }
            foreach (Line line in _m.GetLines())
            {
                line.Draw(graphics);
            }
            if (_isPressed && _previewShape != null)
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
