
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Unity
{

    class ButtonFunction
    {
        public CalculatorModel _calculatorModel { set; get; }
        public string _context { get; set; }
        public Form1 form1 { get; set; }
        public void OnNumberClick(object sender, EventArgs e)
        {
            this._calculatorModel.InputNumber(_context);
            if (_calculatorModel._context.Equals("delay"))
            {
                throw new Exception();
            }
            form1.textBox1.Text = form1._calculatorModel ._context;
        }
    }

    public class CalculatorModel
    {
        public  string _context { get; set; }

        public void InputNumber(string input)
        {
            if (input.Length==1)
            {
                _context += input;
            }
        }
        
    }
    partial class Form1
    {
        public CalculatorModel _calculatorModel = new CalculatorModel();
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _buttons = new List<Button>();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttons 1-9
            // 
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var buttonFunction = new ButtonFunction();
                    buttonFunction._calculatorModel = _calculatorModel;
                    buttonFunction.form1 = this;
                    string numberString = (i*3+j+1).ToString();
                    buttonFunction._context = numberString;
                    
                    var button = new Button();
                    button.Location = new System.Drawing.Point(58+j*35, 93+35*3-i*35);
                    button.Name = "button"+numberString;
                    button.Size = new System.Drawing.Size(30, 30);
                    button.TabIndex = 0;
                    button.Text = numberString;
                    button.UseVisualStyleBackColor = true;
                    button.Click += new System.EventHandler(buttonFunction.OnNumberClick);
                    this.Controls.Add(button);
                }
            }
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(33, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = false;
            this.textBox1.Size = new System.Drawing.Size(337, 20);
            this.textBox1.TabIndex = 1;
            _calculatorModel._context = "delay";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            
            this.Name = "Form1";
            this.Text = "Caculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private List<Button> _buttons;
        public System.Windows.Forms.TextBox textBox1;
    }
}

