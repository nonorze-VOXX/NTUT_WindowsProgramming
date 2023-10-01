using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Shape
    {
        private List<Vector2> _info = new List<Vector2>();
        private ShapeType _shapeType;



        public Shape(Vector2 start, Vector2 end)
        {
            SetInfo(start, end);
        }

        public ShapeType ShapeType
        {
            get => _shapeType;
            set => _shapeType = value;
        }

        private Shape SetInfo(Vector2 start, Vector2 end)
        {
            _info.Add(start);
            _info.Add(end);
            return this;
        }

        public virtual List<Vector2> GetInfo()
        {
            return _info;
        }

        public virtual string GetShapeName()
        {
            return _shapeType.ToString();
        }
    }
}