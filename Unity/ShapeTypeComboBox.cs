using System.Windows.Forms;

namespace Unity
{
    public class ShapeTypeComboBox : ComboBox
    {
        public virtual object GetSelectedItem()
        {
            return SelectedItem;
        }
    }
}
