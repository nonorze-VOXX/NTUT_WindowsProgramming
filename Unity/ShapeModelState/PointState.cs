using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

namespace Unity.ShapeModelState
{
    public class PointState : IState
    {
        int _choosingIndex = -1;
        public const int EIGHT_INTEGER = 8;
        public const int TWO_INTEGER = 2;
        Point _size = new Point(EIGHT_INTEGER, EIGHT_INTEGER);
        Point _pastPoint = new Point(-1, -1);
        Point _scalePoint = new Point(-1, -1);
        MoveCommand _moveCommand;

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        public void DeletePress(BindingList<Shape> shapeList, Command.CommandManager commandManager)
        {
            if (_choosingIndex != -1)
            {
                commandManager.Delete(_choosingIndex);
                shapeList.RemoveAt(_choosingIndex);
                _scalePoint = new Point(-1, -1);
                _choosingIndex = -1;
            }
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics, BindingList<Shape> shapes)
        {
            if (_choosingIndex != -1)
            {
                List<Point> points = shapes[_choosingIndex].GetFixedInfo();
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
            var x1 = first.X;
            var y1 = first.Y;
            var x2 = second.X;
            var y2 = second.Y;
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
            if (_choosingIndex != -1)
            {
                _moveCommand = new MoveCommand(_choosingIndex, point, shapeList[_choosingIndex].GetFixedInfo(), nowCanvas);
                _scalePoint = IsWhichCircle(shapeList);
            }
            if (!_scalePoint.Equals(new Point(-1, -1)))
            {
                return;
            }
            _scalePoint = new Point(-1, -1);
            MoveLogic(point, shapeList);
        }

        /// <summary>
        /// cir
        /// </summary>
        /// <returns></returns>
        public Point IsWhichCircle(BindingList<Shape> shapes)
        {
            if (_choosingIndex == -1)
            {
                return new Point(-1, -1);
            }
            foreach (var circle in GetEightPoint(shapes[_choosingIndex].GetFixedInfo()))
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
        public bool IsScale(BindingList<Shape> shapes)
        {
            if (_scalePoint != new Point(-1, -1))
            {
                return true;
            }
            else
            {
                return IsWhichCircle(shapes) != new Point(-1, -1);
            }

        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MoveLogic(Point point, BindingList<Shape> shapeList)
        {
            foreach (var shape in shapeList)
            {
                if (shape.IsPointIn(point))
                {
                    _choosingIndex = shapeList.IndexOf(shape);
                    return;
                }
            }
            _choosingIndex = -1;
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
        public void MouseMove(Point point, bool pressed, BindingList<Shape> shapes)
        {
            if (pressed && _choosingIndex != -1)
            {
                var delta = PointFunction.GetSubstract(point, _pastPoint);
                _pastPoint = point;
                if (_scalePoint != new Point(-1, -1))
                {
                    shapes[_choosingIndex].Scale(_scalePoint, delta);
                    AddButPointState(delta);
                }
                else
                {
                    shapes[_choosingIndex].Move(delta);
                }
            }
            _pastPoint = point;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="delta"></param>
        private void AddButPointState(Point delta)
        {
            _scalePoint = PointFunction.Add(_scalePoint, delta);
        }

        /// <summary>
        /// a
        /// </summary>
        public void SetChoosingIndex(int index)
        {
            _choosingIndex = index;
        }

        /// <summary>
        /// a
        /// </summary>
        public void SetPastPoint(Point point)
        {
            _pastPoint = point;
        }

        /// <summary>
        /// a
        /// </summary>
        public void SetScalePoint(Point point)
        {
            _scalePoint = point;
        }

        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseUp(Point point, System.ComponentModel.BindingList<Shape> shapeList, Command.CommandManager commandManager)
        {
            if (_choosingIndex != -1 && _moveCommand != null)
            {
                commandManager.Move(_moveCommand, shapeList[_choosingIndex].GetFixedInfo());
            }
            _scalePoint = new Point(-1, -1);
        }

        /// <summary>
        /// a
        /// </summary>
        public void Reset()
        {
            _choosingIndex = -1;
        }
    }
}
