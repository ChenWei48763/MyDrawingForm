﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class AddCommand : ICommand
    {
        Model model;
        Shape shape;

        public AddCommand(Model m, Shape s)
        {
            model = m;
            shape = s;
        }

        public void Execute()
        {
            model.AddShape(shape);
        }

        public void UnExecute()
        {
            model.RemoveShape(shape);
        }
    }
}
