using System.ComponentModel;
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
        void MouseDown(ShapeType shapeType, Point point, System.ComponentModel.BindingList<Shape> shapeList, Point nowCanvas);
        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        void MouseMove(Point point, bool pressed, System.ComponentModel.BindingList<Shape> shapes);
        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        void MouseUp(Point point, System.ComponentModel.BindingList<Shape> shapeList, Command.CommandManager commandManager);
        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics, BindingList<Shape> shapes);
        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        void DeletePress(System.ComponentModel.BindingList<Shape> shapeList, Command.CommandManager commandManager);
        /// <summary>
        /// tes
        /// </summary>
        /// <returns></returns>
        bool IsScale(BindingList<Shape> shapes);
        /// <summary>
        /// a
        /// </summary>
        void Reset();

    }
}
