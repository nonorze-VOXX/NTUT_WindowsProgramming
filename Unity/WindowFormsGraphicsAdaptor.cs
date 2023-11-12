using System;
using System.Drawing;

namespace Unity
{
    class WindowFormsGraphicsAdaptor : IGraphics
    {
        private Graphics _graphics;

        public WindowFormsGraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawEllipse(Point2 point1, Point2 point2)
        {
            var (x1, y1) = point1.GetTuple();
            var (x2, y2) = point2.GetTuple();
            _graphics.DrawEllipse(Pens.Black, x1, y1, x2 - x1, y2 - y1);
        }

        public void DrawEllipseByCenterAndSize(Point2 first, Point2 size)
        {
            DrawEllipse(
                Point2.Sub(first, Point2.Div(size, 2)),
                Point2.Add(first, Point2.Div(size, 2))
                );
        }

        /// <summary>
        /// line
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawLine(Point2 point1, Point2 point2)
        {
            _graphics.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// rectangle
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawRectangle(Point2 point1, Point2 point2)
        {
            var position = new Point2(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2 distance = Point2.GetDistance(point1, point2);
            _graphics.DrawRectangle(
                Pens.Black,
                position.X, position.Y,
                distance.X,
                distance.Y
                );
        }
        /// <summary>
        /// rectangle
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawRectangle(Point2 point1, Point2 point2, Pen pen)
        {
            var position = new Point2(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2 distance = Point2.GetDistance(point1, point2);
            _graphics.DrawRectangle(
                pen,
                position.X, position.Y,
                distance.X,
                distance.Y
                );
        }
    }
}
