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
        /// <param name="nowPageIndex"></param>
        /// <param name="pages"></param>
        public void AddShape(ShapeType shapeType, Point start, Point end, Point nowCanvas,
            int nowPageIndex, List<BindingList<Shape>> pages)
        {
            var add = new AddCommand(shapeType, start, end, nowCanvas, nowPageIndex);
            _undoStack.Push(add);
            _redoStack.Clear();
            GenerateNowPages(pages);
        }


        /// <summary>
        /// aa
        /// </summary>
        /// <param name="add"></param>
        /// <param name="point"></param>
        /// <param name="pages"></param>
        public void AddShape(AddCommand add, Point point, List<BindingList<Shape>> pages)
        {
            add.SetEnd(point);
            _undoStack.Push(add);
            _redoStack.Clear();
            GenerateNowPages(pages);
        }
        public void AddPage(List<BindingList<Shape>> pages)
        {
            _undoStack.Push(new AddPageCommand());
            _redoStack.Clear();
            GenerateNowPages(pages);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pages"></param>
        public void Delete(int index, List<BindingList<Shape>> pages, int nowPage)
        {
            _undoStack.Push(new DeleteCommand(index, nowPage));
            _redoStack.Clear();
            GenerateNowPages(pages);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="moveCommand"></param>
        /// <param name="points"></param>
        /// <param name="pages"></param>
        /// <param name="choosingIndex"></param>
        public void Move(MoveCommand moveCommand, List<Point> points, List<BindingList<Shape>> pages, int choosingIndex)
        {
            var past = moveCommand.GetPastPoints();
            if (IsSame(points, past))
            {
                return;
            }
            moveCommand.SetTarget(points);
            moveCommand.SetChoosingIndex(choosingIndex);

            _undoStack.Push(moveCommand);
            _redoStack.Clear();
            GenerateNowPages(pages);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="points"></param>
        /// <param name="past"></param>
        /// <returns></returns>
        private static bool IsSame(List<Point> points, System.Tuple<Point, Point> past)
        {
            return past.Item1.Equals(points[0]) && past.Item2.Equals(points[1]);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="pages"></param>
        public void Undo(List<BindingList<Shape>> pages)
        {
            if (_undoStack.Count == 0)
            {
                return;
            }
            _redoStack.Push(_undoStack.Pop());
            GenerateNowPages(pages);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="pages"></param>
        public void Redo(List<BindingList<Shape>> pages)
        {
            if (_redoStack.Count == 0)
            {
                return;
            }
            _undoStack.Push(_redoStack.Pop());
            GenerateNowPages(pages);
        }
        private void GenerateNowPages(List<BindingList<Shape>> pages)
        {
            pages.Clear();
            pages.Add(new BindingList<Shape>());
            var reverseStack = new Stack<ICommand>();
            foreach (var command in _undoStack)
            {
                reverseStack.Push(command);
            }
            foreach (var command in reverseStack)
            {
                command.Execute(pages);
            }
        }

    }
}
