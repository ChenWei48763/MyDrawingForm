using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class PointerState : IState
    {
        Model _m;

        public Shape selectedShape;
        private int _previewX;
        private int _previewY;
        private int _startX;
        private int _startY;
        private int _startTextX;
        private int _startTextY;
        private bool _isPressed;
        private bool _isTextHandlePressed;
        private bool _isOnceClickOnTextHandle;
        private bool _isDoubleClickOnTextHandle;

        public event Action<Shape> OnTextHandleDoubleClick;

        public void Initialize(Model m)
        {
            // 當進入PointerState時，應該尚未選取任何形狀，因此清空selectedShape
            this._m = m;
            selectedShape = null;
            _isOnceClickOnTextHandle = false;
        }

        public void MouseDown(int x, int y)
        {
            // 檢查是否有選到圖形，使用相反順序檢查，以便選到最上層的圖形
            foreach (Shape _shape in Enumerable.Reverse(_m.GetShapes()))
            {
                if (_shape.IsPointInTextHandle(x, y))
                {
                    _isDoubleClickOnTextHandle = _isOnceClickOnTextHandle;

                    if (_isDoubleClickOnTextHandle)
                    {
                        OnTextHandleDoubleClick?.Invoke(_shape);
                        _isOnceClickOnTextHandle = false;
                        return;
                    }
                    else
                    {
                        selectedShape = _shape;
                        _previewX = x;
                        _previewY = y;
                        _startTextX = _shape.TextX;
                        _startTextY = _shape.TextY;
                        _isPressed = true;
                        _isTextHandlePressed = true;
                        _isOnceClickOnTextHandle = true;
                        _m.NotifyModelChanged();
                        return;
                    }
                }
                else if (_shape.IsPointInShape(x, y))
                {
                    selectedShape = _shape;
                    _previewX = x;
                    _previewY = y;
                    _startX = _shape.X;
                    _startY = _shape.Y;
                    _startTextX = _shape.TextX;
                    _startTextY = _shape.TextY;
                    _isPressed = true;
                    _isTextHandlePressed = false;
                    _isOnceClickOnTextHandle = false;
                    _m.NotifyModelChanged();
                    return;
                }
            }
        }

        public void MouseMove(int x, int y)
        {
            if (_isPressed)
            {
                int _displacementX = x - _previewX;
                int _displacementY = y - _previewY;

                if (_isTextHandlePressed)
                {
                    // 只移動文字
                    selectedShape.TextX += _displacementX;
                    selectedShape.TextY += _displacementY;
                }
                else
                {
                    // 移動整個形狀
                    selectedShape.X += _displacementX;
                    selectedShape.Y += _displacementY;
                    selectedShape.TextX += _displacementX; // 同時移動文字
                    selectedShape.TextY += _displacementY; // 同時移動文字
                }
                _previewX = x;
                _previewY = y;
                _m.NotifyModelChanged();
            }
        }

        public void MouseUp(int x, int y)
        {
            if (_isPressed)
            {
                if (_isTextHandlePressed)
                {
                    _m.commandManager.Execute(new TextMoveCommand(selectedShape, _startTextX, _startTextY, selectedShape.TextX, selectedShape.TextY));
                }
                else
                {
                    _m.commandManager.Execute(new MoveCommand(selectedShape, _startX, _startY, selectedShape.X, selectedShape.Y));
                }
            }
            _isPressed = false;
            _isTextHandlePressed = false;
        }

        public void OnPaint(IGraphics graphics)
        {
            graphics.ClearAll();
            // 畫出所有的Shape
            foreach (Shape _shape in _m.GetShapes())
            {
                _shape.Draw(graphics);
            }
            // 畫出所有的Line
            foreach (Line line in _m.GetLines())
            {
                line.Draw(graphics);
            }
            // 畫出被選中圖形的外框
            if (selectedShape != null)
            {
                selectedShape.DrawBoundingBox(graphics);
                selectedShape.DrawTextBoundingBox(graphics);
            }
        }
    }
}
