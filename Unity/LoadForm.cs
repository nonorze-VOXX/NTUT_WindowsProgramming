using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class LoadForm : Form
    {
        private PresentationModel _presentationModel;
        private Form1 _form;

        public LoadForm(Form1 form, PresentationModel presentationModel)
        {
            _form = form;
            _presentationModel = presentationModel;
            InitializeComponent();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void LoadClick(object sender, EventArgs e)
        {
            _presentationModel.Load(_form);
            Close();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
