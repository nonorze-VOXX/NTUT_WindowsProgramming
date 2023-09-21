
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Unity
{
    partial class Form1
    {
        private CalculatorModel _calculatorModel = new CalculatorModel();
        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public CalculatorModel GetCalculatorModel()
        {
            return _calculatorModel;
        }
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
            this._textBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // richTextBox1
            // 
            this._textBox1.Location = new System.Drawing.Point(33, 28);
            this._textBox1.Name = "textBox1";
            this._textBox1.ReadOnly = true;
            this._textBox1.Size = new System.Drawing.Size(240, 40);
            this._textBox1.TabIndex = 1;
            this._textBox1.Text = "";
            this._textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19F);

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this._textBox1);
            
            this.Name = "Form1";
            this.Text = "Caculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// create
        /// </summary>
        private void CreateButtons()
        {
            List<List<string>> lists = new List<List<string>>();
            lists.Add(new List<string> { "0", ".", "=", "/", });
            lists.Add(new List<string> { "1", "2", "3", "*", } );
            lists.Add(new List<string> { "4", "5", "6", "-", } );
            lists.Add(new List<string> { "7", "8", "9", "+", } );
            lists.Add(new List<string> { "", "", "CE", "C", });
            for (var y = 0; y < lists.Count; y++)
            {
                var list = lists[y];
                for (var x = 0; x < list.Count; x++)
                {
                    var o = list[x];
                    if (o.Equals(""))
                    {
                        continue;
                    }

                    var button = new Button();
                    button.Location = new System.Drawing.Point(25 + x * 60, 250 + 35 * 3 - y * 70);
                    button.Name = "button" + o;
                    button.Size = new System.Drawing.Size(60, 70);
                    button.TabIndex = 0;
                    button.Text = o;
                    button.UseVisualStyleBackColor = true;
                    button.Click += new System.EventHandler(
                        (object sender, EventArgs e) =>
                        {
                            _calculatorModel.Input(o);
                            GetTextBox1().Text = GetCalculatorModel().GetOutput();
                            // GetTextBox1().Text = GetCalculatorModel()._result + " "
                            //                                                   + GetCalculatorModel()._processingNumber +
                            //                                                   " "
                            //                                                   + GetCalculatorModel()._operator;
                        });
                    this.Controls.Add(button);
                }
            }
        }
        
        #endregion

        /// <summary>
        /// getTextBox1
        /// </summary>
        /// <returns></returns>
        public System.Windows.Forms.RichTextBox GetTextBox1()
        {
            return _textBox1;
        }
        private List<Button> _buttons;
        private System.Windows.Forms.RichTextBox _textBox1;
    }
}

