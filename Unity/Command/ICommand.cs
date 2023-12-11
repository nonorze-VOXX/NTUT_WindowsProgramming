
using System.ComponentModel;
namespace Unity.Command
{
    interface ICommand
    {
        void Excute(BindingList<Shape> shapes);
        void Unexcute(BindingList<Shape> shapes);
        string to_string();
    }
}
