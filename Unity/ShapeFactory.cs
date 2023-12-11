using System;
using System.Drawing;

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
        public static Shape CreateByRandom(ShapeType shapeType, int randomMax, Point nowCanvas, Command.CommandManager commandManager)
        {
            var zero = 0;
            var random = new Random();
            var start = new Point(random.Next(zero, randomMax), random.Next(zero, randomMax));
            var end =
                new Point(random.Next(zero, randomMax), random.Next(zero, randomMax));
            commandManager.AddShape(shapeType, start, end, nowCanvas);
            return CreateShape(shapeType, start, end, nowCanvas); ;
        }

        /// <summary>
        /// create shape by factory
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Shape CreateShape(ShapeType shapeType, Point start, Point end, Point nowCanvas)
        {
            switch (shapeType)
            {
                case ShapeType.Line:
                    return new Line(start, end, nowCanvas);
                case ShapeType.Rectangle:
                    return new Rectangle(start, end, nowCanvas);
                default:
                    return new Ellipse(start, end, nowCanvas);
            }
        }
    }
}