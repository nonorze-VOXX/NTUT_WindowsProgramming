namespace Unity
{
    public class Rectangle : Shape
    {
        private const string RECTANGLE = "Rectangle";
        public Rectangle(Point2 start, Point2 end) : base(start, end)
        {
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_info[0], _info[1]);
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