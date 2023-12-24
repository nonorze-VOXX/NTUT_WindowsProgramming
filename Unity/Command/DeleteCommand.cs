using System.Collections.Generic;
using System.ComponentModel;

namespace Unity.Command
{
    public class DeleteCommand : ICommand
    {
        private int _index;
        private int nowPage;

        public DeleteCommand(int index, int nowPage)
        {
            this._index = index;
            this.nowPage = nowPage;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="pages"></param>
        public void Execute(List<BindingList<Shape>> pages)
        {
            pages[nowPage].RemoveAt(_index);
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
