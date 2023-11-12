namespace Unity.ShapeModelState
{
    interface IState
    {
        void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> _shapeList);
        void MouseMove(Point2 point);
        void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> _shapeList);
        void draw(IGraphics graphics);
    }
}
