using System;
using System.ComponentModel;

namespace Unity
{
    public class ShapeModel
    {
        public event ModelChangedEventhandler _modelChanged;
        public delegate void ModelChangedEventhandler();
        private const int HUNDRED = 100;
        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        bool _isPressed;
        Shape _hint = new Line(Point2.ZERO, Point2.ZERO);
        public BindingList<Shape> shapeList
        {
            get
            {
                return _shapeList;
            }
        }

        #region draw
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
        public void Attach(IShapeObserver shapeObserver)
        {
            _modelChanged += shapeObserver.Bell;
        }
        public void Detach(IShapeObserver shapeObserver)
        {
            _modelChanged -= shapeObserver.Bell;
        }
        void NotifyModelChanged()
        {
            if (_modelChanged != null)
            {
                _modelChanged();
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