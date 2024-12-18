using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm
{
    public class CommandManager
    {
        Stack<ICommand> undo = new Stack<ICommand>();
        Stack<ICommand> redo = new Stack<ICommand>();

        public void Execute(ICommand command)
        {
            command.Execute();
            undo.Push(command);
            redo.Clear();
        }

        public void Undo()
        {
            var command = undo.Pop();
            command.UnExecute();
            redo.Push(command);
        }

        public void Redo()
        {
            var command = redo.Pop();
            command.Execute();
            undo.Push(command);
        }

        public bool IsRedoEnabled
        {
            get
            {
                return redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return undo.Count != 0;
            }
        }
    }
}
