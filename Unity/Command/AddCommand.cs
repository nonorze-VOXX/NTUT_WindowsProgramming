using System.Collections.Generic;
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
        private int nowPageIndex;

        public AddCommand(ShapeType shapeType, Point start, Point end, Point nowCanvas, int nowPageIndex)
        {
            this._shapeType = shapeType;
            this._start = start;
            this._end = end;
            this._nowCanvas = nowCanvas;
            this.nowPageIndex = nowPageIndex;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="pages"></param>
        public void Execute(List<BindingList<Shape>> pages)
        {
            pages[nowPageIndex].Add(ShapeFactory.CreateShape(_shapeType, _start, _end, _nowCanvas));
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
