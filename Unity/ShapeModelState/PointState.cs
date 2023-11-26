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
        Point2 _size = new Point2(EIGHT_INTEGER, EIGHT_INTEGER);
        Point2 _pastPoint = new Point2(0, 0);
        Point2 _scalePoint;

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
                var second = _choosingShape.GetSecond();
                List<Point2> list = GetEightPoint(first, second);
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
        public List<Point2> GetEightPoint(Point2 first, Point2 second)
        {
            var (x1, y1) = first.GetTuple();
            var (x2, y2) = second.GetTuple();
            List<Point2> list = new List<Point2>();
            list.Add(second);
            list.Add(first);
            list.Add(new Point2(x1, y2));
            list.Add(new Point2(x2, y1));
            list.Add(new Point2(x1, (y1 + y2) / TWO_INTEGER));
            list.Add(new Point2(x2, (y1 + y2) / TWO_INTEGER));
            list.Add(new Point2((x1 + x2) / TWO_INTEGER, y1));
            list.Add(new Point2((x1 + x2) / TWO_INTEGER, y2));
            return list;
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
            if (_choosingShape != null)
            {
                foreach (var circle in GetEightPoint(_choosingShape.GetFirst(), _choosingShape.GetSecond()))
                {
                    var distance = Point2.GetDistanceFloat(circle, point);
                    var sum = _size.GetSum();
                    if (Close(distance, sum))
                    {
                        _scalePoint = circle;
                        return;
                    }
                }
            }
            _scalePoint = null;
            MoveLogic(point, shapeList);
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        private void MoveLogic(Point2 point, BindingList<Shape> shapeList)
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
        public void MouseMove(Point2 point)
        {
            if (_choosingShape != null)
            {
                var delta = Point2.GetSubstract(point, _pastPoint);
                if (_scalePoint != null)
                {
                    var (first, second) = _choosingShape.GetLocal();
                    var tuple = ScaleByDelta(delta, first, second);
                    var (first1, second1) = new Tuple<Point2, Point2>(tuple.Item1, tuple.Item2);
                    _scalePoint = tuple.Item3;
                    _choosingShape.SetPosition(first1, second1);
                }
                else
                {
                    _choosingShape.Move(delta);
                }
                _pastPoint = point;
            }
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private Tuple<Point2, Point2, Point2> ScaleByDelta(Point2 delta, Point2 first, Point2 second)
        {
            var tuple = ScaleX(delta, first, second);
            first = tuple.Item1;
            second = tuple.Item2;
            _scalePoint = tuple.Item3;
            return Point2.MoveScaleY(first, second, _scalePoint, delta);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private Tuple<Point2, Point2, Point2> ScaleX(Point2 delta, Point2 first, Point2 second)
        {
            return Point2.MoveScaleX(first, second, _scalePoint, delta);
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
