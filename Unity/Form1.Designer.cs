
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.shape = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.information = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createButton = new System.Windows.Forms.Button();
            this.shapeComboBox = new System.Windows.Forms.ComboBox();
            this.topbar = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關於ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.topbar.SuspendLayout();
            this.rightGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.delete,
            this.shape,
            this.information});
            this.dataGridView.Location = new System.Drawing.Point(6, 72);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(273, 348);
            this.dataGridView.TabIndex = 0;
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
            // shape
            // 
            this.shape.HeaderText = "shape";
            this.shape.Name = "shape";
            this.shape.ReadOnly = true;
            // 
            // information
            // 
            this.information.HeaderText = "information";
            this.information.Name = "information";
            this.information.ReadOnly = true;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(204, 30);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // shapeComboBox
            // 
            this.shapeComboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.shapeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.shapeComboBox.FormattingEnabled = true;
            this.shapeComboBox.Items.AddRange(new object[] {
            "Line",
            "Rectangle"});
            this.shapeComboBox.Location = new System.Drawing.Point(6, 30);
            this.shapeComboBox.Name = "shapeComboBox";
            this.shapeComboBox.Size = new System.Drawing.Size(178, 21);
            this.shapeComboBox.TabIndex = 2;
            // 
            // topbar
            // 
            this.topbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem});
            this.topbar.Location = new System.Drawing.Point(0, 0);
            this.topbar.Name = "topbar";
            this.topbar.Size = new System.Drawing.Size(847, 24);
            this.topbar.TabIndex = 3;
            this.topbar.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關於ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 關於ToolStripMenuItem
            // 
            this.關於ToolStripMenuItem.Name = "關於ToolStripMenuItem";
            this.關於ToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.關於ToolStripMenuItem.Text = "關於";
            // 
            // rightGroupBox
            // 
            this.rightGroupBox.Controls.Add(this.dataGridView);
            this.rightGroupBox.Controls.Add(this.shapeComboBox);
            this.rightGroupBox.Controls.Add(this.createButton);
            this.rightGroupBox.Location = new System.Drawing.Point(550, 27);
            this.rightGroupBox.Name = "rightGroupBox";
            this.rightGroupBox.Size = new System.Drawing.Size(285, 426);
            this.rightGroupBox.TabIndex = 4;
            this.rightGroupBox.TabStop = false;
            this.rightGroupBox.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 503);
            this.Controls.Add(this.rightGroupBox);
            this.Controls.Add(this.topbar);
            this.MainMenuStrip = this.topbar;
            this.Name = "Form1";
            this.Text = "Caculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.topbar.ResumeLayout(false);
            this.topbar.PerformLayout();
            this.rightGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private DataGridView dataGridView;
        private Button createButton;
        private ComboBox shapeComboBox;
        private MenuStrip topbar;
        private ToolStripMenuItem 說明ToolStripMenuItem;
        private ToolStripMenuItem 關於ToolStripMenuItem;
        private GroupBox rightGroupBox;
        private DataGridViewButtonColumn delete;
        private DataGridViewTextBoxColumn shape;
        private DataGridViewTextBoxColumn information;
    }
}

