using System.Collections.Generic;
using System.ComponentModel;

namespace Unity
{
    public interface IShapeObserver
    {
        /// <summary>
        /// notify
        /// </summary>
        /// <param name="pages"></param>
        void ReceiveBell(List<BindingList<Shape>> pages);
    }
}
