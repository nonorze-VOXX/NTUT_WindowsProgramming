using System.Windows.Forms;

namespace Unity
{
    public class ShapeTypeComboBox : ComboBox
    {
        /// <summary>
        /// scale
        /// </summary>
        /// <returns></returns>
        public virtual object GetSelectedItem()
        {
            return SelectedItem;
        }
    }
}
