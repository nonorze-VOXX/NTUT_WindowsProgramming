using System;
using System.Drawing;

namespace Unity
{
    public class WindowFormsGraphicsAdaptor : IGraphics
    {
        private Graphics _graphics;
        public const int TWO_INTEGER = 2;

        public WindowFormsGraphicsAdaptor(Graphics graphics)
        {
            _graphics = graphics;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawEllipse(Point point1, Point point2)
        {
            _graphics.DrawEllipse(Pens.Black, point1.X, point1.Y, point2.X - point1.X, point2.Y - point1.Y);
        }

        /// <summary>
        /// fraw
        /// </summary>
        /// <param name="first"></param>
        /// <param name="size"></param>
        public void DrawEllipseByCenterAndSize(Point first, Point size)
        {
            DrawEllipse(
                PointFunction.GetSubstract(first, PointFunction.Divide(size, TWO_INTEGER)),
                PointFunction.Add(first, PointFunction.Divide(size, TWO_INTEGER))
                );
        }

        /// <summary>
        /// line
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawLine(Point point1, Point point2)
        {
            _graphics.DrawLine(Pens.Black, point1.X, point1.Y, point2.X, point2.Y);
        }

        /// <summary>
        /// rectangle
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public void DrawRectangle(Point point1, Point point2)
        {
            var position = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point distance = PointFunction.GetDistance(point1, point2);
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
        public void DrawRectangle(Point point1, Point point2, Pen pen)
        {
            var position = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point distance = PointFunction.GetDistance(point1, point2);
            _graphics.DrawRectangle(
                pen,
                position.X, position.Y,
                distance.X,
                distance.Y
                );
        }
    }
}
