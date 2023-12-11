using System.ComponentModel;

namespace Unity.Command
{
    public class DeleteCommand : ICommand
    {
        private int _index;

        public DeleteCommand(int index)
        {
            this._index = index;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void Execute(BindingList<Shape> shapes)
        {
            shapes.RemoveAt(_index);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void ExecuteNo(BindingList<Shape> shapes)
        {
        }
    }
}
