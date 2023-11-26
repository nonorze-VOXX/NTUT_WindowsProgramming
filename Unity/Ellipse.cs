namespace Unity
{
    public class Ellipse : Shape
    {
        private const string ELLIPSE = "Ellipse";
        public Ellipse(Point2 point1, Point2 point2) : base(point1, point2)
        {
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(_info[0], _info[1]);
        }

        /// <summary>
        /// shape name
        /// </summary>
        /// <returns></returns>
        public override string GetShapeName()
        {
            return ELLIPSE;
        }
    }
}
