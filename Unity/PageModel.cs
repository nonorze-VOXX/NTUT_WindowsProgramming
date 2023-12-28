using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Unity
{
    public class PageModel
    {
        public BindingList<Shape> shapeList
        {
            get { return _pages[nowPageIndex].shapeList; }
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

        public PageModel(Page page)
        {
            _pages = new List<Page>();
            _pages.Add(page);
        }

        /*
        public void AddPage(int index)
        {
            pages.Add(new BindingList<Shape>());
        }
        public void DeletePage(int index)
        {
            pages.RemoveAt(index);
        }

        public void SetNowPageIndex(int index)
        {
            nowPageIndex = index;
            NotifyModelChanged();
        }
        */
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

        public void Undo()
        {
            _page.Undo();
        }

        public void Redo()
        {
            _page.Redo();
        }

        public void DeletePress()
        {
            _page.DeletePress();
        }

        public void AttachCommandManager(Form1 from)
        {
            _page.AttachCommandManager(from);
        }
    }
}
