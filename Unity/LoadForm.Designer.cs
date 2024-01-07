
namespace Unity
{
    partial class LoadForm
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
            this._button1 = new System.Windows.Forms.Button();
            this._button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _button1
            // 
            this._button1.AccessibleName = "Cancel";
            this._button1.Location = new System.Drawing.Point(34, 94);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(75, 23);
            this._button1.TabIndex = 0;
            this._button1.Text = "Cancel";
            this._button1.UseVisualStyleBackColor = true;
            this._button1.Click += new System.EventHandler(this.CancelClick);
            // 
            // _button2
            // 
            this._button2.AccessibleName = "Load";
            this._button2.Location = new System.Drawing.Point(115, 94);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(75, 23);
            this._button2.TabIndex = 1;
            this._button2.Text = "Load";
            this._button2.UseVisualStyleBackColor = true;
            this._button2.Click += new System.EventHandler(this.LoadClick);
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 132);
            this.Controls.Add(this._button2);
            this.Controls.Add(this._button1);
            this.Name = "LoadForm";
            this.Text = "LoadForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _button1;
        private System.Windows.Forms.Button _button2;
    }
}