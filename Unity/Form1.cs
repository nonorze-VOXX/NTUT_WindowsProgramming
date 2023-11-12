using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form, IShapeObserver
    {
        PresentationModel _presentationModel;
        List<ToolStripItem> _toolStripItems;
        ToolStripButton _toolStripPointButton;

        private const string RECTANGLE_IMAGE_PATH = "rectangle.Image";
        private const string ELLIPSE_IMAGE_PATH = "ellipse.Image";
        private const string LINE_IMAGE_PATH = "line.Image";
        private const string POINTER_IMAGE_PATH = "pointer";
        private const string TOOL_STRIP_BUTTON_NAME = "toolstripButton";
        private const int TOOL_STRIP_BUTTON_HEIGHT = 22;
        private const int TOOL_STRIP_BUTTON_WIDTH = 23;
        private const int STRIP_BUTTON_NUMBER = 3;
        private Bitmap _brief;
        public Form1(PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            InitializeComponent();
            _shapeComboBox.DataSource = Enum.GetValues(typeof(ShapeType));
            _dataGridView.CellContentClick += _presentationModel.DeleteButtonClick;
            _dataGridView.DataSource = _presentationModel.GetShapeList();
            _canvas.Paint += HandleCanvasPaint;
            _canvas.MouseUp += HandleCanvasMouseUp;
            _canvas.MouseDown += HandleCanvasMouseDown;
            _canvas.MouseMove += HandleCanvasMouseMove;
            KeyPreview = true;
            KeyDown += HandleKeyDown;
            _brief = new Bitmap(_canvas.Width, _canvas.Height);
            this._createButton.Click += new System.EventHandler(_presentationModel.CreateButtonClick(_shapeComboBox));
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            List<string> imageNames = GenerateImagePathList();
            _toolStripItems = GenerateToolStripItems(resources, imageNames);

            _toolStripPointButton = GenerateButton(POINTER_IMAGE_PATH);
            _toolStripPointButton.Image = ((System.Drawing.Image)(resources.GetObject(POINTER_IMAGE_PATH)));
            _toolStripPointButton.Click += new EventHandler(_presentationModel.HandleToolStripPointButtonClick(_toolStripItems, _canvas));
            _toolStripItems.Add(_toolStripPointButton);

            _toolStrip1.Items.AddRange(_toolStripItems.ToArray());
        }

        #region Mouse
        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasMouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseUp(_canvas, new Point2(e.X, e.Y), _toolStripItems);
        }

        /// <summary>
        /// mouse move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasMouseMove(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseMove(new Point2(e.X, e.Y));
        }

        /// <summary>
        /// mouse down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasMouseDown(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseDown(new Point2(e.X, e.Y));
        }
        #endregion

        /// <summary>
        /// paint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
            GenerateBrief();
        }

        #region Generate

        /// <summary>
        /// generate
        /// </summary>
        /// <returns></returns>
        List<ToolStripItem> GenerateToolStripItems(System.ComponentModel.ComponentResourceManager resources, List<string> imageNames)
        {
            var toolStripItems = new List<ToolStripItem>();
            List<ShapeType> shapeTypes = GenerateShapeTypeList();
            for (int i = 0; i < STRIP_BUTTON_NUMBER; i++)
            {
                var toolStripButton = GenerateButton(TOOL_STRIP_BUTTON_NAME + i.ToString());
                toolStripButton.Image = ((System.Drawing.Image)(resources.GetObject(imageNames[i])));
                toolStripButton.Click += new EventHandler(_presentationModel.HandleToolStripButtonClick(toolStripItems, shapeTypes[i], _canvas));
                toolStripItems.Add(toolStripButton);
            }
            return toolStripItems;
        }

        /// <summary>
        /// shape list
        /// </summary>
        /// <returns></returns>
        List<ShapeType> GenerateShapeTypeList()
        {
            List<ShapeType> shapeTypes = new List<ShapeType>();
            shapeTypes.Add(ShapeType.Line);
            shapeTypes.Add(ShapeType.Rectangle);
            shapeTypes.Add(ShapeType.Ellipse);
            return shapeTypes;
        }

        /// <summary>
        /// image path list
        /// </summary>
        /// <returns></returns>
        List<string> GenerateImagePathList()
        {
            List<string> imageNames = new List<string>();
            imageNames.Add(LINE_IMAGE_PATH);
            imageNames.Add(RECTANGLE_IMAGE_PATH);
            imageNames.Add(ELLIPSE_IMAGE_PATH);
            return imageNames;
        }

        /// <summary>
        /// Generate Button
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ToolStripButton GenerateButton(string name)
        {
            var toolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton.Size = new System.Drawing.Size(TOOL_STRIP_BUTTON_WIDTH, TOOL_STRIP_BUTTON_HEIGHT);
            toolStripButton.Name = name;
            toolStripButton.Text = name;
            return toolStripButton;
        }
        #endregion

        #region IShapeObserver
        /// <summary>
        /// interface
        /// </summary>
        public void ReceiveBell()
        {
            Invalidate(true);
        }
        #endregion

        /// <summary>
        /// down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandleKeyDown(object sender, KeyEventArgs e)
        {
            _presentationModel.HandleKeyDown(e);
        }

        /// <summary>
        /// preview
        /// </summary>
        private void GenerateBrief()
        {
            _canvas.DrawToBitmap(_brief, new System.Drawing.Rectangle(0, 0, _canvas.Width, _canvas.Height));
            _slide1.Image = new Bitmap(_brief, _slide1.Size);
        }
    }
}