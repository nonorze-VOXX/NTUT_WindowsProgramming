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
        private int _nowPage;

        public MoveCommand(Point point, List<Point> points, Point nowCanvas, int nowPage)
        {
            this._point = point;
            this._from = points;
            this._nowCanvas = nowCanvas;
            this._nowPage = nowPage;
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
        /// <param name="pages"></param>
        public void Execute(List<BindingList<Shape>> pages)
        {
            pages[_nowPage][_index].SetNowCanvasSize(_nowCanvas);
            pages[_nowPage][_index].SetDrawCanvasSize(_nowCanvas);
            pages[_nowPage][_index].SetFirst(_to[0]);
            pages[_nowPage][_index].SetSecond(_to[1]);
        }

        /// <summary>
        /// as
        /// </summary>
        /// <param name="shapes"></param>
        public void ExecuteNo(BindingList<Shape> shapes)
        {
        }

        public void SetChoosingIndex(int choosingIndex)
        {
            _index = choosingIndex;
        }
    }
}
