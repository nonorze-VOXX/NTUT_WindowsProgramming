using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.textBox1.DataBindings.Add("Text", _calculatorModel, "_context", true, DataSourceUpdateMode.OnPropertyChanged);
        }


        private void NumberClick(object sender, EventArgs e)
        {
        }
    }
}