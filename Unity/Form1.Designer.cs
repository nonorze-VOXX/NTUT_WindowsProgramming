
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
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._createButton = new System.Windows.Forms.Button();
            this._topBar = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._rightGroupBox = new System.Windows.Forms.GroupBox();
            this._shapeComboBox = new Unity.ShapeTypeComboBox();
            this._slide1 = new System.Windows.Forms.Button();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new Unity.Canvas();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            this._topBar.SuspendLayout();
            this._rightGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete});
            this._dataGridView.Location = new System.Drawing.Point(6, 72);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.Size = new System.Drawing.Size(340, 348);
            this._dataGridView.TabIndex = 0;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.delete.HeaderText = "delete";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "delete";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 79;
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(204, 30);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 1;
            this._createButton.Text = "create";
            this._createButton.UseVisualStyleBackColor = true;
            // 
            // _topBar
            // 
            this._topBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItem});
            this._topBar.Location = new System.Drawing.Point(0, 0);
            this._topBar.Name = "_topBar";
            this._topBar.Size = new System.Drawing.Size(1363, 24);
            this._topBar.TabIndex = 3;
            this._topBar.Text = "menuStrip1";
            // 
            // _toolStripMenuItem
            // 
            this._toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._aboutToolStripMenuItem});
            this._toolStripMenuItem.Name = "_toolStripMenuItem";
            this._toolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this._toolStripMenuItem.Text = "說明";
            // 
            // _aboutToolStripMenuItem
            // 
            this._aboutToolStripMenuItem.Name = "_aboutToolStripMenuItem";
            this._aboutToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this._aboutToolStripMenuItem.Text = "關於";
            // 
            // _rightGroupBox
            // 
            this._rightGroupBox.Controls.Add(this._dataGridView);
            this._rightGroupBox.Controls.Add(this._shapeComboBox);
            this._rightGroupBox.Controls.Add(this._createButton);
            this._rightGroupBox.Location = new System.Drawing.Point(3, 3);
            this._rightGroupBox.Name = "_rightGroupBox";
            this._rightGroupBox.Size = new System.Drawing.Size(378, 481);
            this._rightGroupBox.TabIndex = 4;
            this._rightGroupBox.TabStop = false;
            this._rightGroupBox.Text = "groupBox1";
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Location = new System.Drawing.Point(6, 30);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(178, 21);
            this._shapeComboBox.TabIndex = 2;
            // 
            // _slide1
            // 
            this._slide1.Location = new System.Drawing.Point(3, 20);
            this._slide1.Name = "_slide1";
            this._slide1.Size = new System.Drawing.Size(150, 110);
            this._slide1.TabIndex = 5;
            this._slide1.UseVisualStyleBackColor = true;
            // 
            // _toolStrip1
            // 
            this._toolStrip1.Location = new System.Drawing.Point(0, 24);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1363, 25);
            this._toolStrip1.TabIndex = 8;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 52);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this.splitContainer1.Panel1.Controls.Add(this._slide1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1363, 484);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.splitContainer2.Panel1.Controls.Add(this._canvas);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._rightGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(1158, 484);
            this.splitContainer2.SplitterDistance = 665;
            this.splitContainer2.TabIndex = 0;
            // 
            // _canvas
            // 
            this._canvas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._canvas.Location = new System.Drawing.Point(20, 20);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(445, 333);
            this._canvas.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._topBar);
            this.MainMenuStrip = this._topBar;
            this.Name = "Form1";
            this.Text = "amogus";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            this._topBar.ResumeLayout(false);
            this._topBar.PerformLayout();
            this._rightGroupBox.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DataGridView _dataGridView;
        private Button _createButton;
        private ShapeTypeComboBox _shapeComboBox;
        private MenuStrip _topBar;
        private ToolStripMenuItem _toolStripMenuItem;
        private ToolStripMenuItem _aboutToolStripMenuItem;
        private GroupBox _rightGroupBox;
        private Button _slide1;
        private DataGridViewButtonColumn _delete;
        private ToolStrip _toolStrip1;
        private Canvas _canvas;
        private DataGridViewButtonColumn delete;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
    }
}

