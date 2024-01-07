using System.Collections.Generic;

namespace Unity.Command.CommandManagerManager
{
    class SomeCommand : IManagerCommand
    {
        private int _index;
        public SomeCommand(int index)
        {
            _index = index;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Undo(List<Page> pages)
        {
            pages[_index].Undo();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Redo(List<Page> pages)
        {
            pages[_index].Redo();
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
