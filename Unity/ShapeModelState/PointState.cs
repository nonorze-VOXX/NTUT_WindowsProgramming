using System.Drawing;

namespace Unity.ShapeModelState
{
    class PointState : IState
    {
        Shape choosingShape = null;
        Point2 size = new Point2(5, 5);
        Point2 prePoint = new Point2(0, 0);
        public void draw(IGraphics graphics)
        {
            if (choosingShape != null)
            {
                var first = choosingShape.GetFirst();
                var second = choosingShape.GetSecond();
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

        public void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> _shapeList)
        {
            prePoint = point;
            foreach (var shape in _shapeList)
            {
                if (shape.IsPointIn(point))
                {
                    choosingShape = shape;
                    return;
                }
            }
            choosingShape = null;
        }

        public void MouseMove(Point2 point)
        {
            if (choosingShape != null)
            {
                var delta = Point2.Sub(point, prePoint);
                choosingShape.Move(delta);
                prePoint = point;
            }
        }

        public void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> _shapeList)
        {
            //throw new NotImplementedException();
        }
    }
}
