using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            _calculatorModel = new CalculatorModel();
            InitializeComponent();
            CreateButtons();
        }

        public Form1(CalculatorModel calculatorModel)
        {
            _calculatorModel = calculatorModel;
            InitializeComponent();
            CreateButtons();
        }
    }
}