namespace Unity
{
    public class PresentationModel
    {
        ShapeModel _model;
        public PresentationModel(ShapeModel model)
        {
            _model = model;
        }
        public void Draw(System.Drawing.Graphics graphics)
        {
            var graphicsAdaptor = new WindowFormsGraphicsAdaptor(graphics);
            _model.Draw(graphicsAdaptor);
        }

    }
}
