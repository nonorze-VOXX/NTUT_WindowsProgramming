using System.Collections.Generic;

namespace Unity.Command.CMM
{
    class AddPageCommand : IManagerCommand
    {
        Page storePage;
        private Form1 _form;

        public AddPageCommand(Form1 form)
        {
            _form = form;
        }

        public void Undo(List<Page> pages)
        {
            storePage = pages[pages.Count - 1];
            _form.RemovePage(pages.Count - 1);
            pages.RemoveAt(pages.Count - 1);
        }

        public void Redo(List<Page> pages)
        {
            pages.Add(storePage);
            _form.AddPage(pages.Count);
        }
    }
}
