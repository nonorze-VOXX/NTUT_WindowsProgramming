using System.Drawing;

namespace Unity.ShapeModelState
{
    class PointState : IState
    {
        Shape choosingShape = null;
        Point2 first = new Point2(0, 0);
        Point2 second = new Point2(0, 0);
        Point2 size = new Point2(5, 5);
        public void draw(IGraphics graphics)
        {
            if (choosingShape != null)
            {
                graphics.DrawRectangle(first, second, Pens.Red);
                graphics.DrawEllipseByCenterAndSize(first, size);
                graphics.DrawEllipseByCenterAndSize(second, size);
                graphics.DrawEllipseByCenterAndSize(new Point2(first.X, second.Y), size);
                graphics.DrawEllipseByCenterAndSize(new Point2(second.X, first.Y), size);
                graphics.DrawEllipseByCenterAndSize(new Point2(first.X, (first.Y + second.Y) / 2), size);
                graphics.DrawEllipseByCenterAndSize(new Point2(second.X, (first.Y + second.Y) / 2), size);
                graphics.DrawEllipseByCenterAndSize(new Point2((first.X + second.X) / 2, first.Y), size);
                graphics.DrawEllipseByCenterAndSize(new Point2((first.X + second.X) / 2, second.Y), size);

            }
        }

        public bool IsKeep()
        {
            return true;
        }
        public void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> _shapeList)
        {
            foreach (var shape in _shapeList)
            {
                if (shape.IsPointIn(point))
                {
                    choosingShape = shape;
                    first = choosingShape.GetFirst();
                    second = choosingShape.GetSecond();
                    return;
                }
            }
            choosingShape = null;


        }

        public void MouseMove(Point2 point)
        {
            //throw new NotImplementedException();
        }

        public void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> _shapeList)
        {
            //throw new NotImplementedException();
        }
    }
}
