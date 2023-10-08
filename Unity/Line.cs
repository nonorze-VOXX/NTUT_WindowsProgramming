namespace Unity
{
    public class Line : Shape
    {
        public Line(Number2 start, Number2 end) : base(start, end)
        {
            shape = ShapeType.LINE;
        }
    }
}