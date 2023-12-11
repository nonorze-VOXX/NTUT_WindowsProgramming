using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Drawing;

namespace Unity.Command
{
    public class CommandManager
    {
        Stack<ICommand> undoStack = new Stack<ICommand>();
        Stack<ICommand> redoStack = new Stack<ICommand>();
        public void AddShape(ShapeType shapeType, Point start, Point end, Point nowCanvas)
        {
            var add = new AddCommand(shapeType, start, end, nowCanvas);
            undoStack.Push(add);
            redoStack.Clear();
        }
        public void AddShape(AddCommand add)
        {
            undoStack.Push(add);
            redoStack.Clear();
        }

        internal void Delete(int v)
        {
            undoStack.Push(new DeleteCommand(v));
            redoStack.Clear();
        }

        internal void Move(MoveCommand moveCommand, List<Point> points)
        {
            var past = moveCommand.GetPastPoints();
            if (past[0].Equals(points[0]) && past[1].Equals(points[1]))
            {
                return;
            }
            moveCommand.SetTarget(points);

            undoStack.Push(moveCommand);
            redoStack.Clear();

            Console.WriteLine("MOve commadn");
            var reverseStack = new Stack<ICommand>();
            foreach (var command in undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
                Console.WriteLine(command.to_string());
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void Undo(BindingList<Shape> shapes)
        {
            if (undoStack.Count == 0)
            {
                return;
            }
            shapes.Clear();
            redoStack.Push(undoStack.Pop());
            var reverseStack = new Stack<ICommand>();
            foreach (var command in undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
                Console.WriteLine(command.to_string());
                command.Excute(shapes);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public void Redo(BindingList<Shape> shapes)
        {
            if (redoStack.Count == 0)
            {
                return;
            }
            shapes.Clear();
            undoStack.Push(redoStack.Pop());
            var reverseStack = new Stack<ICommand>();
            foreach (var command in undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
                command.Excute(shapes);
            }
        }
    }
}
