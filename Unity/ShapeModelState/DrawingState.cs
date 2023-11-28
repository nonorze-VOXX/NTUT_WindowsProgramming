namespace Unity.ShapeModelState
{
    class DrawingState : IState
    {
        Shape _hint = new Line(new Point2(0, 0), new Point2(0, 0));

        /// <summary>
        /// delete
        /// </summary>
        /// <param name="shapeList"></param>
        public void DeletePress(System.ComponentModel.BindingList<Shape> shapeList)
        {
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics)
        {
            _hint.Draw(graphics);
        }

        public Point2 IsWhichCircle()
        {
            return null;
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseDown(ShapeType shapeType, Point2 point, System.ComponentModel.BindingList<Shape> shapeList)
        {
            _hint = ShapeFactory.CreateShape(shapeType, new Point2(point.X, point.Y), new Point2(0, 0));
        }
        public bool IsScale()
        {
            return false;

        }

        /// <summary>
        /// move
        /// </summary>
        /// <param name="point"></param>
        public void MouseMove(Point2 point, bool pressed)
        {
            if (pressed)
            {
                _hint.SetSecond(point);
            }
        }

        /// <summary>
        /// up
        /// </summary>
        /// <param name="point"></param>
        /// <param name="shapeList"></param>
        public void MouseUp(Point2 point, System.ComponentModel.BindingList<Shape> shapeList)
        {
            _hint.SetSecond(point);
            shapeList.Add(_hint);
            _hint = new Line(new Point2(0, 0), new Point2(0, 0));
        }
    }
}
