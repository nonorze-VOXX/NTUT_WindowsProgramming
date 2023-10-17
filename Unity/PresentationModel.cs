using System;

namespace Unity
{
    public class PresentationModel : Interface.IShapeObserver
    {
        private ShapeModel _shapeModel;
        public PresentationModel(ShapeModel shapeModel)
        {
            _shapeModel = shapeModel;
            _shapeModel.Attach(this);
        }
        public void UpdateView()
        {
            throw new NotImplementedException();
        }
    }
}
