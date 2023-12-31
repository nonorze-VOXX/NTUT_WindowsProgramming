using System.Collections.Generic;

namespace Unity.Command.CMM
{
    class SomeCommand : IManagerCommand
    {
        private int _index;
        public SomeCommand(int index)
        {
            _index = index;
        }
        public void Undo(List<Page> pages)
        {
            pages[_index].Undo();
        }
        public void Redo(List<Page> pages)
        {
            pages[_index].Redo();
        }

        public int GetIndex()
        {
            return _index;
        }
    }
}
