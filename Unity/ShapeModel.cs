using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Unity
{
    public class ShapeModel
    {
        private const int HUNDRED = 100;
        private BindingList<Shape> _shapeList = new BindingList<Shape>();
        public BindingList<Shape> shapeList
        {
            get
            {
                return _shapeList;
            }
        }
        private List<Interface.IShapeObserver> _subscriberList = new List<Interface.IShapeObserver>();
        public void Attach(Interface.IShapeObserver shapeObserver)
        {
            _subscriberList.Add(shapeObserver);
        }

        private void NotifyShapeObserver()
        {
            foreach (var shapeOvserver in _subscriberList)
            {
                shapeOvserver.UpdateView();
            }
        }

        public void Detach(Interface.IShapeObserver shapeObserver)
        {
            _subscriberList.Remove(shapeObserver);
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
            Number2 number = new Number2(random.Next(zero, HUNDRED), random.Next(zero, HUNDRED));

            if (Enum.TryParse(type.ToUpper(), out shapeType))
            {
                Add(shapeType,
                    new Number2(random.Next(zero, (int)number.X), random.Next(zero, (int)number.Y)),
                    new Number2(random.Next((int)number.X, HUNDRED), random.Next((int)number.Y, HUNDRED)));
            }
        }

        /// <summary>
        /// Add newShape with type and two point
        /// </summary>
        /// <param name="type"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void Add(ShapeType type, Number2 start, Number2 end)
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