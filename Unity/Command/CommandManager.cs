using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Drawing;

namespace Unity.Command
{
    public class CommandManager
    {
        Stack<ICommand> _undoStack = new Stack<ICommand>();
        Stack<ICommand> _redoStack = new Stack<ICommand>();
        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="nowCanvas"></param>
        public void AddShape(ShapeType shapeType, Point start, Point end, Point nowCanvas)
        {
            var add = new AddCommand(shapeType, start, end, nowCanvas);
            _undoStack.Push(add);
            _redoStack.Clear();
        }

        /// <summary>
        /// aa
        /// </summary>
        /// <param name="add"></param>
        /// <param name="point"></param>
        public void AddShape(AddCommand add, Point point)
        {
            add.SetEnd(point);
            _undoStack.Push(add);
            _redoStack.Clear();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            _undoStack.Push(new DeleteCommand(index));
            _redoStack.Clear();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="moveCommand"></param>
        /// <param name="points"></param>
        public void Move(MoveCommand moveCommand, List<Point> points)
        {
            var past = moveCommand.GetPastPoints();
            if (past[0].Equals(points[0]) && past[1].Equals(points[1]))
            {
                return;
            }
            moveCommand.SetTarget(points);

            _undoStack.Push(moveCommand);
            _redoStack.Clear();

            var reverseStack = new Stack<ICommand>();
            foreach (var command in _undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
            }
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void Undo(BindingList<Shape> shapes)
        {
            if (_undoStack.Count == 0)
            {
                return;
            }
            shapes.Clear();
            _redoStack.Push(_undoStack.Pop());
            var reverseStack = new Stack<ICommand>();
            foreach (var command in _undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
                command.Execute(shapes);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void Redo(BindingList<Shape> shapes)
        {
            if (_redoStack.Count == 0)
            {
                return;
            }
            shapes.Clear();
            _undoStack.Push(_redoStack.Pop());
            var reverseStack = new Stack<ICommand>();
            foreach (var command in _undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
                command.Execute(shapes);
            }
        }
    }
}
