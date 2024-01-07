using System.Collections.Generic;

namespace Unity.Command.CommandManagerManager
{
    class AddPageCommand : IManagerCommand
    {
        Page _storePage;
        private Form1 _form;
        private int _index;

        public AddPageCommand(Form1 form)
        {
            _form = form;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Undo(List<Page> pages)
        {
            _storePage = pages[pages.Count - 1];
            _form.RemovePage(pages.Count - 1);
            pages.RemoveAt(pages.Count - 1);
            _index = pages.Count - 1;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Redo(List<Page> pages)
        {
            pages.Add(_storePage);
            _form.AddPage(pages.Count);
            _index = pages.Count - 1;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public int GetIndex()
        {
            return _index;
        }
    }
}
