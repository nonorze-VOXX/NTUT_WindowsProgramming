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

        public MoveCommand(int v, Point point, List<Point> points, Point nowCanvas)
        {
            this.v = v;
            this.point = point;
            this.from = points;
            this.nowCanvas = nowCanvas;
        }
        public List<Point> GetPastPoints()
        {
            return from;
        }



        internal void SetTarget(List<Point> points)
        {
            to = points;
        }

        public void Excute(BindingList<Shape> shapes)
        {
            shapes[v].SetNowCanvasSize(nowCanvas);
            shapes[v].SetDrawCanvasSize(nowCanvas);
            shapes[v].SetFirst(to[0]);
            shapes[v].SetSecond(to[1]);
        }

        public void Unexcute(BindingList<Shape> shapes)
        {
        }
        public string to_string()
        {
            return "move " + v.ToString();
        }
    }
}
