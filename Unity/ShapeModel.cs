using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    internal class ShapeModel
    {
        private const int HUNDRED = 100;
        private List<Shape> _shapeList = new List<Shape>();
        public List<Shape> shapeList 
        {
            get 
            {
                return _shapeList; 
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
            if (Enum.TryParse(type.ToUpper(), out shapeType))
                Add(shapeType,
                    new Number2(random.Next(zero, HUNDRED), random.Next(zero, HUNDRED)),
                    new Number2(random.Next(zero, HUNDRED), random.Next(zero, HUNDRED)));
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