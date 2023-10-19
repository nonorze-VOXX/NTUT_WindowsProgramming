using System.Collections.Generic;

namespace Unity
{
    public class PresentationModel
    {
        ShapeModel _model;
        List<bool> toolbarActive;
        public PresentationModel(ShapeModel model)
        {
            _model = model;
            toolbarActive = new List<bool> { false, false, false };
        }
        public void Draw(System.Drawing.Graphics graphics)
        {
            var graphicsAdaptor = new WindowFormsGraphicsAdaptor(graphics);
            _model.Draw(graphicsAdaptor);
        }

        internal void ClickDrawButton(ShapeType shapeType)
        {
            toolbarActive = new List<bool> { false, false, false };
        }
    }
}
