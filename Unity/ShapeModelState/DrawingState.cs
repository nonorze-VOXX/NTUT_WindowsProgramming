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
        public void DeletePress(System.ComponentModel.BindingList<Shape> shapeList, Command.CommandManager commandManager)
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
        public void MouseDown(ShapeType shapeType, Point point, System.ComponentModel.BindingList<Shape> shapeList, Point nowCanvas)
        {
            _hint = ShapeFactory.CreateShape(shapeType, new Point(point.X, point.Y), new Point(0, 0), nowCanvas);
            _add = new AddCommand(shapeType, new Point(point.X, point.Y), new Point(0, 0), nowCanvas);
        }

        /// <summary>
        /// set
        /// </summary>
        /// <returns></returns>
        public bool IsScale(BindingList<Shape> shapes)
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
        public void MouseUp(Point point, System.ComponentModel.BindingList<Shape> shapeList, Command.CommandManager commandManager)
        {
            _hint.SetSecond(point);
            shapeList.Add(_hint);
            commandManager.AddShape(_add, point);

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
