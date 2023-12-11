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
        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        private PointState _pointState = new PointState();
        private IState _state = new DrawingState();
        bool _isPressed;
        private const int CANVAS_MAX = 400;
        private CommandManager _commandManager = new CommandManager();
        Point nowCanvas = new Point(1920, 1080);

        public BindingList<Shape> shapeList
        {
            get
            {
                return _shapeList;
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
            return _state.IsScale();
        }

        internal void Resize(Point point)
        {
            nowCanvas = point;
            foreach (var shape in _shapeList)
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
            foreach (Shape shape in _shapeList)
            {
                shape.Draw(graphics);
            }
            _state.Draw(graphics);
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
        void NotifyModelChanged()
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
                _state.MouseDown(shapeType, point, _shapeList, nowCanvas);
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
                _state.MouseUp(point, _shapeList, _commandManager);
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
            _state.MouseMove(point, _isPressed);
            NotifyModelChanged();
        }
        #endregion

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public virtual void Add(ShapeType shapeType)
        {
            _shapeList.Add(ShapeFactory.CreateByRandom(shapeType, CANVAS_MAX, nowCanvas, _commandManager));
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
            _shapeList.Add(ShapeFactory.CreateShape(type, start, end, nowCanvas));
            _commandManager.AddShape(type, start, end, nowCanvas);
            NotifyModelChanged();
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        public virtual void RemoveIndex(int rowIndex)
        {
            _commandManager.Delete(rowIndex);
            _shapeList.RemoveAt(rowIndex);
            NotifyModelChanged();
        }

        /// <summary>
        /// delete
        /// </summary>
        public virtual void DeletePress()
        {
            _state.DeletePress(shapeList, _commandManager);
            NotifyModelChanged();
        }
        internal void Undo()
        {
            _commandManager.Undo(_shapeList);
            NotifyModelChanged();
        }

        internal void Redo()
        {
            _commandManager.Redo(_shapeList);
            NotifyModelChanged();
        }
    }
}