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
        protected Point _drawCanvasSize = new Point(16000, 9000);
        protected Point _nowCanvasSize = new Point(16000, 9000);

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public abstract void Draw(IGraphics graphics);

        public string Information
        {
            get
            {
                List<Point> info = GetFixedInfo();
                return string.Join(COMMA + EMPTY, info);
            }
        }
        public List<Point> GetFixedInfo()
        {
            List<Point> info = new List<Point>();
            info.Add(PointFunction.Translate(_info[0], _drawCanvasSize, _nowCanvasSize));
            info.Add(PointFunction.Translate(_info[1], _drawCanvasSize, _nowCanvasSize));
            return info;

        }

        /// <summary>
        /// in
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public virtual bool IsPointIn(Point point)
        {
            var firstDistance = PointFunction.GetDistance(point, GetFixedInfo()[0]);
            var secondDistance = PointFunction.GetDistance(point, GetFixedInfo()[1]);
            var shapeDistance = PointFunction.GetDistance(GetFirst(), GetSecond());
            var (x1, y1) = (firstDistance.X, firstDistance.Y);
            var (x2, y2) = (secondDistance.X, secondDistance.Y);
            var (x3, y3) = (shapeDistance.X, shapeDistance.Y);
            return x1 + x2 <= x3 && y1 + y2 <= y3;
        }

        public Shape(Point start, Point end, Point canvas)
        {
            SetInfo(start, end);
            _drawCanvasSize = canvas;
            _nowCanvasSize = canvas;
        }

        public void SetNowCanvasSize(Point canvas)
        {
            _nowCanvasSize = canvas;
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
            _info[0] = PointFunction.Add(GetFixedInfo()[0], delta);
            _info[1] = PointFunction.Add(GetFixedInfo()[1], delta);
            _drawCanvasSize = _nowCanvasSize;
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
        /// <returns></returns>
        internal Tuple<Point, Point> GetLocal()
        {
            return new Tuple<Point, Point>(GetFirst(), GetSecond());
        }

        internal void Scale(Point scalePoint, Point delta)
        {
            var info = GetFixedInfo();
            Move(new Point(0, 0));
            if (info[0].X.Equals(scalePoint.X))
            {
                _info[0] = new Point(scalePoint.X + delta.X, _info[0].Y);
            }
            else
            if (info[1].X.Equals(scalePoint.X))
            {
                _info[1] = new Point(scalePoint.X + delta.X, _info[1].Y);
            }
            if (info[0].Y.Equals(scalePoint.Y))
            {
                _info[0] = new Point(_info[0].X, scalePoint.Y + delta.Y);
            }
            else
            if (info[1].Y.Equals(scalePoint.Y))
            {
                _info[1] = new Point(_info[1].X, scalePoint.Y + delta.Y);
            }
        }
    }
}