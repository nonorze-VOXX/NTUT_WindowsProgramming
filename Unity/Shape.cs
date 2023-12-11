using System;
using System.Collections.Generic;
using System.Drawing;

namespace Unity
{
    public abstract class Shape
    {
        private const string COMMA = ",";
        private const string EMPTY = " ";
        public string shape
        {
            get
            {
                return GetShapeName();
            }
        }
        protected List<Point> _info = new List<Point>();
        protected Point _canvasSize = new Point(16000, 9000);

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(IGraphics graphics);

        public string Information
        {
            get
            {
                return string.Join(COMMA + EMPTY, _info);
            }
        }

        /// <summary>
        /// in
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual bool IsPointIn(Point point)
        {
            var firstDistance = PointFunction.GetDistance(point, GetFirst());
            var secondDistance = PointFunction.GetDistance(point, GetSecond());
            var shapeDistance = PointFunction.GetDistance(GetFirst(), GetSecond());
            var (x1, y1) = (firstDistance.X, firstDistance.Y);
            var (x2, y2) = (secondDistance.X, secondDistance.Y);
            var (x3, y3) = (shapeDistance.X, shapeDistance.Y);
            return x1 + x2 <= x3 && y1 + y2 <= y3;
        }

        public Shape(Point start, Point end, Point canvas)
        {
            SetInfo(start, end);
            _canvasSize = canvas;
        }

        private void SetCanvasSize(Point canvas)
        {
            _canvasSize = canvas;
        }

        /// <summary>
        /// set two point at once
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Shape SetInfo(Point start, Point end)
        {
            _info.Add(start);
            _info.Add(end);
            return this;
        }

        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public virtual Point GetFirst()
        {
            return _info[0];
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Move(Point delta)
        {
            for (int i = 0; i < _info.Count; i++)
            {
                _info[i] = PointFunction.Add(_info[i], delta);
            }
        }

        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public virtual Point GetSecond()
        {
            return _info[1];
        }

        /// <summary>
        /// get info but string
        /// </summary>
        /// <returns></returns>
        public virtual string GetInfoString()
        {
            string result = "";
            foreach (var i in _info)
            {
                result += i.ToString();
            }
            return result;
        }

        /// <summary>
        /// get shape name string
        /// </summary>
        /// <returns></returns>
        public abstract string GetShapeName();

        /// <summary>
        /// set
        /// </summary>
        /// <param name="point"></param>
        public void SetFirst(Point point)
        {
            _info[0] = point;
        }

        /// <summary>
        /// set
        /// </summary>
        /// <param name="point"></param>
        public void SetSecond(Point point)
        {
            _info[1] = point;
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        internal void SetPosition(Point first, Point second)
        {
            SetFirst(first);
            SetSecond(second);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <returns></returns>
        internal Tuple<Point, Point> GetLocal()
        {
            return new Tuple<Point, Point>(GetFirst(), GetSecond());
        }
    }
}