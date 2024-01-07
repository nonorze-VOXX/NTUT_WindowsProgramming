
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
            this._delete1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this._dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._shapeListUnitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._presentationModelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._createButton = new System.Windows.Forms.Button();
            this._topBar = new System.Windows.Forms.MenuStrip();
            this._toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this._undoButton = new System.Windows.Forms.ToolStripButton();
            this._redoButton = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton21 = new System.Windows.Forms.ToolStripButton();
            this._toolStripButton31 = new System.Windows.Forms.ToolStripButton();
            this._splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._splitContainer2 = new System.Windows.Forms.SplitContainer();
            this._canvas = new Unity.Canvas();
            this._shapeComboBox = new Unity.ShapeTypeComboBox();
            this._presentationModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._shapeModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._shapeListUnitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._presentationModelBindingSource1)).BeginInit();
            this._topBar.SuspendLayout();
            this._toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).BeginInit();
            this._splitContainer1.Panel2.SuspendLayout();
            this._splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).BeginInit();
            this._splitContainer2.Panel1.SuspendLayout();
            this._splitContainer2.Panel2.SuspendLayout();
            this._splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._presentationModelBindingSource)).BeginInit();
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
            this._delete1,
            this._dataGridViewTextBoxColumn1,
            this._dataGridViewTextBoxColumn2});
            this._dataGridView.DataSource = this._shapeListUnitBindingSource;
            this._dataGridView.Location = new System.Drawing.Point(0, 75);
            this._dataGridView.Name = "_dataGridView";
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.Size = new System.Drawing.Size(485, 423);
            this._dataGridView.TabIndex = 0;
            // 
            // delete
            // 
            this._delete1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._delete1.HeaderText = "delete";
            this._delete1.Name = "delete";
            this._delete1.ReadOnly = true;
            this._delete1.Text = "delete";
            this._delete1.UseColumnTextForButtonValue = true;
            this._delete1.Width = 42;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this._dataGridViewTextBoxColumn1.DataPropertyName = "shape";
            this._dataGridViewTextBoxColumn1.HeaderText = "shape";
            this._dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this._dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this._dataGridViewTextBoxColumn2.DataPropertyName = "Information";
            this._dataGridViewTextBoxColumn2.HeaderText = "Information";
            this._dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this._dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // shapeListUnitBindingSource
            // 
            this._shapeListUnitBindingSource.DataMember = "shapeListUnit";
            this._shapeListUnitBindingSource.DataSource = this._presentationModelBindingSource1;
            // 
            // presentationModelBindingSource1
            // 
            this._presentationModelBindingSource1.DataSource = typeof(Unity.PresentationModel);
            // 
            // _createButton
            // 
            this._createButton.Location = new System.Drawing.Point(187, 18);
            this._createButton.Name = "_createButton";
            this._createButton.Size = new System.Drawing.Size(75, 23);
            this._createButton.TabIndex = 1;
            this._createButton.Text = "create";
            this._createButton.UseVisualStyleBackColor = true;
            this._createButton.Click += new System.EventHandler(this.CreateButtonClick);
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
            // _toolStrip1
            // 
            this._toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripButton1,
            this._toolStripButton2,
            this._toolStripButton3,
            this._toolStripButton4,
            this._undoButton,
            this._redoButton,
            this._toolStripButton11,
            this._toolStripButton21,
            this._toolStripButton31});
            this._toolStrip1.Location = new System.Drawing.Point(0, 24);
            this._toolStrip1.Name = "_toolStrip1";
            this._toolStrip1.Size = new System.Drawing.Size(1363, 25);
            this._toolStrip1.TabIndex = 8;
            this._toolStrip1.Text = "toolStrip1";
            // 
            // _toolStripButton1
            // 
            this._toolStripButton1.AccessibleName = "Line";
            this._toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton1.Image")));
            this._toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton1.Name = "_toolStripButton1";
            this._toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton1.Text = "┃";
            this._toolStripButton1.Click += new System.EventHandler(this.ClickLine);
            // 
            // _toolStripButton2
            // 
            this._toolStripButton2.AccessibleName = "Rectangle";
            this._toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton2.Image")));
            this._toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton2.Name = "_toolStripButton2";
            this._toolStripButton2.Size = new System.Drawing.Size(24, 22);
            this._toolStripButton2.Text = "⬛ ";
            this._toolStripButton2.Click += new System.EventHandler(this.ClickRectangle);
            // 
            // _toolStripButton3
            // 
            this._toolStripButton3.AccessibleName = "Ellipse";
            this._toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton3.Image")));
            this._toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton3.Name = "_toolStripButton3";
            this._toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton3.Text = "⚪";
            this._toolStripButton3.Click += new System.EventHandler(this.ClickCircle);
            // 
            // _toolStripButton4
            // 
            this._toolStripButton4.AccessibleName = "Point";
            this._toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("_toolStripButton4.Image")));
            this._toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton4.Name = "_toolStripButton4";
            this._toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton4.Text = "↖";
            this._toolStripButton4.Click += new System.EventHandler(this.ClickMouse);
            // 
            // _undoButton
            // 
            this._undoButton.AccessibleName = "Undo";
            this._undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._undoButton.Image = ((System.Drawing.Image)(resources.GetObject("_undoButton.Image")));
            this._undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._undoButton.Name = "_undoButton";
            this._undoButton.Size = new System.Drawing.Size(23, 22);
            this._undoButton.Text = "↩";
            this._undoButton.Click += new System.EventHandler(this.UndoClick);
            // 
            // _redoButton
            // 
            this._redoButton.AccessibleName = "Redo";
            this._redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._redoButton.Image = ((System.Drawing.Image)(resources.GetObject("_redoButton.Image")));
            this._redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._redoButton.Name = "_redoButton";
            this._redoButton.Size = new System.Drawing.Size(23, 22);
            this._redoButton.Text = "↪";
            this._redoButton.Click += new System.EventHandler(this.RedoClick);
            // 
            // toolStripButton1
            // 
            this._toolStripButton11.AccessibleName = "AddPageEventHandler";
            this._toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this._toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton11.Name = "toolStripButton1";
            this._toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton11.Text = "📝";
            this._toolStripButton11.Click += new System.EventHandler(this.AddPageButtonClick);
            // 
            // toolStripButton2
            // 
            this._toolStripButton21.AccessibleName = "Save";
            this._toolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton21.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this._toolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton21.Name = "toolStripButton2";
            this._toolStripButton21.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton21.Text = "💾";
            this._toolStripButton21.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // toolStripButton3
            // 
            this._toolStripButton31.AccessibleName = "Load";
            this._toolStripButton31.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._toolStripButton31.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this._toolStripButton31.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._toolStripButton31.Name = "toolStripButton3";
            this._toolStripButton31.Size = new System.Drawing.Size(23, 22);
            this._toolStripButton31.Text = "⬇️";
            this._toolStripButton31.Click += new System.EventHandler(this.LoadButtonClick);
            // 
            // _splitContainer1
            // 
            this._splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this._splitContainer1.Location = new System.Drawing.Point(0, 49);
            this._splitContainer1.Name = "_splitContainer1";
            // 
            // _splitContainer1.Panel1
            // 
            this._splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Info;
            this._splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // _splitContainer1.Panel2
            // 
            this._splitContainer1.Panel2.Controls.Add(this._splitContainer2);
            this._splitContainer1.Size = new System.Drawing.Size(1363, 499);
            this._splitContainer1.SplitterDistance = 201;
            this._splitContainer1.TabIndex = 9;
            this._splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.MoveRightSplitLine);
            // 
            // _splitContainer2
            // 
            this._splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this._splitContainer2.BackColor = System.Drawing.SystemColors.WindowFrame;
            this._splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this._splitContainer2.Location = new System.Drawing.Point(0, 0);
            this._splitContainer2.Name = "_splitContainer2";
            // 
            // _splitContainer2.Panel1
            // 
            this._splitContainer2.Panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this._splitContainer2.Panel1.Controls.Add(this._canvas);
            // 
            // _splitContainer2.Panel2
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
            this._canvas.BackColor = System.Drawing.Color.White;
            this._canvas.Location = new System.Drawing.Point(3, 3);
            this._canvas.Name = "_canvas";
            this._canvas.Size = new System.Drawing.Size(655, 315);
            this._canvas.TabIndex = 7;
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
            // presentationModelBindingSource
            // 
            this._presentationModelBindingSource.DataSource = typeof(Unity.PresentationModel);
            // 
            // shapeModelBindingSource
            // 
            this._shapeModelBindingSource.DataSource = typeof(Unity.Page);
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
            ((System.ComponentModel.ISupportInitialize)(this._shapeListUnitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._presentationModelBindingSource1)).EndInit();
            this._topBar.ResumeLayout(false);
            this._topBar.PerformLayout();
            this._toolStrip1.ResumeLayout(false);
            this._toolStrip1.PerformLayout();
            this._splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer1)).EndInit();
            this._splitContainer1.ResumeLayout(false);
            this._splitContainer2.Panel1.ResumeLayout(false);
            this._splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._splitContainer2)).EndInit();
            this._splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._presentationModelBindingSource)).EndInit();
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
        private ToolStrip _toolStrip1;
        private Canvas _canvas;
        private SplitContainer _splitContainer2;
        private ToolStripButton _toolStripButton1;
        private ToolStripButton _toolStripButton2;
        private ToolStripButton _toolStripButton3;
        private ToolStripButton _toolStripButton4;
        private ToolStripButton _undoButton;
        private ToolStripButton _redoButton;
        private SplitContainer _splitContainer1;
        private ToolStripButton _toolStripButton11;
        private DataGridViewButtonColumn _delete1;
        private BindingSource _shapeModelBindingSource;
        private BindingSource _presentationModelBindingSource;
        private BindingSource _presentationModelBindingSource1;
        private DataGridViewTextBoxColumn _dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn _dataGridViewTextBoxColumn2;
        private BindingSource _shapeListUnitBindingSource;
        private ToolStripButton _toolStripButton21;
        private ToolStripButton _toolStripButton31;
    }
}

