﻿using System.Drawing;
namespace Unity
{
    public interface IGraphics
    {
        /// <summary>
        /// draw line
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        void DrawLine(Point2 point1, Point2 point2);
        /// <summary>
        /// draw rectangle
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        void DrawRectangle(Point2 point1, Point2 point2);
        /// <summary>
        /// draw ellipse
        /// </summary>
        /// <param name="first"></param>
        /// <param name="size"></param>
        void DrawEllipseByCenterAndSize(Point2 first, Point2 size);
        /// <summary>
        /// rectangle by color
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="pen"></param>
        void DrawRectangle(Point2 point1, Point2 point2, Pen pen);
        /// <summary>
        /// ellipse
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        void DrawEllipse(Point2 point1, Point2 point2);
    }
}
