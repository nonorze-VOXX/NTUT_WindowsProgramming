using System.Collections.Generic;

namespace Unity.Command.CMM
{
    public class CommandManagerManager
    {
        private Stack<IManagerCommand> _undoStack = new Stack<IManagerCommand>();
        private Stack<IManagerCommand> _redoStack = new Stack<IManagerCommand>();

        public void AddSomeCommand(int index)
        {
            _undoStack.Push(new SomeCommand(index));
            _redoStack.Clear();
        }

        public void Undo(List<Page> pages)
        {
            if (_undoStack.Count == 0)
            {
                return;
            }

            var command = _undoStack.Pop();
            command.Undo(pages);
            _redoStack.Push(command);
        }
        public void Redo(List<Page> pages)
        {
            if (_redoStack.Count == 0)
            {
                return;
            }

            var command = _redoStack.Pop();
            command.Redo(pages);
            _undoStack.Push(command);
        }

        public bool IsUnDo()
        {
            return _undoStack.Count != 0;
        }
        public bool IsReDo()
        {
            return _redoStack.Count != 0;
        }
    }
}
