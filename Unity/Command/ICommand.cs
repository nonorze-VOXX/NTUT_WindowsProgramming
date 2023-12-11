
using System.ComponentModel;
namespace Unity.Command
{
    interface ICommand
    {
        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        void Execute(BindingList<Shape> shapes);
        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        void ExecuteNo(BindingList<Shape> shapes);
    }
}
