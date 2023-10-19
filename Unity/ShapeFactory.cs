namespace Unity
{
    public enum ShapeType
    {
        Line,
        Rectangle,
        Ellipse
    }

    internal class ShapeFactory
    {
        /// <summary>
        /// create shape by factory
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Shape CreateShape(ShapeType shapeType, Point2 start, Point2 end)
        {
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(start, end);
                case ShapeType.Rectangle:
                    return new Rectangle(start, end);
                case ShapeType.Ellipse:
                    return new Ellipse(start, end);
                default:
                    return null;
            }
        }
    }
}