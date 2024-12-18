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

        public List<Shape> selectedShapes = new List<Shape>();
        private float _previewX;
        private float _previewY;
        private bool _isPressed;
        private bool _isTextHandlePressed;
        private bool _isOnceClickOnTextHandle;
        private bool _isDoubleClickOnTextHandle;

        public void Initialize(Model m)
        {
            // 當進入PointerState時，應該尚未選取任何形狀，因此清空selectedShapes
            this._m = m;
            selectedShapes.Clear();
            _isOnceClickOnTextHandle = false;
        }

        public void MouseDown(float x, float y)
        {
            // 檢查是否有選到圖形，使用相反順序檢查，以便選到最上層的圖形
            foreach (Shape _shape in Enumerable.Reverse(_m.GetShapes()))
            {
                if (_shape.IsPointInTextHandle(x, y))
                {
                    _isDoubleClickOnTextHandle = _isOnceClickOnTextHandle;

                    if (_isDoubleClickOnTextHandle)
                    {
                        using (var dialog = new Form2(_shape.Text))
                        {
                            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                _shape.UpdateText(dialog.GetTextBoxText());
                                _m.NotifyModelChanged();
                            }
                        }
                        _isOnceClickOnTextHandle = false;
                        return;
                    }
                    else
                    {
                        selectedShapes.Clear();
                        AddSelectedShape(_shape);
                        _previewX = x;
                        _previewY = y;
                        _isPressed = true;
                        _isTextHandlePressed = true;
                        _isOnceClickOnTextHandle = true;
                        _m.NotifyModelChanged();
                        return;
                    }
                }
                else if (_shape.IsPointInShape(x, y))
                {
                    selectedShapes.Clear();
                    AddSelectedShape(_shape);
                    _previewX = x;
                    _previewY = y;
                    _isPressed = true;
                    _isTextHandlePressed = false;
                    _isOnceClickOnTextHandle = false;
                    _m.NotifyModelChanged();
                    return;
                }
            }
        }

        public void AddSelectedShape(Shape _shape)
        {
            if (!selectedShapes.Contains(_shape))
            {
                selectedShapes.Add(_shape);
            }
        }

        public void MouseMove(float x, float y)
        {
            if (_isPressed)
            {
                int _displacementX = (int)x - (int)_previewX;
                int _displacementY = (int)y - (int)_previewY;

                foreach (Shape _shape in selectedShapes)
                {
                    if (_isTextHandlePressed)
                    {
                        // 只移動文字
                        _shape.TextX += _displacementX;
                        _shape.TextY += _displacementY;
                    }
                    else
                    {
                        // 移動整個形狀
                        _shape.X += _displacementX;
                        _shape.Y += _displacementY;
                        _shape.TextX += _displacementX; // 同時移動文字
                        _shape.TextY += _displacementY; // 同時移動文字
                    }
                    _previewX = x;
                    _previewY = y;
                }
                _m.NotifyModelChanged();
            }
        }

        public void MouseUp(float x, float y)
        {
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
            // 畫出被選中圖形的外框
            foreach (Shape selectedShape in selectedShapes)
            {
                if (selectedShape != null)
                {
                    selectedShape.DrawBoundingBox(graphics);
                    selectedShape.DrawTextBoundingBox(graphics);
                }
            }
        }
    }
}
