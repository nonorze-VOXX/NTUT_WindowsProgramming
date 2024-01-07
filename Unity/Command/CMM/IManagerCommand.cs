using System.Collections.Generic;

namespace Unity.Command.CommandManagerManager
{
    interface IManagerCommand
    {
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        void Undo(List<Page> pages);
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        void Redo(List<Page> pages);
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        int GetIndex();
    }
}
