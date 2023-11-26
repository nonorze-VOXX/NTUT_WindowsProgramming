using System;
using System.Collections.Generic;

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
        protected List<Point2> _info = new List<Point2>();

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
        public virtual bool IsPointIn(Point2 point)
        {
            var firstDistance = Point2.GetDistance(point, GetFirst());
            var secondDistance = Point2.GetDistance(point, GetSecond());
            var shapeDistance = Point2.GetDistance(GetFirst(), GetSecond());
            var (x1, y1) = firstDistance.GetTuple();
            var (x2, y2) = secondDistance.GetTuple();
            var (x3, y3) = shapeDistance.GetTuple();
            return x1 + x2 <= x3 && y1 + y2 <= y3;
        }

        public Shape(Point2 start, Point2 end)
        {
            SetInfo(start, end);
        }

        /// <summary>
        /// set two point at once
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private Shape SetInfo(Point2 start, Point2 end)
        {
            _info.Add(start);
            _info.Add(end);
            return this;
        }

        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public virtual Point2 GetFirst()
        {
            return _info[0];
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="delta"></param>
        public virtual void Move(Point2 delta)
        {
            for (int i = 0; i < _info.Count; i++)
            {
                _info[i] = Point2.Add(_info[i], delta);
            }
        }

        /// <summary>
        /// getter
        /// </summary>
        /// <returns></returns>
        public virtual Point2 GetSecond()
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
        public void SetFirst(Point2 point)
        {
            _info[0] = point;
        }

        /// <summary>
        /// set
        /// </summary>
        /// <param name="point"></param>
        public void SetSecond(Point2 point)
        {
            _info[1] = point;
        }
    }
}