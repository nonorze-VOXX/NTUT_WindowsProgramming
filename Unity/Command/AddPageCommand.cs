using System.Collections.Generic;
using System.ComponentModel;

namespace Unity.Command
{
    class AddPageCommand : ICommand
    {
        public void Execute(List<BindingList<Shape>> pages)
        {
            pages.Add(new BindingList<Shape>());
        }

        public void ExecuteNo(BindingList<Shape> shapes)
        {
        }
    }
}
