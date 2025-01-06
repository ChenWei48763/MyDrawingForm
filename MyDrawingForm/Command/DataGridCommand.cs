using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class DataGridCommand : ICommand
    {
        private Model _model;
        private Shape _shape;
        private bool _isAdd;

        public DataGridCommand(Model model, Shape shape, bool isAdd)
        {
            _model = model;
            _shape = shape;
            _isAdd = isAdd;
        }

        public void Execute()
        {
            if (_isAdd)
            {
                _model.AddShape(_shape);
            }
            else
            {
                _model.RemoveShape(_shape);
            }
        }

        public void UnExecute()
        {
            if (_isAdd)
            {
                _model.RemoveShape(_shape);
            }
            else
            {
                _model.AddShape(_shape);
            }
        }
    }
}
