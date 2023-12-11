using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Unity.ShapeModelState
{
    public class PointState : IState
    {
        Shape _choosingShape = null;
        public const int EIGHT_INTEGER = 8;
        public const int TWO_INTEGER = 2;
        Point _size = new Point(EIGHT_INTEGER, EIGHT_INTEGER);
        Point _pastPoint = new Point(-1, -1);
        Point _scalePoint = new Point(-1, -1);

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        public void DeletePress(System.ComponentModel.BindingList<Shape> shapeList)
        {
            if (_choosingShape != null)
            {
                shapeList.Remove(_choosingShape);
                _scalePoint = new Point(-1, -1);
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

                List<Point> points = _choosingShape.GetFixedInfo();
                var first = points[0];
                var second = points[1];
                List<Point> list = GetEightPoint(points);
                graphics.DrawRectangle(first, second, Pens.Red);
                foreach (var point in list)
                {
                    graphics.DrawEllipseByCenterAndSize(point, _size);
                }
            }
        }

        /// <summary>
        /// scael
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public List<Point> GetEightPoint(List<Point> points)
        {
            var first = points[0];
            var second = points[1];
            var (x1, y1) = (first.X, first.Y);
            var (x2, y2) = (second.X, second.Y);
            List<Point> list = new List<Point>();
            list.Add(second);
            list.Add(first);
            list.Add(new Point(x1, y2));
            list.Add(new Point(x2, y1));
            list.Add(new Point(x1, (y1 + y2) / TWO_INTEGER));
            list.Add(new Point(x2, (y1 + y2) / TWO_INTEGER));
            list.Add(new Point((x1 + x2) / TWO_INTEGER, y1));
            list.Add(new Point((x1 + x2) / TWO_INTEGER, y2));
            return list;
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseDown(ShapeType shapeType, Point point, System.ComponentModel.BindingList<Shape> shapeList, Point nowCanvas)
        {
            _pastPoint = point;
            if (_choosingShape != null)
            {
                _scalePoint = IsWhichCircle();
                if (!_scalePoint.Equals(new Point(-1, -1)))
                {
                    return;
                }
            }
            _scalePoint = new Point(-1, -1);
            MoveLogic(point, shapeList);
        }

        /// <summary>
        /// cir
        /// </summary>
        /// <returns></returns>
        public Point IsWhichCircle()
        {
            if (_choosingShape == null)
            {
                return new Point(-1, -1);
            }
            foreach (var circle in GetEightPoint(_choosingShape.GetFixedInfo()))
            {
                var distance = PointFunction.GetDistanceFloat(circle, _pastPoint);
                var sum = PointFunction.GetSum(_size);
                if (Close(distance, sum))
                {
                    return circle;
                }
            }
            return new Point(-1, -1);
        }

        /// <summary>
        /// set
        /// </summary>
        public bool IsScale()
        {
            if (_scalePoint != new Point(-1, -1))
            {
                return true;
            }
            else
            {
                return IsWhichCircle() != new Point(-1, -1);
            }

        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        private void MoveLogic(Point point, BindingList<Shape> shapeList)
        {
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
        /// sclae
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        private bool Close(float distance, float sum)
        {
            return distance * (1 + 1) < sum;
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        public void MouseMove(Point point, bool pressed)
        {
            if (pressed && _choosingShape != null)
            {
                var delta = PointFunction.GetSubstract(point, _pastPoint);
                _pastPoint = point;
                if (_scalePoint != new Point(-1, -1))
                {
                    _choosingShape.Scale(_scalePoint, delta);
                    _scalePoint = PointFunction.Add(_scalePoint, delta);
                }
                else
                {
                    _choosingShape.Move(delta);
                }
            }
            _pastPoint = point;
        }


        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseUp(Point point, System.ComponentModel.BindingList<Shape> shapeList)
        {
            _scalePoint = new Point(-1, -1);
        }
    }
}
