
using System.Collections.Generic;
using System.ComponentModel;
namespace Unity.Command
{
    interface ICommand
    {
        /// <summary>
        /// a
        /// </summary>
        /// <param name="pages"></param>
        void Execute(List<BindingList<Shape>> pages);
        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        void ExecuteNo(BindingList<Shape> shapes);
    }
}
