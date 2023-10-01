using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    internal class ShapeModel
    {
        private List<Shape> _shapeList = new List<Shape>();
        public List<Shape> shapeList { get { return _shapeList; }}

        public void Add(string type)
        {
            ShapeType shapeType;
            var r = new Random();
            if (Enum.TryParse(type.ToUpper(), out shapeType))
                Add(shapeType,
                    new Vector2(r.Next(0, 100), r.Next(0, 100)),
                    new Vector2(r.Next(0, 100), r.Next(0, 100)));
        }

        public void Add(ShapeType type, Vector2 start, Vector2 end)
        {
            _shapeList.Add(ShapeFactory.CreateShape(type, start, end));
        }

        internal void RemoveIndex(int rowIndex)
        {
            _shapeList.RemoveAt(rowIndex);
        }
    }
}