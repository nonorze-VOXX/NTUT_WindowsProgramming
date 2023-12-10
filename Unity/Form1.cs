using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form, IShapeObserver
    {
        PresentationModel _presentationModel;

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

            this.Resize += ResizeWindow;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.FixedPanel = FixedPanel.Panel2;

            _presentationModel.Resize(this.ClientSize.Height, this.ClientSize.Width - this._toolStrip1.Height - this._toolStrip1.Height, this.splitContainer1, this.splitContainer2, this._dataGridView, this._rightGroupBox);
            _rightGroupBox.Location = new Point(0, 0);
        }
        internal void ResizeWindow(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int workHeight = control.ClientSize.Height - this._toolStrip1.Height - this._aboutToolStripMenuItem.Height;
            _presentationModel.Resize(workHeight, control.Width, this.splitContainer1, this.splitContainer2, this._dataGridView, this._rightGroupBox);
        }

        #region Mouse
        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasMouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseUp(_canvas, new Point2(e.X, e.Y), this._toolStrip1.Items);
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
            var graphicsAdaptor = new WindowFormsGraphicsAdaptor(e.Graphics);
            _presentationModel.Draw(graphicsAdaptor, _canvas);
            GenerateBrief();
        }

        #region Generate

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick(this._toolStrip1.Items, ShapeType.Line, _canvas);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick(this._toolStrip1.Items, ShapeType.Rectangle, _canvas);

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick
                (this._toolStrip1.Items, ShapeType.Ellipse, _canvas);

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripPointButtonClick(this._toolStrip1.Items, _canvas);
        }
    }
}