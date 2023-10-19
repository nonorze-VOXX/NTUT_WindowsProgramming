using System.Windows.Forms;

namespace Unity
{
    public class Canvas : Panel
    {

        public Canvas()
        {
            DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
    }
}
