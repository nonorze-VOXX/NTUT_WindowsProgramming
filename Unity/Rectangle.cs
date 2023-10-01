using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Rectangle : Shape
    {
        public Rectangle(Vector2 start, Vector2 end) : base(start, end)
        {
            ShapeType = ShapeType.RECTANGLE;
        }
    }
}