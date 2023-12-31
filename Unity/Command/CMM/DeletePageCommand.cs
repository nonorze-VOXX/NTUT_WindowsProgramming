using System.Collections.Generic;

namespace Unity.Command.CMM
{
    public class DeletePageCommand : IManagerCommand
    {
        Page storePage;
        private Form1 _form;
        private int _clickIndex;
        private int _removeIndex;
        public DeletePageCommand(Form1 form, int index, Page page)
        {
            _form = form;
            _removeIndex = index;
            storePage = page;
        }
        public void Undo(List<Page> pages)
        {
            pages.Insert(_removeIndex, storePage);
            _form.AddPage(pages.Count);
            _clickIndex = _removeIndex;
        }

        public void Redo(List<Page> pages)
        {
            pages.RemoveAt(_removeIndex);
            _form.RemovePage(_removeIndex);
            if (_removeIndex - 1 >= 0)
            {
                _clickIndex = _removeIndex - 1;
            }
            else
            {
                _clickIndex = _removeIndex;
            }

        }

        public int GetIndex()
        {
            return _clickIndex;
        }
    }
}
