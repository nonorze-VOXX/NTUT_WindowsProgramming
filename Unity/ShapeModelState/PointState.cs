using System;
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
        Point _pastPoint = new Point(0, 0);
        Point _scalePoint;

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
                var first = _choosingShape.GetFirst();
                var second = _choosingShape.GetSecond();
                List<Point> list = GetEightPoint(first, second);
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
        public List<Point> GetEightPoint(Point first, Point second)
        {
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
        public void MouseDown(ShapeType shapeType, Point point, System.ComponentModel.BindingList<Shape> shapeList)
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
            foreach (var circle in GetEightPoint(_choosingShape.GetFirst(), _choosingShape.GetSecond()))
            {
                var distance = PointFunction.GetDistanceFloat(circle, _pastPoint);
                var sum = PointFunction.GetSum(_size);
                if (Close(distance, sum))
                {
                    return circle;
                }
            }
            Console.WriteLine(_pastPoint.ToString());
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
                if (_scalePoint != new Point(-1, -1))
                {
                    var (first, second) = _choosingShape.GetLocal();
                    var tuple = ScaleByDelta(delta, first, second);
                    var (first1, second1) = new Tuple<Point, Point>(tuple.Item1, tuple.Item2);
                    _scalePoint = tuple.Item3;
                    _choosingShape.SetPosition(first1, second1);
                }
                else
                {
                    _choosingShape.Move(delta);
                }
            }
            _pastPoint = point;
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private Tuple<Point, Point, Point> ScaleByDelta(Point delta, Point first, Point second)
        {
            var tuple = ScaleX(delta, first, second);
            first = tuple.Item1;
            second = tuple.Item2;
            _scalePoint = tuple.Item3;
            return PointFunction.MoveScaleY(first, second, _scalePoint, delta);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private Tuple<Point, Point, Point> ScaleX(Point delta, Point first, Point second)
        {
            return PointFunction.MoveScaleX(first, second, _scalePoint, delta);
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
