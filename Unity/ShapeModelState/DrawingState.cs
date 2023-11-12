namespace Unity.ShapeModelState
{
    class DrawingState : IState
    {
        Shape _hint = new Line(new Point2(0, 0), new Point2(0, 0));

        public void DeletePress(System.ComponentModel.BindingList<Shape> shapeList)
        {
        }

        public void draw(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        public void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> _shapeList)
        {
            _hint = ShapeFactory.CreateShape(shapeType, new Point2(point.X, point.Y), new Point2(0, 0));
        }

        public void MouseMove(Point2 point)
        {
            _hint.SetSecond(point);
        }

        public void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> _shapeList)
        {
            _hint.SetSecond(point);
            _shapeList.Add(_hint);
            _hint = new Line(new Point2(0, 0), new Point2(0, 0));
        }
    }
}
