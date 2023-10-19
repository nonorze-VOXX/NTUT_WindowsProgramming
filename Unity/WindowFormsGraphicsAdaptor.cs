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

        public void DrawEllipse(Point2 point1, Point2 point2)
        {
            _graphics.DrawEllipse(
                Pens.Black,
                point1.X, point1.Y,
                point2.X - point1.X,
                point2.Y - point1.Y
                );
        }

        public void Drawline(Point2 point1, Point2 point2)
        {
            _graphics.DrawLine(Pens.Black,
                point1.X, point1.Y,
                point2.X, point2.Y
           );
        }

        public void DrawRectangle(Point2 point1, Point2 point2)
        {
            var position = new Point2(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
            Point2 distance = Point2.Abs(point1, point2);
            _graphics.DrawRectangle(
                Pens.Black,
                position.X, position.Y,
                distance.X,
                distance.Y
                );
        }
    }
}
