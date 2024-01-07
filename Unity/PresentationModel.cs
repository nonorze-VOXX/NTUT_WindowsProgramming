using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public class PresentationModel
    {
        public event DeletePageEventHandler _deletePage;
        public delegate void DeletePageEventHandler();
        public event AddPageEventHandler _addPage;
        public delegate void AddPageEventHandler(int index);
        private int _pageIndex = -1;
        private int _nowPageIndex = 0;
        private const int ONE_SIX = 16;
        private const int NINE = 9;
        //Page _page;
        private PageModel _pageModel;
        List<bool> _shapeButtonActive;
        private BindingList<Shape> _fakeBindingList;
        public BindingList<Shape> shapeListUnit
        {
            get
            {
                return _fakeBindingList;
            }
        }
        /// <summary>
        /// model
        /// </summary>
        /// <param name="model"></param>
        public PresentationModel(PageModel model)
        {
            _pageModel = model;
            _shapeButtonActive = new List<bool>
            {
                false, false, false,false
            };
            _pageModel.SwitchStatePoint();
        }
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SwitchToSliderWrap(Form1 form)
        {
            _pageModel.SwitchToSliderWrapper(form);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SetAddPageEvent(Form1 form)
        {
            _addPage += index => _pageModel.AddPage(index, form);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SetNowPageIndex(int index)
        {
            _nowPageIndex = index;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void DeletePage(Form1 form)
        {
            if (_pageModel.GetPageCount() <= 1)
            {
                return;
            }
            _pageModel.DeletePage(_nowPageIndex, form);
            form.DeletePageAt(_nowPageIndex);
            if (_pageModel.GetPageCount() - 1 < _nowPageIndex)
            {
                form.SwitchToslide(_pageModel.GetPageCount() - 1);
            }
            else
            {
                form.SwitchToslide(_nowPageIndex);
            }

        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AttachDelete(Form1 form)
        {
            _deletePage += form.DeletePage;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddFirstPage(int index, Form1 form)
        {
            _pageModel.InitAddPage(0, form);
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics, Canvas canvas)
        {
            _pageModel.Draw(graphics);
            if (_pageModel.IsScale())
            {
                canvas.Cursor = Cursors.SizeNWSE;
            }
            else
            {
                if (canvas.Cursor != Cursors.Cross)
                {
                    canvas.Cursor = Cursors.Default;
                }

            }
        }

        /// <summary>
        /// a
        /// </summary>
        internal void Resize(Canvas canvas, Control.ControlCollection slide)
        {
            canvas.Height = canvas.Width / ONE_SIX * NINE;
            for (int i = 0; i < slide.Count; i++)
            {
                slide[i].Height = slide[i].Width / ONE_SIX * NINE;
            }

            for (int i = 1; i < slide.Count; i++)
            {
                slide[i].Location = new Point(1 + 1 + 1, slide[i - 1].Location.Y + slide[i - 1].Height);
            }
            _pageModel.Resize(new Point(canvas.Width, canvas.Height));
        }

        /// <summary>
        /// update tool stript
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="clickedIndex"></param>
        /// <param name="clicked"></param>
        public void UpdateShapeButtonActive(ToolStripItemCollection toolStripItems, int clickedIndex, bool clicked)
        {
            _shapeButtonActive = ResetToolStripButton(toolStripItems);
            _shapeButtonActive[clickedIndex] = clicked;
            UpdateToolStripButton(toolStripItems, _shapeButtonActive);
        }

        /// <summary>
        /// reset
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <returns></returns>
        List<bool> ResetToolStripButton(ToolStripItemCollection toolStripItems)
        {
            List<bool> newList = new List<bool>();

            if (toolStripItems == null)
            {
                newList.Add(false);
                return newList;
            }
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                newList.Add(false);
            }

            return newList;
        }

        /// <summary>
        /// tool
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="shapeButtonActive"></param>
        void UpdateToolStripButton(ToolStripItemCollection toolStripItems, List<bool> shapeButtonActive)
        {
            if (toolStripItems == null)
            {
                return;
            }
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                var toolStripButton = (System.Windows.Forms.ToolStripButton)toolStripItems[i];
                toolStripButton.Checked = shapeButtonActive[i];
            }

        }

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