namespace Unity
{
    public class Rectangle : Shape
    {
        public Rectangle(Point2 start, Point2 end) : base(start, end)
        {
            shape = ShapeType.RECTANGLE;
        }

        public override void Draw(IGraphics graphics)
        {
            graphics.DrawRectangle(_info[0], _info[1]);
        }
    }
}