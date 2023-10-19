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
        Shape _hint = new Line();

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

        public BindingList<Shape> shapeList
        {
            get
            {
                return _shapeList;
            }
        }
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

        /// <summary>
        /// Add newShape with type, info is random
        /// </summary>
        /// <param name="type"></param>
        public void Add(string type)
        {
            var zero = 0;
            ShapeType shapeType;
            var random = new Random();
            Point2 number = new Point2(random.Next(zero, HUNDRED), random.Next(zero, HUNDRED));

            if (Enum.TryParse(type.ToUpper(), out shapeType))
            {
                Add(shapeType,
                    new Point2(random.Next(zero, (int)number.X), random.Next(zero, (int)number.Y)),
                    new Point2(random.Next((int)number.X, HUNDRED), random.Next((int)number.Y, HUNDRED)));
            }
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
        }

        /// <summary>
        /// remove from list by index
        /// </summary>
        /// <param name="rowIndex"></param>
        internal void RemoveIndex(int rowIndex)
        {
            _shapeList.RemoveAt(rowIndex);
        }
    }
}