using System;
using System.Drawing;

namespace Unity.ShapeModelState
{
    public class PointState : IState
    {
        Shape _choosingShape = null;
        public const int EIGHT_INTEGER = 8;
        public const int TWO_INTEGER = 2;
        Point2 _size = new Point2(EIGHT_INTEGER, EIGHT_INTEGER);
        Point2 _pastPoint = new Point2(0, 0);

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        public void DeletePress(System.ComponentModel.BindingList<Shape> shapeList)
        {
            if (_choosingShape != null)
            {
                shapeList.Remove(_choosingShape);
                _choosingShape = null;
            }
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            if (_choosingShape != null)
            {
                var first = _choosingShape.GetFirst();
                var (x1, y1) = first.GetTuple();
                var second = _choosingShape.GetSecond();
                var (x2, y2) = second.GetTuple();
                graphics.DrawRectangle(first, second, Pens.Red);
                graphics.DrawEllipseByCenterAndSize(first, _size);
                graphics.DrawEllipseByCenterAndSize(second, _size);
                graphics.DrawEllipseByCenterAndSize(new Point2(x1, y2), _size);
                graphics.DrawEllipseByCenterAndSize(new Point2(x2, y1), _size);
                graphics.DrawEllipseByCenterAndSize(new Point2(x1, (y1 + y2) / TWO_INTEGER), _size);
                graphics.DrawEllipseByCenterAndSize(new Point2(x2, (y1 + y2) / TWO_INTEGER), _size);
                graphics.DrawEllipseByCenterAndSize(new Point2((x1 + x2) / TWO_INTEGER, y1), _size);
                graphics.DrawEllipseByCenterAndSize(new Point2((x1 + x2) / TWO_INTEGER, y2), _size);
            }
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> shapeList)
        {
            _pastPoint = point;
            foreach (var shape in shapeList)
            {
                if (shape.IsPointIn(point))
                {
                    _choosingShape = shape;
                    return;
                }
            }
            _choosingShape = null;
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        public void MouseMove(Point2 point)
        {
            if (_choosingShape != null)
            {
                var delta = Point2.GetSubstract(point, _pastPoint);
                _choosingShape.Move(delta);
                _pastPoint = point;
            }
        }

        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> shapeList)
        {
        }
    }
}
