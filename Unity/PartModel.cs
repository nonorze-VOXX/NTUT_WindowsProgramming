using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public partial class PresentationModel
    {
        /// <summary>
        /// get
        /// </summary>
        /// <returns></returns>
        public BindingList<Shape> GetShapeList()
        {
            return _pageModel.shapeList;
        }

        #region CanvasMouse

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="point"></param>
        /// <param name="toolStripItems"></param>
        public void HandleCanvasMouseUp(Canvas canvas, Point point, ToolStripItemCollection items)
        {
            _pageModel.MouseUp(point);
            HandleToolStripPointButtonClick(items, canvas);
        }

        /// <summary>
        /// mouse move
        /// </summary>
        /// <param name="point"></param>
        public void HandleCanvasMouseMove(Point point)
        {
            _pageModel.MouseMove(point);
        }

        /// <summary>
        /// mouse down
        /// </summary>
        /// <param name="point"></param>
        public void HandleCanvasMouseDown(Point point)
        {
            for (int i = 0; i < _shapeButtonActive.Count; i++)
            {
                if (_shapeButtonActive[i])
                {
                    _pageModel.MouseDown((ShapeType)i, point);
                }
            }

            _focusSlide = false;
        }
        #endregion

        /// <summary>
        /// delete button click with delete model and datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _pageModel.RemoveIndex(e.RowIndex);
            }
        }

        /// <summary>
        /// a
        /// </summary>
        public void Undo()
        {
            _pageModel.Undo();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Redo()
        {
            _pageModel.Redo();
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="shapeType"></param>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public void HandleToolStripButtonClick(ToolStripItemCollection toolStripItems, ShapeType shapeType, Canvas canvas)
        {
            UpdateShapeButtonActive(toolStripItems, (int)shapeType, true);
            canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            _pageModel.SwitchStateDrawing();
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public void HandleToolStripPointButtonClick(ToolStripItemCollection toolStripItems, Canvas canvas)
        {
            if (toolStripItems == null)
            {
                return;
            }

            UpdateShapeButtonActive(toolStripItems, 1 + 1 + 1, true);
            canvas.Cursor = System.Windows.Forms.Cursors.Default;
            _pageModel.SwitchStatePoint();
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="e"></param>
        public void HandleKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (_focusSlide)
                {
                    if (_deletePage != null)
                    {
                        _deletePage.Invoke();
                    }
                }
                else
                {
                    _pageModel.DeletePress();
                }
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddPageButtonClick()
        {
            _pageIndex += 1;
            _addPage.Invoke(_pageIndex);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        internal void ClickSlide(int index, DataGridView dataGridView)
        {
            _nowPageIndex = index;
            _pageModel.SetNowPageIndex(index);
            dataGridView.DataSource = GetShapeList();
            _focusSlide = true;
        }

        private bool _focusSlide = false;

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SetFocusSlide(bool slide)
        {
            _focusSlide = slide;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public int GetNowPage()
        {
            return _nowPageIndex;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SetUndoHandler(Form1 from)
        {
            _pageModel.AttachCommandManager(from);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Load(Form1 form)
        {
            _pageModel.Load(form);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            _pageModel.Save();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public int GetPageCount()
        {
            return _pageModel.GetPageCount();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddShape(ShapeType shapeType, Point point, Point point1)
        {
            _pageModel.Add(shapeType, point, point1);
        }
    }
}
