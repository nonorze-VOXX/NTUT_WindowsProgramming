using System.Collections.Generic;
using System.Drawing;

namespace Unity.Command.CMM
{
    class CommandManagerManager
    {
        private List<CommandManager> commandManagers = new List<CommandManager>();

        void AddShape(int pageIndex, ShapeType shapeType, Point start, Point end, Point nowCanvas)
        {

            commandManagers[pageIndex].AddShape(shapeType, start, end, nowCanvas);
        }
    }
}
