using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using ButtonFunction = System.Action<object, System.EventArgs>;

namespace Unity
{
    public class PresentationModel
    {
        public event AddPage addPage;
        public delegate void AddPage(int index);
        private int pageIndex = 0;
        private int nowPageIndex = 0;
        private const int ONE_SIX = 16;
        private const int NINE = 9;
        Page _page;
        List<bool> _shapeButtonActive;
        private BindingList<Shape> fakeBindingList;
        public BindingList<Shape> shapeListUnit
        {
            get
            {
                return fakeBindingList;
            }
        }
        /// <summary>
        /// model
        /// </summary>
        /// <param name="model"></param>
        public PresentationModel(Page model)
        {
            _page = model;
            //addPage += model.AddPage;
            _shapeButtonActive = new List<bool>
            {
                false, false, false,false
            };
            _page.SwitchStatePoint();
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics, Canvas canvas)
        {
            _page.Draw(graphics);
            if (_page.IsScale())
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
                slide[i].Location = new Point(3, slide[i - 1].Location.Y + slide[i - 1].Height);
            }
            _page.Resize(new Point(canvas.Width, canvas.Height));
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
            return _page.shapeList;
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
            _page.MouseUp(point);
            HandleToolStripPointButtonClick(items, canvas);
        }

        /// <summary>
        /// mouse move
        /// </summary>
        /// <param name="point"></param>
        public void HandleCanvasMouseMove(Point point)
        {
            _page.MouseMove(point);
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
                    _page.MouseDown((ShapeType)i, point);
                }
            }
        }
        #endregion

        /// <summary>
        /// create shape button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ButtonFunction CreateButtonClick(ShapeTypeComboBox comboBox)
        {
            return (object sender, EventArgs e) =>
            {
                _page.Add((ShapeType)comboBox.GetSelectedItem());
            };
        }

        /// <summary>
        /// delete button click with delete model and datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _page.RemoveIndex(e.RowIndex);
            }
        }

        /// <summary>
        /// a
        /// </summary>
        public void Undo()
        {
            _page.Undo();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Redo()
        {
            _page.Redo();
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
            _page.SwitchStateDrawing();
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
            _page.SwitchStatePoint();
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="e"></param>
        public void HandleKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _page.DeletePress();
            }
        }

        internal void AddPageButtonClick()
        {
            pageIndex += 1;
            addPage.Invoke(pageIndex);
        }

        internal void ClickSlide(int index, DataGridView dataGridView)
        {
            nowPageIndex = index;
            dataGridView.DataSource = GetShapeList();
            //_page.SetNowPageIndex(index);
        }

        public int GetNowPage()
        {
            return nowPageIndex;
        }

        public void SetUndoHandler(Form1 from)
        {
            _page.AttachCommandManager(from);

        }
    }
}
