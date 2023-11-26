using System;
using System.Collections.Generic;
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
                List<Point2> list = GetEightpoint(first, second);
                graphics.DrawRectangle(first, second, Pens.Red);
                foreach (var point in list)
                {
                    graphics.DrawEllipseByCenterAndSize(point, _size);
                }
            }
        }
        public List<Point2> GetEightpoint(Point2 first, Point2 second)
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
                foreach (var circle in GetEightpoint(_choosingShape.GetFirst(), _choosingShape.GetSecond()))
                {
                    var distance = Point2.GetDistanceFloat(circle, point);
                    if (distance * 2 < _size.X + _size.Y)
                    {
                        Console.WriteLine("point");
                        _scalePoint = circle;
                        return;
                    }
                }
            }
            _scalePoint = null;
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
                if (_scalePoint != null)
                {
                    var first = _choosingShape.GetFirst();
                    var second = _choosingShape.GetSecond();
                    Point2 compare1 = null;
                    Point2 compare2 = null;
                    if (Point2.GetDistanceFloat(first, _scalePoint) < Point2.GetDistanceFloat(second, _scalePoint))
                    {
                        compare1 = first;
                        compare2 = second;
                    }
                    else
                    {
                        compare1 = second;
                        compare2 = first;
                    }
                    if (compare1.X.Equals(_scalePoint.X))
                    {
                        compare1.X += delta.X;
                        _scalePoint.X = compare1.X;
                    }
                    else if (compare2.X.Equals(_scalePoint.X))
                    {
                        compare2.X += delta.X;
                        _scalePoint.X = compare2.X;
                    }
                    if (compare1.Y.Equals(_scalePoint.Y))
                    {
                        compare1.Y += delta.Y;
                        _scalePoint.Y = compare1.Y;
                    }
                    else if (compare2.Y.Equals(_scalePoint.Y))
                    {
                        compare2.Y += delta.Y;
                        _scalePoint.Y = compare2.Y;
                    }

                    _choosingShape.SetFirst(compare1);
                    _choosingShape.SetSecond(compare2);
                }
                else
                {
                    _choosingShape.Move(delta);
                }
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
