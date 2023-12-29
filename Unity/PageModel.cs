using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command.CMM;

namespace Unity
{
    public class PageModel
    {
        private CommandManagerManager _commandManagerManager;
        public BindingList<Shape> shapeList
        {
            get
            {
                if (_pages.Count == 0)
                {
                    return null;
                }

                return _pages[nowPageIndex].shapeList;
            }
        }

        private Page _page
        {
            get
            {
                return _pages[nowPageIndex];
            }
        }

        private List<Page> _pages;

        private int nowPageIndex = 0;

        public PageModel()
        {
            _pages = new List<Page>();
            _commandManagerManager = new CommandManagerManager();
            _commandManagerManager.Attach(this);
        }

        #region wrapper        

        public void Resize(Point point)
        {
            _page.Resize(point);
        }

        public void Draw(IGraphics graphics)
        {
            _page.Draw(graphics);
        }

        public bool IsScale()
        {
            return _page.IsScale();
        }

        public void SwitchStateDrawing()
        {
            foreach (var p in _pages)
            {
                p.SwitchStateDrawing();
            }
        }
        public void SwitchStatePoint()
        {
            foreach (var p in _pages)
            {
                p.SwitchStatePoint();
            }
        }

        public void MouseUp(Point point)
        {
            _page.MouseUp(point);
        }

        public void MouseMove(Point point)
        {
            _page.MouseMove(point);
        }

        public void MouseDown(ShapeType shapeType, Point point)
        {
            _page.MouseDown(shapeType, point);
        }

        public void Add(ShapeType getSelectedItem)
        {
            _page.Add(getSelectedItem);
        }

        public void RemoveIndex(int eRowIndex)
        {
            _page.RemoveIndex(eRowIndex);
        }

        public void DeletePress()
        {
            _page.DeletePress();
        }

        public void Attach(Form1 form)
        {
            _page.Attach(form);
        }

        public void SetNowPageIndex(int index)
        {
            nowPageIndex = index;
            _page.NotifyModelChanged();
        }
        #endregion

        #region CMM
        public void InitAddPage(int index, Form1 form)
        {
            var page = new Page();
            page.Attach(form);
            page.Attach(this);
            _pages.Add(page);
        }
        public void AddPage(int index, Form1 form)
        {
            var page = new Page();
            page.Attach(form);
            page.Attach(this);
            _pages.Add(page);
            _commandManagerManager.AddAddPageCommand(form);
        }
        public void DeletePage(int index, IShapeObserver form)
        {
            _pages[index].Detach(form);
            _pages[index].Detach(this);
            _pages.RemoveAt(index);
        }

        public void Undo()
        {
            _commandManagerManager.Undo(_pages);
        }

        public void Redo()
        {
            _commandManagerManager.Redo(_pages);
        }
        #endregion

        public void HandleCommandChange(Page page)
        {
            var index = _pages.IndexOf(page);
            _commandManagerManager.AddSomeCommand(index);
        }
        public event CommandManagerHandler _commandManagerChanges;
        public delegate void CommandManagerHandler(bool undo, bool redo);
        public void AttachCommandManager(Form1 model)
        {
            _commandManagerChanges += model.HandleUndoButtonState;
        }
        public void NotifyCommandChanged()
        {
            if (_commandManagerChanges != null)
            {
                _commandManagerChanges(_commandManagerManager.IsUnDo(), _commandManagerManager.IsReDo());
            }
        }

        public void ReceiveCommandChanged()
        {
            NotifyCommandChanged();
        }
    }
}
