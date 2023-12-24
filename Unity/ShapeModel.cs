using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;
using Unity.ShapeModelState;

namespace Unity
{
    enum ModelState
    {
        DRAWING,
        POINT
    }
    public class ShapeModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private List<BindingList<Shape>> pages = new List<BindingList<Shape>> { new BindingList<Shape>() };
        private PointState _pointState = new PointState();
        private IState _state = new DrawingState();
        bool _isPressed;
        private const int CANVAS_MAX = 400;
        private CommandManager _commandManager = new CommandManager();
        Point _nowCanvas = new Point(1, 1);

        public List<BindingList<Shape>> shapeList
        {
            get
            {
                return pages;
            }
        }
        #region state
        /// <summary>
        /// switch
        /// </summary>
        public virtual void SwitchStateDrawing()
        {
            _pointState = new PointState();
            _state = new DrawingState();
            NotifyModelChanged();
        }

        /// <summary>
        /// switch
        /// </summary>
        public virtual void SwitchStatePoint()
        {
            _state = _pointState;
        }

        /// <summary>
        /// set
        /// </summary>
        public virtual bool IsScale(int nowPage)
        {
            return _state.IsScale(pages, nowPage);
        }

        /// <summary>
        /// a
        /// </summary>
        public void Resize(Point point, int nowPage)
        {
            _nowCanvas = point;
            foreach (var shape in pages[nowPage])
            {
                shape.SetNowCanvasSize(point);
            }
        }
        #endregion

        #region draw
        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public virtual void Draw(IGraphics graphics, int nowPage)
        {
            foreach (Shape shape in pages[nowPage])
            {
                shape.Draw(graphics);
            }
            _state.Draw(graphics, pages[nowPage]);
        }
        #endregion

        #region subscribe

        /// <summary>
        /// attach
        /// </summary>
        /// <param name="shapeObserver"></param>
        public void Attach(IShapeObserver shapeObserver)
        {
            _modelChanged += shapeObserver.ReceiveBell;
        }

        /// <summary>
        /// detach
        /// </summary>
        /// <param name="shapeObserver"></param>
        public void Detach(IShapeObserver shapeObserver)
        {
            _modelChanged -= shapeObserver.ReceiveBell;
        }

        /// <summary>
        /// notify
        /// </summary>
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
            }
        }

        /// <summary>
        /// mouse down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        public virtual void MouseDown(ShapeType shapeType, Point point, int nowPage)
        {
            if (PointFunction.IsBothNotNegative(point))
            {
                _state.MouseDown(shapeType, point, pages[nowPage], _nowCanvas, nowPage);
                _isPressed = true;
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        public virtual void MouseUp(Point point, int nowPage)
        {
            if (_isPressed)
            {
                _state.MouseUp(point, pages, _commandManager, nowPage);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        public virtual void MouseMove(Point point, int nowPage)
        {
            _state.MouseMove(point, _isPressed, pages[nowPage]);
            NotifyModelChanged();
        }
        #endregion

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public virtual void Add(ShapeType shapeType, int nowPage)
        {
            var newShape = ShapeFactory.CreateByRandom(shapeType, CANVAS_MAX, _nowCanvas);
            _commandManager.AddShape(
                shapeType,
                newShape.GetFirst(), newShape.GetSecond(), _nowCanvas, nowPage, pages);
            NotifyModelChanged();
        }

        /// <summary>
        /// Add newShape with type and two point
        /// </summary>
        /// <param name="type"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public virtual void Add(ShapeType type, Point start, Point end, int nowPage)
        {
            _commandManager.AddShape(type, start, end, _nowCanvas, nowPage, pages);
            NotifyModelChanged();
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        public virtual void RemoveIndex(int rowIndex, int nowPage)
        {
            if (rowIndex < pages[nowPage].Count)
            {
                _commandManager.Delete(rowIndex, pages, nowPage);
                _state.Reset();
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// delete
        /// </summary>
        public virtual void DeletePress(int nowPage)
        {
            _state.DeletePress(pages, _commandManager, nowPage);
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Undo(int nowPage)
        {
            _commandManager.Undo(pages);
            _state.Reset();
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Redo(int nowPage)
        {
            _commandManager.Redo(pages);
            NotifyModelChanged();
        }

        public void AddPage(int index)
        {
            pages.Add(new BindingList<Shape>());
        }
    }
}