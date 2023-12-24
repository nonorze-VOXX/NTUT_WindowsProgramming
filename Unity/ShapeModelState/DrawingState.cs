using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

namespace Unity.ShapeModelState
{
    public class DrawingState : IState
    {
        Shape _hint = new Line(new Point(0, 0), new Point(0, 0), new Point(1, 1));
        AddCommand _add;

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        /// <param name="commandManager"></param>
        /// <param name="nowPage"></param>
        public void DeletePress(List<BindingList<Shape>> shapeList, CommandManager commandManager, int nowPage)
        {
        }


        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics, BindingList<Shape> shapes)
        {
            _hint.Draw(graphics);
        }


        /// <summary>
        /// down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        /// <param name="nowCanvas"></param>
        /// <param name="nowPage"></param>
        public void MouseDown(ShapeType shapeType, Point point, BindingList<Shape> shapeList, Point nowCanvas,
            int nowPage)
        {
            _hint = ShapeFactory.CreateShape(shapeType, new Point(point.X, point.Y), new Point(0, 0), nowCanvas);
            _add = new AddCommand(shapeType, new Point(point.X, point.Y), new Point(0, 0), nowCanvas, nowPage);
        }

        /// <summary>
        /// set
        /// </summary>
        /// <returns></returns>
        public bool IsScale(List<BindingList<Shape>> shapes, int nowPage)
        {
            return false;
        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        public void MouseMove(Point point, bool pressed, BindingList<Shape> shapes)
        {
            if (pressed)
            {
                _hint.SetSecond(point);
            }
        }

        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        /// <param name="commandManager"></param>
        /// <param name="nowPageIndex"></param>
        public void MouseUp(Point point, List<BindingList<Shape>> shapeList, CommandManager commandManager,
            int nowPageIndex)
        {
            _hint.SetSecond(point);
            commandManager.AddShape(_add, point, shapeList);
            _add = null;

            _hint = new Line(new Point(0, 0), new Point(0, 0), new Point(1, 1));
        }

        /// <summary>
        /// a
        /// </summary>
        public void Reset()
        {
        }
    }
}
