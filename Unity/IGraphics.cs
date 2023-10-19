namespace Unity
{
    public interface IGraphics
    {
        /// <summary>
        /// draw line
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        void DrawLine(Point2 point1, Point2 point2);
        /// <summary>
        /// draw rectangle
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        void DrawRectangle(Point2 point1, Point2 point2);
        /// <summary>
        /// ellipse
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        void DrawEllipse(Point2 point1, Point2 point2);
    }
}
