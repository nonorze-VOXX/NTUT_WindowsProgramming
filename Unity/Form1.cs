using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form, IShapeObserver
    {
        PresentationModel _presentationModel;

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

            toolStripButton4_Click(null, null);
            this.Resize += ResizeWindow;
            ResizeWindow(null, null);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ResizeWindow(object sender, EventArgs e)
        {
            _presentationModel.Resize(_canvas, _slide1);
            if (_canvas.Width != 0 && _canvas.Height != 0)
            {
                _brief = new Bitmap(_canvas.Width, _canvas.Height);
            }
        }

        #region Mouse
        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleCanvasMouseUp(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseUp(_canvas, new Point(e.X, e.Y), this._toolStrip1.Items);
        }

        /// <summary>
        /// mouse move
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasMouseMove(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseMove(new Point(e.X, e.Y));
        }

        /// <summary>
        /// mouse down
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleCanvasMouseDown(object sender, MouseEventArgs e)
        {
            _presentationModel.HandleCanvasMouseDown(new Point(e.X, e.Y));
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
            ResizeWindow(null, null);
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

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick(this._toolStrip1.Items, ShapeType.Line, _canvas);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick(this._toolStrip1.Items, ShapeType.Rectangle, _canvas);

        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick
                (this._toolStrip1.Items, ShapeType.Ellipse, _canvas);

        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripPointButtonClick(this._toolStrip1.Items, _canvas);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ResizeWindow(null, null);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoClick(object sender, EventArgs e)
        {
            _presentationModel.Undo();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedoClick(object sender, EventArgs e)
        {
            _presentationModel.Redo();
        }
    }
}