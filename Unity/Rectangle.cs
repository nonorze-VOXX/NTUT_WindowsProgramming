using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unity
{
    public class Rectangle : Shape
    {
        public Rectangle(Number2 start, Number2 end) : base(start, end)
        {
            ShapeType = ShapeType.RECTANGLE;
        }
    }
}