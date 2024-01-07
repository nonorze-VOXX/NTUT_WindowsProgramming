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

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void SaveClick(object sender, EventArgs e)
        {
            _presentationModel.Save();
            Close();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void Button1Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
