using System.Drawing;

namespace Unity
{
    public class Line : Shape
    {

        private const string LINE = "Line";
        public Line(Point point1, Point point2, Point cx) : base(point1, point2, cx)
        {
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawLine(_info[0], _info[1]);
        }

        /// <summary>
        /// shape name
        /// </summary>
        /// <returns></returns>
        public override string GetShapeName()
        {
            return LINE;
        }
    }
}