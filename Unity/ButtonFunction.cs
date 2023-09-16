using System;

namespace Unity
{
    internal class ButtonFunction
    {
        public CalculatorModel _calculatorModel 
        {
            set; get; 
        }
        public string _context 
        { 
            get; set; 
        }
        public Form1 form1 
        { 
            get; set; 
        }

        /// <summary>
        /// function on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClickNumber(object sender, EventArgs e)
        {
            _calculatorModel.InputNumber(_context);
            form1.GetTextBox1().Text = form1.GetCalculatorModel()._context;
        }
    }
}