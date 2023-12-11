using System.ComponentModel;
using System.Drawing;

namespace Unity.Command
{
    public class AddCommand : ICommand
    {
        private ShapeType shapeType;
        private Point start;
        private Point end;
        private Point nowCanvas;

        public AddCommand(ShapeType shapeType, Point start, Point end, Point nowCanvas)
        {
            this.shapeType = shapeType;
            this.start = start;
            this.end = end;
            this.nowCanvas = nowCanvas;
        }

        public void Excute(BindingList<Shape> shapes)
        {
            shapes.Add(ShapeFactory.CreateShape(shapeType, start, end, nowCanvas));
        }

        public void SetEnd(Point point)
        {
            end = point;
        }

        public void Unexcute(BindingList<Shape> shapes)
        {
        }
        public string to_string()
        {
            return "add";
        }
    }
}
