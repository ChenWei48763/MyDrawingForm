using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class TextChangedCommand : ICommand
    {
        private Shape _shape;
        private string _oldText;
        private string _newText;

        public TextChangedCommand(Shape shape, string oldText, string newText)
        {
            _shape = shape;
            _oldText = oldText;
            _newText = newText;
        }

        public void Execute()
        {
            _shape.UpdateText(_newText);
        }

        public void UnExecute()
        {
            _shape.UpdateText(_oldText);
        }
    }
}
