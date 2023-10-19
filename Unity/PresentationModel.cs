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

        internal void ClickDrawButton(List<System.Windows.Forms.ToolStripItem> toolStripItems, ShapeType shapeType)
        {
            toolbarActive = new List<bool> { false, false, false };
            toolbarActive[(int)shapeType] = true;
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                var toolStripButton = (System.Windows.Forms.ToolStripButton)toolStripItems[i];
                toolStripButton.Checked = toolbarActive[i];
            }
        }
    }
}
