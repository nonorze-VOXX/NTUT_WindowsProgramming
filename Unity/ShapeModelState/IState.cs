using System.Drawing;

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
        void MouseDown(ShapeType shapeType, Point point, System.ComponentModel.BindingList<Shape> shapeList);
        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        void MouseMove(Point point, bool isPress);
        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        void MouseUp(Point point, System.ComponentModel.BindingList<Shape> shapeList);
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
        /// <summary>
        /// tes
        /// </summary>
        /// <returns></returns>
        bool IsScale();
    }
}
