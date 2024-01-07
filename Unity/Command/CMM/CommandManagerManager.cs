using System.Collections.Generic;

namespace Unity.Command.CommandManagerManager
{
    public class CommandManagerManager
    {
        public event CommandManagerManagerChangeEventHanlder _commandChange;
        public delegate void CommandManagerManagerChangeEventHanlder();
        private Stack<IManagerCommand> _undoStack = new Stack<IManagerCommand>();
        private Stack<IManagerCommand> _redoStack = new Stack<IManagerCommand>();

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddRemovePagecommand(Form1 form, int index, Page page)
        {
            var deleteCommand = new DeletePageCommand(form, index, page);
            _undoStack.Push(deleteCommand);
            _redoStack.Clear();
            NotifyCommandChange();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddAddPageCommand(Form1 form)
        {
            _undoStack.Push(new AddPageCommand(form));
            _redoStack.Clear();
            NotifyCommandChange();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddSomeCommand(int index)
        {
            _undoStack.Push(new SomeCommand(index));
            _redoStack.Clear();
            NotifyCommandChange();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public bool IsUnDo()
        {
            return _undoStack.Count != 0;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public bool IsReDo()
        {
            return _redoStack.Count != 0;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Attach(PageModel pageModel)
        {
            _commandChange += pageModel.ReceiveCommandChanged;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        void NotifyCommandChange()
        {
            if (_commandChange != null)
            {
                _commandChange.Invoke();
            }
        }
        public event SwitchPage switchPage;
        public delegate void SwitchPage(int index);

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Attach(Form1 form)
        {
            switchPage += form.SwitchToslide;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Clear()
        {
            _redoStack.Clear();
            _undoStack.Clear();
        }
    }
}
