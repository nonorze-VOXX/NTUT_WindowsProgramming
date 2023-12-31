using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class SaveForm : Form
    {
        private PresentationModel _presentationModel;
        public SaveForm(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
        }

        private void SaveClick(object sender, EventArgs e)
        {
            _presentationModel.Save();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
