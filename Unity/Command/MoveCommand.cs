using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Unity.Command
{
    public class MoveCommand : ICommand
    {
        private int v;
        private Point point;
        private Point nowCanvas;
        private List<Point> from;
        private List<Point> to;

        public MoveCommand(int index, Point point, List<Point> points, Point nowCanvas)
        {
            this.v = index;
            this.point = point;
            this.from = points;
            this.nowCanvas = nowCanvas;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public List<Point> GetPastPoints()
        {
            return from;
        }



        /// <summary>
        /// as
        /// </summary>
        /// <param name="points"></param>
        public void SetTarget(List<Point> points)
        {
            to = points;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <param name="shapes"></param>
        public void Execute(BindingList<Shape> shapes)
        {
            shapes[v].SetNowCanvasSize(nowCanvas);
            shapes[v].SetDrawCanvasSize(nowCanvas);
            shapes[v].SetFirst(to[0]);
            shapes[v].SetSecond(to[1]);
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
