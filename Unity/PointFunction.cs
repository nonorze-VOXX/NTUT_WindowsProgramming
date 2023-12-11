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

        /// <summary>
        /// a
        /// </summary>
        internal static Point Translate(Point point, Point from, Point to)
        {
            float x1 = (float)to.X / (float)from.X;
            float x2 = (float)point.X * x1;
            float y1 = (float)to.Y / (float)from.Y;
            float y2 = (float)point.Y * y1;
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

    }
}