namespace Unity
{
    public class Line : Shape
    {
        public Line(Vector2 start, Vector2 end) : base(start, end)
        {
            ShapeType = ShapeType.LINE;
        }
    }
}