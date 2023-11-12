namespace Unity.ShapeModelState
{
    interface IState
    {
        /// <summary>
        /// down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> shapeList);
        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        void MouseMove(Point2 point);
        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> shapeList);
        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        void DeletePress(System.ComponentModel.BindingList<Shape> shapeList);
    }
}
