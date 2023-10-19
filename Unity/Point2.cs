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
        /// get point2 of abs
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        internal static Point2 GetDistance(Point2 point1, Point2 point2)
        {
            return new Point2(Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
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
        internal bool IsBothPositive()
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