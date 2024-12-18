using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class AddCommand : ICommand
    {
        Model _model;
        Shape _shape;

        public AddCommand(Model model, Shape shape)
        {
            _model = model;
            _shape = shape;
        }

        public void Execute()
        {
            _model.AddShape(_shape.ShapeName, _shape.Text, _shape.X, _shape.Y, _shape.Height, _shape.Width);
        }

        public void UnExecute()
        {
            _model.RemoveShape(_shape.ShapeId);
        }
    }
}
