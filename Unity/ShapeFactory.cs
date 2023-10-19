namespace Unity
{
    public enum ShapeType
    {
        LINE,
        RECTANGLE
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
                case ShapeType.LINE:
                    return new Line(start, end);
                case ShapeType.RECTANGLE:
                    return new Rectangle(start, end);
                default:
                    return null;
            }
        }
    }
}