namespace Unity
{
    public interface IGraphics
    {
        void Drawline(Point2 point1, Point2 point2);
        void DrawRectangle(Point2 point1, Point2 point2);
        void DrawEllipse(Point2 point1, Point2 point2);
    }
}
