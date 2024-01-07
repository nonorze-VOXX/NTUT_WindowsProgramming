
namespace Unity
{
    partial class AddShapeForm
    {
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
            this._createButton = new System.Windows.Forms.Button();
            this._button2 = new System.Windows.Forms.Button();
            this._textBox1 = new System.Windows.Forms.TextBox();
            this._textBox2 = new System.Windows.Forms.TextBox();
            this._textBox3 = new System.Windows.Forms.TextBox();
            this._textBox4 = new System.Windows.Forms.TextBox();
            this._label1 = new System.Windows.Forms.Label();
            this._label2 = new System.Windows.Forms.Label();
            this._label3 = new System.Windows.Forms.Label();
            this._label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _createButton
            // 
            this._createButton.AccessibleName = "Create";
            this._createButton.Location = new System.Drawing.Point(143, 94);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 0;
            this._createButton.Text = "create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this.CreateShape);
            // 
            // button2
            // 
            this._button2.AccessibleName = "Cancel";
            this._button2.Location = new System.Drawing.Point(12, 94);
            this._button2.Name = "button2";
            this._button2.Size = new System.Drawing.Size(75, 23);
            this._button2.TabIndex = 1;
            this._button2.Text = "cancel";
            this._button2.UseVisualStyleBackColor = true;
            this._button2.Click += new System.EventHandler(this.CancelClick);
            // 
            // textBox1
            // 
            this._textBox1.Location = new System.Drawing.Point(12, 29);
            this._textBox1.Name = "textBox1";
            this._textBox1.Size = new System.Drawing.Size(100, 20);
            this._textBox1.TabIndex = 2;
            this._textBox1.TextChanged += new System.EventHandler(this.TopChange);
            // 
            // textBox2
            // 
            this._textBox2.Location = new System.Drawing.Point(118, 68);
            this._textBox2.Name = "textBox2";
            this._textBox2.Size = new System.Drawing.Size(100, 20);
            this._textBox2.TabIndex = 3;
            this._textBox2.TextChanged += new System.EventHandler(this.ChangeRight);
            // 
            // textBox3
            // 
            this._textBox3.Location = new System.Drawing.Point(118, 29);
            this._textBox3.Name = "textBox3";
            this._textBox3.Size = new System.Drawing.Size(100, 20);
            this._textBox3.TabIndex = 4;
            this._textBox3.TextChanged += new System.EventHandler(this.ChangeDown);
            // 
            // textBox4
            // 
            this._textBox4.Location = new System.Drawing.Point(12, 68);
            this._textBox4.Name = "textBox4";
            this._textBox4.Size = new System.Drawing.Size(100, 20);
            this._textBox4.TabIndex = 5;
            this._textBox4.TextChanged += new System.EventHandler(this.LeftChange);
            // 
            // label1
            // 
            this._label1.AutoSize = true;
            this._label1.Location = new System.Drawing.Point(13, 13);
            this._label1.Name = "label1";
            this._label1.Size = new System.Drawing.Size(22, 13);
            this._label1.TabIndex = 6;
            this._label1.Text = "top";
            // 
            // label2
            // 
            this._label2.AutoSize = true;
            this._label2.Location = new System.Drawing.Point(118, 13);
            this._label2.Name = "label2";
            this._label2.Size = new System.Drawing.Size(33, 13);
            this._label2.TabIndex = 7;
            this._label2.Text = "down";
            // 
            // label3
            // 
            this._label3.AutoSize = true;
            this._label3.Location = new System.Drawing.Point(118, 52);
            this._label3.Name = "label3";
            this._label3.Size = new System.Drawing.Size(27, 13);
            this._label3.TabIndex = 8;
            this._label3.Text = "right";
            // 
            // label4
            // 
            this._label4.AutoSize = true;
            this._label4.Location = new System.Drawing.Point(9, 52);
            this._label4.Name = "label4";
            this._label4.Size = new System.Drawing.Size(21, 13);
            this._label4.TabIndex = 9;
            this._label4.Text = "left";
            // 
            // AddShapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 142);
            this.Controls.Add(this._label4);
            this.Controls.Add(this._label3);
            this.Controls.Add(this._label2);
            this.Controls.Add(this._label1);
            this.Controls.Add(this._textBox4);
            this.Controls.Add(this._textBox3);
            this.Controls.Add(this._textBox2);
            this.Controls.Add(this._textBox1);
            this.Controls.Add(this._button2);
            this.Controls.Add(this._createButton);
            this.Name = "AddShapeForm";
            this.Text = "AddShapeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _createButton;
        private System.Windows.Forms.Button _button2;
        private System.Windows.Forms.TextBox _textBox1;
        private System.Windows.Forms.TextBox _textBox2;
        private System.Windows.Forms.TextBox _textBox3;
        private System.Windows.Forms.TextBox _textBox4;
        private System.Windows.Forms.Label _label1;
        private System.Windows.Forms.Label _label2;
        private System.Windows.Forms.Label _label3;
        private System.Windows.Forms.Label _label4;
    }
}