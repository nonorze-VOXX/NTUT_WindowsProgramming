using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

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
        /// <param name="nowCanvas"></param>
        /// <param name="nowPage"></param>
        void MouseDown(ShapeType shapeType, Point point, BindingList<Shape> shapeList, Point nowCanvas, int nowPage);
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
        /// <param name="commandManager"></param>
        /// <param name="nowPageIndex"></param>
        void MouseUp(Point point, List<BindingList<Shape>> shapeList, CommandManager commandManager, int nowPageIndex);
        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        void Draw(IGraphics graphics, BindingList<Shape> shapes);

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        /// <param name="commandManager"></param>
        /// <param name="nowPage"></param>
        void DeletePress(List<BindingList<Shape>> shapeList, CommandManager commandManager, int nowPage);
        /// <summary>
        /// tes
        /// </summary>
        /// <returns></returns>
        bool IsScale(List<BindingList<Shape>> shapes, int nowPage);
        /// <summary>
        /// a
        /// </summary>
        void Reset();
    }
}
