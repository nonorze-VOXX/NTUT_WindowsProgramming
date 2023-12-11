
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this._dataGridView = new System.Windows.Forms.DataGridView();
            this._delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this._shapeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._createButton = new System.Windows.Forms.Button();
            this._topBar = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._slide1 = new System.Windows.Forms.Button();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new Unity.Canvas();
            this._shapeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._informationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._shapeComboBox = new Unity.ShapeTypeComboBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeListBindingSource)).BeginInit();
            this._topBar.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel1.SuspendLayout();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._shapeModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridView
            // 
            this._dataGridView.AllowUserToAddRows = false;
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._dataGridView.AutoGenerateColumns = false;
            this._dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._delete,
            this._shapeDataGridViewTextBoxColumn,
            this._informationDataGridViewTextBoxColumn});
            this._dataGridView.DataSource = this._shapeListBindingSource;
            this._dataGridView.Location = new System.Drawing.Point(0, 75);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.Size = new System.Drawing.Size(485, 423);
            this._dataGridView.TabIndex = 0;
            // 
            // delete
            // 
            this._delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._delete.HeaderText = "delete";
            this._delete.Name = "delete";
            this._delete.ReadOnly = true;
            this._delete.Text = "delete";
            this._delete.UseColumnTextForButtonValue = true;
            this._delete.Width = 42;
            // 
            // shapeListBindingSource
            // 
            this._shapeListBindingSource.DataMember = "shapeList";
            this._shapeListBindingSource.DataSource = this._shapeModelBindingSource;
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(187, 18);
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
            // _slide1
            // 
            this._slide1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._slide1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this._slide1.Location = new System.Drawing.Point(3, 3);
            this._slide1.Name = "_slide1";
            this._slide1.Size = new System.Drawing.Size(191, 110);
            this._slide1.TabIndex = 5;
            this._slide1.UseVisualStyleBackColor = true;
            // 
            // _toolStrip1
            // 
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButton1,
            this._toolStripButton2,
            this._toolStripButton3,
            this._toolStripButton4,
            this._toolStripButton5,
            this._toolStripButton6});
            this._toolStrip1.Location = new System.Drawing.Point(0, 24);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1363, 25);
            this._toolStrip1.TabIndex = 8;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this._toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this._toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton1.Name = "toolStripButton1";
            this._toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton1.Text = "┃";
            this._toolStripButton1.Click += new System.EventHandler(this.ClickLine);
            // 
            // toolStripButton2
            // 
            this._toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this._toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton2.Name = "toolStripButton2";
            this._toolStripButton2.Size = new System.Drawing.Size(24, 22);
            this._toolStripButton2.Text = "⬛ ";
            this._toolStripButton2.Click += new System.EventHandler(this.ClickRectangle);
            // 
            // toolStripButton3
            // 
            this._toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this._toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton3.Name = "toolStripButton3";
            this._toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton3.Text = "⚪";
            this._toolStripButton3.Click += new System.EventHandler(this.ClickCircle);
            // 
            // toolStripButton4
            // 
            this._toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this._toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton4.Name = "toolStripButton4";
            this._toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton4.Text = "↖";
            this._toolStripButton4.Click += new System.EventHandler(this.ClickMouse);
            // 
            // toolStripButton5
            // 
            this._toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this._toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton5.Name = "toolStripButton5";
            this._toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton5.Text = "↩";
            this._toolStripButton5.Click += new System.EventHandler(this.UndoClick);
            // 
            // toolStripButton6
            // 
            this._toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this._toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton6.Name = "toolStripButton6";
            this._toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton6.Text = "↪";
            this._toolStripButton6.Click += new System.EventHandler(this.RedoClick);
            // 
            // splitContainer1
            // 
            this._splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(0, 49);
            this._splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.WindowText;
            this._splitContainer1.Panel1.Controls.Add(this._slide1);
            this._splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1363, 499);
            this._splitContainer1.SplitterDistance = 201;
            this._splitContainer1.TabIndex = 9;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveRightSplitLine);
            // 
            // splitContainer2
            // 
            this._splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this._splitContainer2.Panel1.Controls.Add(this._canvas);
            // 
            // splitContainer2.Panel2
            // 
            this._splitContainer2.Panel2.Controls.Add(this._dataGridView);
            this._splitContainer2.Panel2.Controls.Add(this._createButton);
            this._splitContainer2.Panel2.Controls.Add(this._shapeComboBox);
            this._splitContainer2.Size = new System.Drawing.Size(1158, 499);
            this._splitContainer2.SplitterDistance = 665;
            this._splitContainer2.TabIndex = 0;
            this._splitContainer2.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveRightSplitLine);
            // 
            // _canvas
            // 
            this._canvas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._canvas.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this._canvas.Location = new System.Drawing.Point(3, 3);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(655, 315);
            this._canvas.TabIndex = 7;
            // 
            // shapeDataGridViewTextBoxColumn
            // 
            this._shapeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._shapeDataGridViewTextBoxColumn.DataPropertyName = "shape";
            this._shapeDataGridViewTextBoxColumn.HeaderText = "shape";
            this._shapeDataGridViewTextBoxColumn.Name = "shapeDataGridViewTextBoxColumn";
            this._shapeDataGridViewTextBoxColumn.ReadOnly = true;
            this._shapeDataGridViewTextBoxColumn.Width = 61;
            // 
            // informationDataGridViewTextBoxColumn
            // 
            this._informationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._informationDataGridViewTextBoxColumn.DataPropertyName = "Information";
            this._informationDataGridViewTextBoxColumn.HeaderText = "Information";
            this._informationDataGridViewTextBoxColumn.Name = "informationDataGridViewTextBoxColumn";
            this._informationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // shapeModelBindingSource
            // 
            this._shapeModelBindingSource.DataSource = typeof(Unity.ShapeModel);
            // 
            // _shapeComboBox
            // 
            this._shapeComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._shapeComboBox.FormattingEnabled = true;
            this._shapeComboBox.Location = new System.Drawing.Point(3, 20);
            this._shapeComboBox.Name = "_shapeComboBox";
            this._shapeComboBox.Size = new System.Drawing.Size(178, 21);
            this._shapeComboBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 548);
            this.Controls.Add(this._splitContainer1);
            this.Controls.Add(this._toolStrip1);
            this.Controls.Add(this._topBar);
            this.MainMenuStrip = this._topBar;
            this.Name = "Form1";
            this.Text = "amogus";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeListBindingSource)).EndInit();
            this._topBar.ResumeLayout(false);
            this._topBar.PerformLayout();
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this._splitContainer1.Panel1.ResumeLayout(false);
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._shapeModelBindingSource)).EndInit();
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
        private Button _slide1;
        private ToolStrip _toolStrip1;
        private Canvas _canvas;
        private SplitContainer _splitContainer2;
        private ToolStripButton _toolStripButton1;
        private ToolStripButton _toolStripButton2;
        private ToolStripButton _toolStripButton3;
        private ToolStripButton _toolStripButton4;
        private ToolStripButton _toolStripButton5;
        private ToolStripButton _toolStripButton6;
        private BindingSource _shapeListBindingSource;
        private BindingSource _shapeModelBindingSource;
        private SplitContainer _splitContainer1;
        private DataGridViewButtonColumn _delete;
        private DataGridViewTextBoxColumn _shapeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn _informationDataGridViewTextBoxColumn;
    }
}

