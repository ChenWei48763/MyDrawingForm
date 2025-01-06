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

        public void Execute(ICommand cmd)
        {
            cmd.Execute();
            undo.Push(cmd);
            redo.Clear();
            Console.WriteLine("Command executed and added to undo stack.");
        }

        public void Undo()
        {
            if (undo.Count <= 0)
                throw new Exception("Cannot Undo exception\n");
            ICommand cmd = undo.Pop();
            redo.Push(cmd);
            cmd.UnExecute();
            Console.WriteLine("Command undone and added to redo stack.");
        }

        public void Redo()
        {
            if (redo.Count <= 0)
                throw new Exception("Cannot Redo exception\n");
            ICommand cmd = redo.Pop();
            undo.Push(cmd);
            cmd.Execute();
            Console.WriteLine("Command redone and added to undo stack.");
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
