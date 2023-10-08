namespace Unity
{
    public class Rectangle : Shape
    {
        public Rectangle(Number2 start, Number2 end) : base(start, end)
        {
            shape = ShapeType.RECTANGLE;
        }
    }
}