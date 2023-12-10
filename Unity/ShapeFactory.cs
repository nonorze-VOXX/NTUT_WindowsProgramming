using System;

namespace Unity
{
    public enum ShapeType
    {
        Line,
        Rectangle,
        Ellipse
    }

    public class ShapeFactory
    {
        /// <summary>
        /// create shape by factory
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Shape CreateByRandom(ShapeType shapeType, int randomMax)
        {
            var zero = 0;
            var random = new Random();
            return CreateShape(shapeType,
                new Point2(random.Next(zero, randomMax), random.Next(zero, randomMax)),
                new Point2(random.Next(zero, randomMax), random.Next(zero, randomMax)));
        }

        /// <summary>
        /// create shape by factory
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Shape CreateShape(ShapeType shapeType, Point2 start, Point2 end)
        {
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(start, end, new Point2(16000, 9000));
                case ShapeType.Rectangle:
                    return new Rectangle(start, end, new Point2(16000, 9000));
                default:
                    return new Ellipse(start, end, new Point2(16000, 9000));
            }
        }
    }
}