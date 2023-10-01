namespace Unity
{
    public enum ShapeType
    {
        LINE,
        RECTANGLE
    }

    internal class ShapeFactory
    {
        public static Shape CreateShape(ShapeType shapeType, Vector2 start, Vector2 end)
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