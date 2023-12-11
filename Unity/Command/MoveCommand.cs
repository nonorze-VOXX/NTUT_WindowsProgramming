using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Unity.Command
{
    public class MoveCommand : ICommand
    {
        private int _index;
        private Point _point;
        private Point _nowCanvas;
        private List<Point> _from;
        private List<Point> _to;

        public MoveCommand(int index, Point point, List<Point> points, Point nowCanvas)
        {
            this._index = index;
            this._point = point;
            this._from = points;
            this._nowCanvas = nowCanvas;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public Tuple<Point, Point> GetPastPoints()
        {
            return new Tuple<Point, Point>(_from[0], _from[1]);
        }

        /// <summary>
        /// as
        /// </summary>
        /// <param name="points"></param>
        public void SetTarget(List<Point> points)
        {
            _to = points;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void Execute(BindingList<Shape> shapes)
        {
            shapes[_index].SetNowCanvasSize(_nowCanvas);
            shapes[_index].SetDrawCanvasSize(_nowCanvas);
            shapes[_index].SetFirst(_to[0]);
            shapes[_index].SetSecond(_to[1]);
        }

        /// <summary>
        /// as
        /// </summary>
        /// <param name="shapes"></param>
        public void ExecuteNo(BindingList<Shape> shapes)
        {
        }
    }
}
