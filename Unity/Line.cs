namespace Unity
{
    public class Line : Shape
    {
        public Line(Point2 start, Point2 end) : base(start, end)
        {
            shape = ShapeType.Line;
        }

        public override void Draw(IGraphics graphics)
        {
            graphics.Drawline(_info[0], _info[1]);
        }
    }
}