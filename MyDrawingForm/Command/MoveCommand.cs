using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class MoveCommand : ICommand
    {
        private Shape _shape;
        private int _startX, _startY;
        private int _endX, _endY;
        private int _textOffsetX, _textOffsetY;

        public MoveCommand(Shape shape, int startX, int startY, int endX, int endY)
        {
            _shape = shape;
            _startX = startX;
            _startY = startY;
            _endX = endX;
            _endY = endY;
            _textOffsetX = shape.TextX - shape.X;
            _textOffsetY = shape.TextY - shape.Y;
        }

        public void Execute()
        {
            _shape.X = _endX;
            _shape.Y = _endY;
            _shape.TextX = _endX + _textOffsetX;
            _shape.TextY = _endY + _textOffsetY;
        }

        public void UnExecute()
        {
            _shape.X = _startX;
            _shape.Y = _startY;
            _shape.TextX = _startX + _textOffsetX;
            _shape.TextY = _startY + _textOffsetY;
        }
    }
}
