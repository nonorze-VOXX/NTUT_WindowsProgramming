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
        public void Drawline(Point2 point1, Point2 point2)
        {
            _graphics.DrawLine(Pens.Black,
                point1.X, point1.Y,
                point2.X, point2.Y
           );
        }

        public void DrawRectangle(Point2 point1, Point2 point2)
        {
            _graphics.DrawRectangle(
                Pens.Black,
                point1.X, point1.Y,
                point2.X - point1.X,
                point2.Y - point1.Y
                );
        }
    }
}
