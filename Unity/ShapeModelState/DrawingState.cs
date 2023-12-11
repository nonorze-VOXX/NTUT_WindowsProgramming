﻿using System.Drawing;
using Unity.Command;

namespace Unity.ShapeModelState
{
    class DrawingState : IState
    {
        Shape _hint = new Line(new Point(0, 0), new Point(0, 0), new Point(16000, 9000));
        AddCommand add;

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
        public void Draw(IGraphics graphics)
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
            add = new AddCommand(shapeType, new Point(point.X, point.Y), new Point(0, 0), nowCanvas);
        }

        /// <summary>
        /// set
        /// </summary>
        /// <returns></returns>
        public bool IsScale()
        {
            return false;

        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        public void MouseMove(Point point, bool pressed)
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
            commandManager.AddShape(add);

            _hint = new Line(new Point(0, 0), new Point(0, 0), new Point(16000, 9000));
        }
    }
}
