using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command.CommandManagerManager;

namespace Unity
{
    public class PageModel
    {
        public event CommandManagerEventHandler _commandManagerChanges;
        public delegate void CommandManagerEventHandler(bool undo, bool redo);
        private CommandManagerManager _commandManagerManager;
        public BindingList<Shape> shapeList
        {
            get
            {
                if (_pages.Count == 0)
                {
                    return null;
                }

                return _pages[_nowPageIndex].shapeList;
            }
        }

        private Page _page
        {
            get
            {
                return _pages[_nowPageIndex];
            }
        }

        private List<Page> _pages;

        private int _nowPageIndex = 0;

        public PageModel()
        {
            _pages = new List<Page>();
            _commandManagerManager = new CommandManagerManager();
            _commandManagerManager.Attach(this);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public int GetPageCount()
        {
            return _pages.Count;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SwitchToSliderWrap(Form1 form)
        {
            _commandManagerManager.Attach(form);
        }
        #region wrapper

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Resize(Point point)
        {
            _page.Resize(point);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Draw(IGraphics graphics)
        {
            _page.Draw(graphics);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public bool IsScale()
        {
            return _page.IsScale();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SwitchStateDrawing()
        {
            foreach (var p in _pages)
            {
                p.SwitchStateDrawing();
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SwitchStatePoint()
        {
            foreach (var p in _pages)
            {
                p.SwitchStatePoint();
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void MouseUp(Point point)
        {
            _page.MouseUp(point);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void MouseMove(Point point)
        {
            _page.MouseMove(point);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void MouseDown(ShapeType shapeType, Point point)
        {
            _page.MouseDown(shapeType, point);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Add(ShapeType getSelectedItem, Point point1, Point point2)
        {
            _page.Add(getSelectedItem, point1, point2);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void RemoveIndex(int index)
        {
            _page.RemoveIndex(index);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void DeletePress()
        {
            _page.DeletePress();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Attach(Form1 form)
        {
            _page.Attach(form);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SetNowPageIndex(int index)
        {
            _nowPageIndex = index;
            _page.NotifyModelChanged();
        }
        #endregion

        #region CMM
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddStartPage(int index, Form1 form)
        {
            var page = new Page();
            page.Attach(form);
            page.Attach(this);
            _pages.Add(page);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddPage(int index, Form1 form)
        {
            var page = new Page();
            page.Attach(form);
            page.Attach(this);
            _pages.Add(page);
            _commandManagerManager.AddAddPageCommand(form);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void DeletePage(int index, Form1 form)
        {
            //_pages[index].Detach(form);
            //_pages[index].Detach(this);
            var page = _pages[index];
            _commandManagerManager.AddRemovePageCommand(form, index, page);
            _pages.RemoveAt(index);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Undo()
        {
            _commandManagerManager.Undo(_pages);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Redo()
        {
            _commandManagerManager.Redo(_pages);
        }
        #endregion

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void HandleCommandChange(Page page)
        {
            var index = _pages.IndexOf(page);
            _commandManagerManager.AddSomeCommand(index);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AttachCommandManager(Form1 model)
        {
            _commandManagerChanges += model.HandleUndoButtonState;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void NotifyCommandChanged()
        {
            if (_commandManagerChanges != null)
            {
                _commandManagerChanges(_commandManagerManager.IsUndo(), _commandManagerManager.IsRedo());
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void ReceiveCommandChanged()
        {
            NotifyCommandChanged();
        }

        #region google

        private GoogleDriveWrap _drive = new GoogleDriveWrap();

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Load(Form1 form)
        {
            var newPage = _drive.LoadData();
            int index = 0;
            for (index = 0; index < newPage.Count; index++)
            {
                if (_pages.Count == index)
                {
                    AddPage(index, form);
                }
                _pages[index].Clear();
                AddToList(newPage, index);
            }
            for (int j = _pages.Count - 1; j >= index; j--)
            {
                _pages.RemoveAt(index);
            }
            _commandManagerManager.Clear();
            NotifyCommandChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="newPage"></param>
        /// <param name="index"></param>
        void AddToList(List<Page> newPage, int index)
        {
            foreach (var shape in newPage[index].shapeList)
            {
                _pages[index].Add(shape);
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            _drive.SaveData(_pages);
            _commandManagerManager.Clear();
            NotifyCommandChanged();
        }
        #endregion
    }
}