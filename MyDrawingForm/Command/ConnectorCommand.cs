using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class ConnectorCommand : ICommand
    {
        Model _m;
        Line _line;

        public ConnectorCommand(Model m, Line line)
        {
            _m = m;
            _line = line;
        }

        public void Execute()
        {
            _m.AddLine(_line);
        }

        public void UnExecute()
        {
            _m.RemoveLine(_line);
        }
    }
}