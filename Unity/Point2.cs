using System;

namespace Unity
{
    public class Point2
    {
        private float _first;
        private float _second;
        private const string ROUND_BRACKET_LEFT = "(";
        private const string ROUND_BRACKET_RIGHT = ")";
        private const string COMMA = ",";

        public float X
        {
            get
            {
                return _first;
            }
            set
            {
                _first = value;
            }
        }

        public float Y
        {
            get
            {
                return _second;
            }
            set
            {
                _second = value;
            }
        }

        public Point2(float first, float second)
        {
            _first = first;
            _second = second;
        }

        /// <summary>
        /// sub
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point2 GetSubstract(Point2 point1, Point2 point2)
        {
            return new Point2(point1.X - point2.X, point1.Y - point2.Y);
        }

        /// <summary>
        /// div
        /// </summary>
        /// <param name="point"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Point2 Divide(Point2 point, int number)
        {
            return new Point2(point.X / number, point.Y / number);
        }

        /// <summary>
        /// get point2 of abs
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point2 GetDistance(Point2 point1, Point2 point2)
        {
            return new Point2(Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
        }

        /// <summary>
        /// float
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float GetDistanceFloat(Point2 point1, Point2 point2)
        {
            var compare1 = point1.X - point2.X;
            var compare2 = point1.Y - point2.Y;
            return (float)Math.Sqrt(compare1 * compare1 + compare2 * compare2);
        }

        /// <summary>
        /// add
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point2 Add(Point2 point1, Point2 point2)
        {
            return new Point2(point1.X + point2.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// addY
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public Point2 AddY(Point2 point2)
        {
            return new Point2(X, Y + point2.Y);
        }

        /// <summary>
        /// add
        /// </summary>
        /// <param name="point2"></param>
        /// <returns></returns>
        public Point2 AddX(Point2 point2)
        {
            return new Point2(X + point2.X, Y);
        }

        /// <summary>
        /// sum
        /// </summary>
        /// <returns></returns>
        internal float GetSum()
        {
            return X + Y;
        }

        /// <summary>
        /// Normal To String
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ROUND_BRACKET_LEFT + _first + COMMA + _second + ROUND_BRACKET_RIGHT;
        }

        /// <summary>
        /// return if both positive
        /// </summary>
        /// <returns></returns>
        public bool IsBothPositive()
        {
            return X > 0 && Y > 0;
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        internal static bool IsFirstCloserX(Point2 scale, Point2 first, Point2 second)
        {
            return Math.Abs(scale.X - first.X) < Math.Abs(scale.X - second.X);
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="scalePoint"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static Tuple<Point2, Point2, Point2> MoveScaleX(Point2 first, Point2 second, Point2 scalePoint, Point2 delta)
        {
            if (Point2.IsFirstCloserX(scalePoint, first, second))
            {
                if (first.EqualsFirst(scalePoint))
                {
                    first = first.AddX(delta);
                    scalePoint = scalePoint.AddX(delta);
                }
            }
            else
            {
                if (second.EqualsFirst(scalePoint))
                {
                    second = second.AddX(delta);
                    scalePoint = scalePoint.AddX(delta);
                }
            }
            return new Tuple<Point2, Point2, Point2>(first, second, scalePoint);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="scalePoint"></param>
        /// <returns></returns>
        internal bool EqualsFirst(Point2 scalePoint)
        {
            return X.Equals(scalePoint.X);
        }

        /// <summary>
        /// sclae
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        internal static bool IsFirstCloserY(Point2 scale, Point2 first, Point2 second)
        {
            return Math.Abs(scale.Y - first.Y) < Math.Abs(scale.Y - second.Y);
        }

        /// <summary>
        /// get xy
        /// </summary>
        /// <returns></returns>
        public Tuple<float, float> GetTuple()
        {
            return new Tuple<float, float>(X, Y);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="scalePoint"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        internal static Tuple<Point2, Point2, Point2> MoveScaleY(Point2 first, Point2 second, Point2 scalePoint, Point2 delta)
        {
            if (Point2.IsFirstCloserY(scalePoint, first, second))
            {
                if (first.EqualsY(scalePoint))
                {
                    first = first.AddY(delta);
                    scalePoint = scalePoint.AddY(delta);
                }
            }
            else
            {
                if (second.EqualsY(scalePoint))
                {
                    second = second.AddY(delta);
                    scalePoint = scalePoint.AddY(delta);
                }
            }
            return new Tuple<Point2, Point2, Point2>(first, second, scalePoint);
        }

        /// <summary>
        /// sclae
        /// </summary>
        /// <param name="scalePoint"></param>
        /// <returns></returns>
        internal bool EqualsY(Point2 scalePoint)
        {
            return Y.Equals(scalePoint.Y);
        }
    }
}