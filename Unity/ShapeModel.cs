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
        private int nowPageIndex = 0;
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
        public virtual bool IsScale()
        {
            return _state.IsScale(pages[nowPageIndex]);
        }

        /// <summary>
        /// a
        /// </summary>
        public void Resize(Point point)
        {
            _nowCanvas = point;
            foreach (var shape in pages[nowPageIndex])
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
        public virtual void Draw(IGraphics graphics)
        {
            foreach (Shape shape in pages[nowPageIndex])
            {
                shape.Draw(graphics);
            }
            _state.Draw(graphics, pages[nowPageIndex]);
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
        public virtual void MouseDown(ShapeType shapeType, Point point)
        {
            if (PointFunction.IsBothNotNegative(point))
            {
                _state.MouseDown(shapeType, point, pages[nowPageIndex], _nowCanvas);
                _isPressed = true;
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        public virtual void MouseUp(Point point)
        {
            if (_isPressed)
            {
                _state.MouseUp(point, pages[nowPageIndex], _commandManager);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        public virtual void MouseMove(Point point)
        {
            _state.MouseMove(point, _isPressed, pages[nowPageIndex]);
            NotifyModelChanged();
        }
        #endregion

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public virtual void Add(ShapeType shapeType)
        {
            pages[nowPageIndex].Add(ShapeFactory.CreateByRandom(shapeType, CANVAS_MAX, _nowCanvas, _commandManager));
            NotifyModelChanged();
        }

        /// <summary>
        /// Add newShape with type and two point
        /// </summary>
        /// <param name="type"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public virtual void Add(ShapeType type, Point start, Point end)
        {
            pages[nowPageIndex].Add(ShapeFactory.CreateShape(type, start, end, _nowCanvas));
            _commandManager.AddShape(type, start, end, _nowCanvas);
            NotifyModelChanged();
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        public virtual void RemoveIndex(int rowIndex)
        {
            if (rowIndex < pages[nowPageIndex].Count)
            {
                _commandManager.Delete(rowIndex);
                pages[nowPageIndex].RemoveAt(rowIndex);
                _state.Reset();
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// delete
        /// </summary>
        public virtual void DeletePress()
        {
            _state.DeletePress(pages[nowPageIndex], _commandManager);
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Undo()
        {
            _commandManager.Undo(pages[nowPageIndex]);
            _state.Reset();
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Redo()
        {
            _commandManager.Redo(pages[nowPageIndex]);
            NotifyModelChanged();
        }

        public void AddPage(int index)
        {
            pages.Add(new BindingList<Shape>());
        }
    }
}