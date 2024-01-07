using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public partial class PresentationModel
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
        private BindingList<Shape> _fakeBindingList = new BindingList<Shape>();
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
            _pageModel.SwitchToSliderWrap(form);
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
                form.SwitchToSlide(_pageModel.GetPageCount() - 1);
            }
            else
            {
                form.SwitchToSlide(_nowPageIndex);
            }
            Debug.Assert(_nowPageIndex >= 0);
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
            _pageModel.AddStartPage(0, form);
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
    }
}
