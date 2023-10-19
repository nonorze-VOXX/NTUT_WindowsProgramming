using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ToolStripButtonFunction = System.Action<object, System.EventArgs>;
namespace Unity
{
    public partial class Form1 : Form, IShapeObserver
    {
        ShapeModel _shapeModel;
        PresentationModel _presentationModel;
        ToolStripItem[] _toolStripItems;

        public Form1(ShapeModel shapeModel, PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            _shapeModel = shapeModel;
            InitializeComponent();
            _shapeComboBox.DataSource = Enum.GetValues(typeof(ShapeType));
            _dataGridView.CellContentClick += DeleteButtonClick;
            _dataGridView.DataSource = _shapeModel.shapeList;
            _canvas.Paint += HandleCanvasPaint;
            _toolStripItems = GenerateToolStripItems();
            toolStrip1.Items.AddRange(_toolStripItems);
        }

        ToolStripItem[] GenerateToolStripItems()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            var toolStripItems = new ToolStripItem[3];
            List<string> imageNames = new List<string>
           {
            "line.Image",
            "rectangle.Image",
            "ellipse.Image"
           };
            List<ShapeType> shapeTypes = new List<ShapeType> {
                ShapeType.Line,
                ShapeType.Rectangle,
                ShapeType.Ellipse,
            };
            for (int i = 0; i < 3; i++)
            {

                var toolStripButton = new System.Windows.Forms.ToolStripButton();
                toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
                toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject(imageNames[i])));
                toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
                toolStripButton.Name = "toolStripButton" + i.ToString();
                toolStripButton.Size = new System.Drawing.Size(23, 22);
                toolStripButton.Text = "toolStripButton" + i.ToString();
                toolStripButton.Click += new EventHandler(HandleToolStripButtonClick(shapeTypes[i]));
                toolStripItems[i] = toolStripButton;

            }
            return toolStripItems;
        }


        private ToolStripButtonFunction HandleToolStripButtonClick(ShapeType shapeType)
        {
            return (object sender, EventArgs e) =>
            {
                _presentationModel.ClickDrawButton(shapeType);
            };
        }
        public void Bell()
        {
            Invalidate(true);
        }

        public void HandleCanvasPaint(object sender,
        System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        /// <summary>
        /// create shape button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButtonClick(object sender, EventArgs e)
        {
            _shapeModel.Add((ShapeType)_shapeComboBox.SelectedItem);
        }

        /// <summary>
        /// delete button click with delete model and datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _shapeModel.RemoveIndex(e.RowIndex);
            }
        }
    }
}