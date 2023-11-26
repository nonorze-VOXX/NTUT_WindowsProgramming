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
        /// get xy
        /// </summary>
        /// <returns></returns>
        public Tuple<float, float> GetTuple()
        {
            return new Tuple<float, float>(X, Y);
        }
    }
}