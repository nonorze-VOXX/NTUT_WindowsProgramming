using System.ComponentModel;

namespace Unity.Command
{
    public class DeleteCommand : ICommand
    {
        private int v;

        public DeleteCommand(int v)
        {
            this.v = v;
        }


        public void Excute(BindingList<Shape> shapes)
        {
            shapes.RemoveAt(v);
        }


        public void Unexcute(BindingList<Shape> shapes)
        {
        }
    }
}
