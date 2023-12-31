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
    public class Page
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private BindingList<Shape> shapes = new BindingList<Shape> { };
        private PointState _pointState = new PointState();
        private IState _state = new DrawingState();
        bool _isPressed;
        private const int CANVAS_MAX = 400;
        private CommandManager _commandManager = new CommandManager();
        Point _nowCanvas = new Point(1, 1);


        public BindingList<Shape> shapeList
        {
            get
            {
                return shapes;
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
            return _state.IsScale(shapes);
        }

        /// <summary>
        /// a
        /// </summary>
        public void Resize(Point point)
        {
            _nowCanvas = point;
            foreach (var shape in shapes)
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
            foreach (Shape shape in shapes)
            {
                shape.Draw(graphics);
            }
            _state.Draw(graphics, shapes);
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
                _modelChanged.Invoke();
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
                _state.MouseDown(shapeType, point, shapes, _nowCanvas);
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
                _state.MouseUp(point, shapes, _commandManager);
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
            _state.MouseMove(point, _isPressed, shapes);
            NotifyModelChanged();
        }
        #endregion

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public virtual void Add(ShapeType shapeType)
        {
            shapes.Add(ShapeFactory.CreateByRandom(shapeType, CANVAS_MAX, _nowCanvas, _commandManager));
            NotifyModelChanged();
        }
        public virtual void Add(Shape shape)
        {
            shapes.Add(shape);
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
            shapes.Add(ShapeFactory.CreateShape(type, start, end, _nowCanvas));
            _commandManager.AddShape(type, start, end, _nowCanvas);
            NotifyModelChanged();
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        public virtual void RemoveIndex(int rowIndex)
        {
            if (rowIndex < shapes.Count)
            {
                _commandManager.Delete(rowIndex);
                shapes.RemoveAt(rowIndex);
                _state.Reset();
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// delete
        /// </summary>
        public virtual void DeletePress()
        {
            _state.DeletePress(shapes, _commandManager);
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Undo()
        {
            _commandManager.Undo(shapes);
            _state.Reset();
            NotifyModelChanged();
        }

        /// <summary>
        /// a
        /// </summary>
        public void Redo()
        {
            _commandManager.Redo(shapes);
            NotifyModelChanged();
        }

        public void HandleCommandChange()
        {
            NotifyCommandChange();
        }
        public event PageCommandChange _pageCommandChanged;
        public delegate void PageCommandChange(Page page);
        public void Detach(PageModel pageModel)
        {
            _pageCommandChanged -= pageModel.HandleCommandChange;
            _commandManager.Detach(this);
        }
        public void Attach(PageModel pageModel)
        {
            _pageCommandChanged += pageModel.HandleCommandChange;

            _commandManager.Attach(this);
        }
        void NotifyCommandChange()
        {
            if (_pageCommandChanged != null)
            {
                _pageCommandChanged.Invoke(this);
            }
        }
    }
}