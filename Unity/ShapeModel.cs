using System.ComponentModel;
using Unity.ShapeModelState;

namespace Unity
{
    enum state
    {
        drawing,
        point
    }
    public class ShapeModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        private DrawingState drawingState = new DrawingState();
        bool _isPressed;
        private const int CANVAS_MAX = 400;
        public BindingList<Shape> shapeList
        {
            get
            {
                return _shapeList;
            }
        }

        #region draw
        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        internal void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapeList)
            {
                shape.Draw(graphics);
            }
            if (_isPressed)
            {
                drawingState.draw(graphics);
            }
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
        internal void MouseDown(ShapeType shapeType, Point2 point)
        {
            if (point.IsBothPositive())
            {
                drawingState.MouseDown(shapeType, point);
                _isPressed = true;
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        internal void MouseUp(Point2 point)
        {
            if (_isPressed)
            {
                drawingState.MouseUp(point, _shapeList);
                _isPressed = false;
                NotifyModelChanged();
            }
        }

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="point"></param>
        internal void MouseMove(Point2 point)
        {
            if (_isPressed)
            {
                drawingState.MouseMove(point);
                NotifyModelChanged();
            }
        }
        #endregion

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public void Add(ShapeType shapeType)
        {
            _shapeList.Add(ShapeFactory.CreateByRandom(shapeType, CANVAS_MAX));
            NotifyModelChanged();
        }

        /// <summary>
        /// Add newShape with type and two point
        /// </summary>
        /// <param name="type"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void Add(ShapeType type, Point2 start, Point2 end)
        {
            _shapeList.Add(ShapeFactory.CreateShape(type, start, end));
            NotifyModelChanged();
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        internal void RemoveIndex(int rowIndex)
        {
            _shapeList.RemoveAt(rowIndex);
            NotifyModelChanged();
        }
    }
}