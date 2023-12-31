using System.Collections.Generic;

namespace Unity.Command.CMM
{
    public class CommandManagerManager
    {
        private Stack<IManagerCommand> _undoStack = new Stack<IManagerCommand>();
        private Stack<IManagerCommand> _redoStack = new Stack<IManagerCommand>();

        public void AddRemovePagecommand(Form1 form, int index, Page page)
        {
            var deleteCommand = new DeletePageCommand(form, index, page);
            _undoStack.Push(deleteCommand);
            _redoStack.Clear();
            NotifyCommandChange();
        }

        public void AddAddPageCommand(Form1 form)
        {
            _undoStack.Push(new AddPageCommand(form));
            _redoStack.Clear();
            NotifyCommandChange();
        }

        public void AddSomeCommand(int index)
        {
            _undoStack.Push(new SomeCommand(index));
            _redoStack.Clear();
            NotifyCommandChange();
        }

        public void Undo(List<Page> pages)
        {
            if (_undoStack.Count == 0)
            {
                return;
            }

            var command = _undoStack.Pop();
            command.Undo(pages);
            switchPage.Invoke(command.GetIndex());
            _redoStack.Push(command);
            NotifyCommandChange();
        }
        public void Redo(List<Page> pages)
        {
            if (_redoStack.Count == 0)
            {
                return;
            }

            var command = _redoStack.Pop();
            command.Redo(pages);
            switchPage.Invoke(command.GetIndex());
            _undoStack.Push(command);
            NotifyCommandChange();
        }

        public bool IsUnDo()
        {
            return _undoStack.Count != 0;
        }
        public bool IsReDo()
        {
            return _redoStack.Count != 0;
        }
        public event CommandManagerManagerChange _commandChange;
        public delegate void CommandManagerManagerChange();
        public void Attach(PageModel pageModel)
        {
            _commandChange += pageModel.ReceiveCommandChanged;
        }
        void NotifyCommandChange()
        {
            if (_commandChange != null)
            {
                _commandChange.Invoke();
            }
        }
        public event SwitchPage switchPage;
        public delegate void SwitchPage(int index);
        public void Attach(Form1 form)
        {
            switchPage += form.SwitchToslide;
        }

        public void Clear()
        {
            _redoStack.Clear();
            _undoStack.Clear();
        }
    }
}
