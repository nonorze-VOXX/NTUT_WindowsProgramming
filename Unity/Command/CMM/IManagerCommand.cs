using System.Collections.Generic;

namespace Unity.Command.CMM
{
    interface IManagerCommand
    {
        void Undo(List<Page> pages);
        void Redo(List<Page> pages);
    }
}
