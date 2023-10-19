using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form, IShapeObserver
    {
        PresentationModel _presentationModel;
        List<ToolStripItem> _toolStripItems;

        public Form1(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            _shapeComboBox.DataSource = Enum.GetValues(typeof(ShapeType));
            _dataGridView.CellContentClick += _presentationModel.DeleteButtonClick;
            _dataGridView.DataSource = _presentationModel.GetShapeList();
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseUp += HandleCanvasMouseUp;
            _canvas.MouseDown += _presentationModel.HandleCanvasMouseDown;
            _canvas.MouseMove += _presentationModel.HandleCanvasMouseMove;
            this._createButton.Click += new System.EventHandler(_presentationModel.CreateButtonClick(_shapeComboBox));
            _toolStripItems = GenerateToolStripItems();
            toolStrip1.Items.AddRange(_toolStripItems.ToArray());
        }

        private void HandleCanvasMouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseUp(_canvas, new Point2(e.X, e.Y), _toolStripItems);
        }

        List<ToolStripItem> GenerateToolStripItems()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            var toolStripItems = new List<ToolStripItem>();
            List<string> imageNames = new List<string>
            {
                "line.Image", "rectangle.Image", "ellipse.Image"
            };
            List<ShapeType> shapeTypes = new List<ShapeType>
            {
                ShapeType.Line, ShapeType.Rectangle, ShapeType.Ellipse,
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
                toolStripButton.Click += new EventHandler(_presentationModel.HandleToolStripButtonClick(toolStripItems, shapeTypes[i], _canvas));
                toolStripItems.Add(toolStripButton);

            }
            return toolStripItems;
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
    }
}