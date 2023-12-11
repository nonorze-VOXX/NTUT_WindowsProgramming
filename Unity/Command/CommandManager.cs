using System.Collections.Generic;

namespace Unity.Command
{
    class CommandManager
    {
        Stack<ICommand> undoStack = new Stack<ICommand>();
        Stack<ICommand> redoStack = new Stack<ICommand>();

    }
}
