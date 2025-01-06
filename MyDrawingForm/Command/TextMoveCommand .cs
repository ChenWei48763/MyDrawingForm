using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class TextMoveCommand : ICommand
    {
        private Shape _shape;
        private int _startTextX, _startTextY;
        private int _endTextX, _endTextY;

        public TextMoveCommand(Shape shape, int startTextX, int startTextY, int endTextX, int endTextY)
        {
            _shape = shape;
            _startTextX = startTextX;
            _startTextY = startTextY;
            _endTextX = endTextX;
            _endTextY = endTextY;
        }

        public void Execute()
        {
            _shape.TextX = _endTextX;
            _shape.TextY = _endTextY;
        }

        public void UnExecute()
        {
            _shape.TextX = _startTextX;
            _shape.TextY = _startTextY;
        }
    }
}
