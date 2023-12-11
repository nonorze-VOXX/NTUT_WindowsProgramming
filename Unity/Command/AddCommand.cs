using System.ComponentModel;
using System.Drawing;

namespace Unity.Command
{
    public class AddCommand : ICommand
    {
        private ShapeType _shapeType;
        private Point _start;
        private Point _end;
        private Point _nowCanvas;

        public AddCommand(ShapeType shapeType, Point start, Point end, Point nowCanvas)
        {
            this._shapeType = shapeType;
            this._start = start;
            this._end = end;
            this._nowCanvas = nowCanvas;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void Execute(BindingList<Shape> shapes)
        {
            shapes.Add(ShapeFactory.CreateShape(_shapeType, _start, _end, _nowCanvas));
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="point"></param>
        public void SetEnd(Point point)
        {
            _end = point;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void ExecuteNo(BindingList<Shape> shapes)
        {
        }
    }
}
