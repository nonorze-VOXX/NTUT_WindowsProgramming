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
        protected Point _drawCanvasSize = new Point(1, 1);
        protected Point _nowCanvasSize = new Point(1, 1);

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

        /// <summary>
        /// a
        /// </summary>
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
            Point firstDistance = GetFirstDistance(point);
            Point secondDistance = GetSecondDistance(point);
            Point shapeDistance = GetShapeDistance();
            return firstDistance.X + secondDistance.X <= shapeDistance.X && firstDistance.Y + secondDistance.Y <= shapeDistance.Y;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private Point GetShapeDistance()
        {
            return PointFunction.GetDistance(GetFirst(), GetSecond());
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private Point GetSecondDistance(Point point)
        {
            return PointFunction.GetDistance(point, GetFixedInfo()[1]);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private Point GetFirstDistance(Point point)
        {
            return PointFunction.GetDistance(point, GetFixedInfo()[0]);
        }

        public Shape(Point start, Point end, Point canvas)
        {
            SetInfo(start, end);
            _drawCanvasSize = canvas;
            _nowCanvasSize = canvas;
        }

        /// <summary>
        /// a
        /// </summary>
        public void SetNowCanvasSize(Point canvas)
        {
            _nowCanvasSize = canvas;
        }

        /// <summary>
        /// a
        /// </summary>
        public void SetDrawCanvasSize(Point canvas)
        {
            _drawCanvasSize = canvas;
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
        /// a
        /// </summary>
        public virtual void Scale(Point scalePoint, Point delta)
        {
            var info = GetFixedInfo();
            Move(new Point(0, 0));
            ScaleX(ref scalePoint, ref delta, info);
            if (info[0].Y.Equals(scalePoint.Y))
            {
                _info[0] = new Point(_info[0].X, scalePoint.Y + delta.Y);
            }
            else if (info[1].Y.Equals(scalePoint.Y))
            {
                _info[1] = new Point(_info[1].X, scalePoint.Y + delta.Y);
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="scalePoint"></param>
        /// <param name="delta"></param>
        /// <param name="info"></param>
        private void ScaleX(ref Point scalePoint, ref Point delta, List<Point> info)
        {
            if (info[0].X.Equals(scalePoint.X))
            {
                _info[0] = new Point(scalePoint.X + delta.X, _info[0].Y);
            }
            else if (info[1].X.Equals(scalePoint.X))
            {
                _info[1] = new Point(scalePoint.X + delta.X, _info[1].Y);
            }
        }

        public string Serializable()
        {
            return GetShapeName() + ","
                             + _info[0].X + "," + _info[0].Y + ","
                             + _info[1].X + "," + _info[1].Y + ","
                             + _drawCanvasSize.X + "," + _drawCanvasSize.Y + "\n";
        }
    }
}