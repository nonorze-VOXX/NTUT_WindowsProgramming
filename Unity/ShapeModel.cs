using System;
using System.ComponentModel;

namespace Unity
{
    public class ShapeModel
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private const int HUNDRED = 100;
        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        bool _isPressed;
        Shape _hint = new Line(new Point2(0, 0), new Point2(0, 0));
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
                _hint.Draw(graphics);
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
                _hint = ShapeFactory.CreateShape(shapeType, new Point2(0, 0), new Point2(0, 0));
                _hint.SetFirst(point);
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
                _isPressed = false;
                _shapeList.Add(_hint);
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
                _hint.SetSecond(point);
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
            var zero = 0;
            var random = new Random();
            Point2 number = new Point2(random.Next(zero, HUNDRED), random.Next(zero, HUNDRED));
            Add(shapeType,
                new Point2(random.Next(zero, (int)number.X), random.Next(zero, (int)number.Y)),
                new Point2(random.Next((int)number.X, HUNDRED), random.Next((int)number.Y, HUNDRED)));
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