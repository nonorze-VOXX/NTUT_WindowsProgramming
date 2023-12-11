using System;
using System.Drawing;

namespace Unity
{
    public class PointFunction
    {
        /// <summary>
        /// sub
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point GetSubstract(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        /// <summary>
        /// div
        /// </summary>
        /// <param name="point"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public static Point Divide(Point point, int number)
        {
            return new Point(point.X / number, point.Y / number);
        }

        internal static Point Translate(Point point, Point from, Point to)
        {
            float x1 = (float)point.X / (float)from.X;
            float x2 = x1 * (float)to.X;
            float y1 = (float)point.Y / (float)from.Y;
            float y2 = y1 * (float)to.Y;
            return new Point((int)x2, (int)y2);
        }

        /// <summary>
        /// get point2 of abs
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point GetDistance(Point point1, Point point2)
        {
            return new Point(Math.Abs(point1.X - point2.X), Math.Abs(point1.Y - point2.Y));
        }

        /// <summary>
        /// float
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static float GetDistanceFloat(Point point1, Point point2)
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
        public static Point Add(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// addY
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point AddY(Point point1, Point point2)
        {
            return new Point(point1.X, point1.Y + point2.Y);
        }

        /// <summary>
        /// add
        /// </summary>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static Point AddX(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y);
        }

        /// <summary>
        /// sum
        /// </summary>
        /// <returns></returns>
        internal static float GetSum(Point point)
        {
            return point.X + point.Y;
        }

        /// <summary>
        /// return if both positive
        /// </summary>
        /// <returns></returns>
        public static bool IsBothNotNegative(Point point)
        {
            return point.X >= 0 && point.Y >= 0;
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        internal static bool IsFirstCloserX(Point scale, Point first, Point second)
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
        public static Tuple<Point, Point, Point> MoveScaleX(Point first, Point second, Point scalePoint, Point delta)
        {
            if (PointFunction.IsFirstCloserX(scalePoint, first, second))
            {
                if (EqualsFirst(first, scalePoint))
                {
                    first = AddX(first, delta);
                    scalePoint = AddX(scalePoint, delta);
                }
            }
            else
            {
                if (EqualsFirst(second, scalePoint))
                {
                    second = AddX(second, delta);
                    scalePoint = AddX(scalePoint, delta);
                }
            }
            return new Tuple<Point, Point, Point>(first, second, scalePoint);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="scalePoint"></param>
        /// <returns></returns>
        internal static bool EqualsFirst(Point point, Point scalePoint)
        {
            return point.X.Equals(scalePoint.X);
        }

        /// <summary>
        /// sclae
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        internal static bool IsFirstCloserY(Point scale, Point first, Point second)
        {
            return Math.Abs(scale.Y - first.Y) < Math.Abs(scale.Y - second.Y);
        }

        /// <summary>
        /// scale
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="scalePoint"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        internal static Tuple<Point, Point, Point> MoveScaleY(Point first, Point second, Point scalePoint, Point delta)
        {
            if (PointFunction.IsFirstCloserY(scalePoint, first, second))
            {
                if (EqualsY(first, scalePoint))
                {
                    first = AddY(first, delta);
                    scalePoint = AddY(scalePoint, delta);
                }
            }
            else
            {
                if (EqualsY(second, scalePoint))
                {
                    second = AddY(second, delta);
                    scalePoint = AddY(scalePoint, delta);
                }
            }
            return new Tuple<Point, Point, Point>(first, second, scalePoint);
        }

        /// <summary>
        /// sclae
        /// </summary>
        /// <param name="scalePoint"></param>
        /// <returns></returns>
        internal static bool EqualsY(Point point, Point scalePoint)
        {
            return point.Y.Equals(scalePoint.Y);
        }
    }
}