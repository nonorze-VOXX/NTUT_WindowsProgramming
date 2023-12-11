using System.Drawing;

namespace Unity
{
    public class Rectangle : Shape
    {
        private const string RECTANGLE = "Rectangle";
        public Rectangle(Point point1, Point point2, Point point) : base(point1, point2, point)
        {
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            var info = GetFixedInfo();
            graphics.DrawRectangle(info[0], info[1]);
        }

        /// <summary>
        /// shape name
        /// </summary>
        /// <returns></returns>
        public override string GetShapeName()
        {
            return RECTANGLE;
        }
    }
}