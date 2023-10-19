namespace Unity
{
    class Ellipse : Shape
    {
        public Ellipse(Point2 point1, Point2 point2) : base(point1, point2)
        {
            shape = ShapeType.Ellipse;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawEllipse(_info[0], _info[1]);
        }
    }
}
