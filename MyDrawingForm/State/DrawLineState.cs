using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class DrawLineState : IState
    {
        private Model _model;
        private Shape _startShape, _endShape, _hoverShape;
        private LineHint _lineHint;
        private int _startConnector, _endConnector;

        public void Initialize(Model model)
        {
            _model = model;
            if (_model.GetShapes().Count <= 1)
            {
                _model.SetSelectMode();
                _model.NotifyModelChanged();
            }
        }

        public void OnPaint(IGraphics graphics)
        {
            foreach (var shape in _model.GetShapes())
            {
                shape.Draw(graphics);
            }

            foreach (var line in _model.GetLines())
            {
                line.Draw(graphics);
            }

            _lineHint?.Render(graphics);
            _hoverShape?.DrawConnector(graphics);
        }

        public void MouseDown(int x, int y)
        {
            foreach (var shape in _model.GetShapes().Reverse<Shape>())
            {
                int connector = shape.GetConnectorNumber(x, y);
                Console.WriteLine($"MouseDown: Checking shape {shape.ShapeName} at ({x}, {y}) - Connector: {connector}");
                if (connector != -1)
                {
                    if (_lineHint == null)
                    {
                        _lineHint = new LineHint(x, y, x, y);
                    }
                    else
                    {
                        _lineHint.EndX = x;
                        _lineHint.EndY = y;
                    }

                    if (_startShape == null)
                    {
                        _startShape = shape;
                        _startConnector = connector;
                    }
                    else if (_endShape == null && _startShape != shape)
                    {
                        _endShape = shape;
                        _endConnector = connector;
                        var line = new Line(_startShape, _endShape, _startConnector, _endConnector);
                        _model.commandManager.Execute(new ConnectorCommand(_model, line));

                        _lineHint = null;
                        _startShape = null;
                        _endShape = null;

                        _model.NotifyModelChanged();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            _model.NotifyModelChanged();
        }

        public void MouseMove(int x, int y)
        {
            foreach (var shape in _model.GetShapes().Reverse<Shape>())
            {
                if (shape.IsPointInShape(x, y))
                {
                    _hoverShape = shape;
                    _model.NotifyModelChanged();
                }
            }

            if (_lineHint != null)
            {
                _lineHint.EndX = x;
                _lineHint.EndY = y;
                _model.NotifyModelChanged();
            }
        }

        public void MouseUp(int x, int y)
        {
            if (_lineHint != null)
            {
                foreach (var shape in _model.GetShapes().Reverse<Shape>())
                {
                    int connector = shape.GetConnectorNumber(x, y);
                    Console.WriteLine($"MouseUp: Checking shape {shape.ShapeName} at ({x}, {y}) - Connector: {connector}");
                    if (connector != -1 && _startShape != shape)
                    {
                        _endShape = shape;
                        _endConnector = connector;
                        var line = new Line(_startShape, _endShape, _startConnector, _endConnector);
                        _model.commandManager.Execute(new ConnectorCommand(_model, line));

                        _lineHint = null;
                        _startShape = null;
                        _endShape = null;

                        _model.NotifyModelChanged();
                        return;
                    }
                }
            }
            _lineHint = null;
            _startShape = null;
            _endShape = null;
            _model.NotifyModelChanged();
        }
    }
}
