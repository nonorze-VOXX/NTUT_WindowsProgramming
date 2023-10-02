
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Unity
{
    partial class Form1
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
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._createButton = new System.Windows.Forms.Button();
            this._shapeComboBox = new System.Windows.Forms.ComboBox();
            this._topBar = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rightGroupBox = new System.Windows.Forms.GroupBox();
            this._slide1 = new System.Windows.Forms.Button();
            this._slide2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._topBar.SuspendLayout();
            this._rightGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete,
            this._shape,
            this._information});
            this._dataGridView.Location = new System.Drawing.Point(6, 72);
            this._dataGridView.Name = "dataGridView";
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.ReadOnly = true;
            this._dataGridView.Size = new System.Drawing.Size(273, 348);
            this._dataGridView.TabIndex = 0;
            // 
            // delete
            // 
            this._delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this._delete.HeaderText = "delete";
            this._delete.Name = "delete";
            this._delete.ReadOnly = true;
            this._delete.Text = "delete";
            this._delete.UseColumnTextForButtonValue = true;
            this._delete.Width = 79;
            // 
            // shape
            // 
            this._shape.HeaderText = "shape";
            this._shape.Name = "shape";
            this._shape.ReadOnly = true;
            // 
            // information
            // 
            this._information.HeaderText = "information";
            this._information.Name = "information";
            this._information.ReadOnly = true;
            // 
            // createButton
            // 
            this._createButton.Location = new System.Drawing.Point(204, 30);
            this._createButton.Name = "createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 1;
            this._createButton.Text = "create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this.CreateButtonClick);
            // 
            // shapeComboBox
            // 
            this._shapeComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Items.AddRange(new object[] {
            "Line",
            "Rectangle"});
            this._shapeComboBox.Location = new System.Drawing.Point(6, 30);
            this._shapeComboBox.Name = "shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(178, 21);
            this._shapeComboBox.TabIndex = 2;
            // 
            // topbar
            // 
            this._topBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem});
            this._topBar.Location = new System.Drawing.Point(0, 0);
            this._topBar.Name = "topbar";
            this._topBar.Size = new System.Drawing.Size(847, 24);
            this._topBar.TabIndex = 3;
            this._topBar.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this._toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._toolStripMenuItem.Name = "說明ToolStripMenuItem";
            this._toolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this._toolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // rightGroupBox
            // 
            this._rightGroupBox.Controls.Add(this._dataGridView);
            this._rightGroupBox.Controls.Add(this._shapeComboBox);
            this._rightGroupBox.Controls.Add(this._createButton);
            this._rightGroupBox.Location = new System.Drawing.Point(550, 27);
            this._rightGroupBox.Name = "rightGroupBox";
            this._rightGroupBox.Size = new System.Drawing.Size(285, 426);
            this._rightGroupBox.TabIndex = 4;
            this._rightGroupBox.TabStop = false;
            this._rightGroupBox.Text = "groupBox1";
            // 
            // slide1
            // 
            this._slide1.Location = new System.Drawing.Point(26, 67);
            this._slide1.Name = "slide1";
            this._slide1.Size = new System.Drawing.Size(75, 23);
            this._slide1.TabIndex = 5;
            this._slide1.Text = "Slide1";
            this._slide1.UseVisualStyleBackColor = true;
            // 
            // slide2
            // 
            this._slide2.Location = new System.Drawing.Point(26, 118);
            this._slide2.Name = "slide2";
            this._slide2.Size = new System.Drawing.Size(75, 23);
            this._slide2.TabIndex = 6;
            this._slide2.Text = "slide2";
            this._slide2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 503);
            this.Controls.Add(this._slide2);
            this.Controls.Add(this._slide1);
            this.Controls.Add(this._rightGroupBox);
            this.Controls.Add(this._topBar);
            this.MainMenuStrip = this._topBar;
            this.Name = "Form1";
            this.Text = "Caculator";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._topBar.ResumeLayout(false);
            this._topBar.PerformLayout();
            this._rightGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DataGridView _dataGridView;
        private Button _createButton;
        private ComboBox _shapeComboBox;
        private MenuStrip _topBar;
        private ToolStripMenuItem _toolStripMenuItem;
        private ToolStripMenuItem _aboutToolStripMenuItem;
        private GroupBox _rightGroupBox;
        private DataGridViewButtonColumn _delete;
        private DataGridViewTextBoxColumn _shape;
        private DataGridViewTextBoxColumn _information;
        private Button _slide1;
        private Button _slide2;
    }
}

