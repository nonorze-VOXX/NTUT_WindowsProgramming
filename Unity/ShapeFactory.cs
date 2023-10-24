﻿using System;

namespace Unity
{
    public enum ShapeType
    {
        Line,
        Rectangle,
        Ellipse
    }

    internal class ShapeFactory
    {
        /// <summary>
        /// create shape by factory
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static Shape CreateByRandom(ShapeType shapeType)
        {
            var zero = 0;
            var max = 400;
            var random = new Random();
            return CreateShape(shapeType,
                new Point2(random.Next(zero, max), random.Next(zero, max)),
                new Point2(random.Next(zero, max), random.Next(zero, max)));
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
                    return new Line(start, end);
                case ShapeType.Rectangle:
                    return new Rectangle(start, end);
                case ShapeType.Ellipse:
                    return new Ellipse(start, end);
                default:
                    return null;
            }
        }
    }
}