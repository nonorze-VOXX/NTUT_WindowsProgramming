using System;
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
            _presentationModel.addPage += AddPage;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));

            ClickMouse(null, null);
            this.Resize += ResizeWindow;
            ResizeWindow(null, null);
            AddPage(0);
            _presentationModel.SetUndoHandler(this);
            HandleUndoButtonState(false, false);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void ResizeWindow(object sender, EventArgs e)
        {
            _presentationModel.Resize(_canvas, _splitContainer1.Panel1.Controls);
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
            var slide = _splitContainer1.Panel1.Controls[_presentationModel.GetNowPage()] as Button;
            slide.Image = new Bitmap(_brief, slide.Size);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickLine(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick(this._toolStrip1.Items, ShapeType.Line, _canvas);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickRectangle(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick(this._toolStrip1.Items, ShapeType.Rectangle, _canvas);

        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClickCircle(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripButtonClick
                (this._toolStrip1.Items, ShapeType.Ellipse, _canvas);

        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>White
        private void ClickMouse(object sender, EventArgs e)
        {
            _presentationModel.HandleToolStripPointButtonClick(this._toolStrip1.Items, _canvas);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveRightSplitLine(object sender, SplitterEventArgs e)
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

        private void AddPageButtonClick(object sender, EventArgs e)
        {
            _presentationModel.AddPageButtonClick();
        }
        public void AddPage(int index)
        {
            var slide = new Button();
            slide.Anchor = ((AnchorStyles)(((AnchorStyles.Right | AnchorStyles.Left) | AnchorStyles.Top)));
            slide.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            var width = _splitContainer1.Panel1.Width - 6;
            var height = width / 16 * 9;
            slide.Size = new Size(width, height);
            slide.Location = new Point(3, 3 + _splitContainer1.Panel1.Controls.Count * height);
            slide.Name = "slide";
            slide.BackColor = Color.White;
            slide.Focus();
            this._splitContainer1.Panel1.Controls.Add(slide);
            slide.Click += HandleSlideClick(_splitContainer1.Panel1.Controls, slide);
        }

        private EventHandler HandleSlideClick(Control.ControlCollection panel1Controls, Button slide)
        {
            var index = _splitContainer1.Panel1.Controls.IndexOf(slide);
            return (object sender, EventArgs e) =>
            {
                _presentationModel.ClickSlide(index, _dataGridView);
            };
        }

        public void HandleUndoButtonState(bool undo, bool redo)
        {
            _undoButton.Enabled = undo;
            _redoButton.Enabled = redo;
        }
    }
}