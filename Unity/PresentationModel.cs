using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using ButtonFunction = System.Action<object, System.EventArgs>;
namespace Unity
{
    public class PresentationModel
    {
        ShapeModel _shapeModel;
        List<bool> toolbarActive;
        public PresentationModel(ShapeModel model)
        {
            _shapeModel = model;
            toolbarActive = new List<bool> { false, false, false };
        }
        public void Draw(System.Drawing.Graphics graphics)
        {
            var graphicsAdaptor = new WindowFormsGraphicsAdaptor(graphics);
            _shapeModel.Draw(graphicsAdaptor);
        }

        internal void ClickDrawButton(List<System.Windows.Forms.ToolStripItem> toolStripItems, int clickedIndex, bool clicked)
        {
            toolbarActive = new List<bool> { false, false, false };
            toolbarActive[clickedIndex] = clicked;
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                var toolStripButton = (System.Windows.Forms.ToolStripButton)toolStripItems[i];
                toolStripButton.Checked = toolbarActive[i];
            }
        }

        internal BindingList<Shape> GetShapeList()
        {
            return _shapeModel.shapeList;
        }

        public void HandleCanvasMouseUp(Canvas canvas, Point2 point, List<System.Windows.Forms.ToolStripItem> toolStripItems)
        {
            _shapeModel.MouseUp(point);
            ClickDrawButton(toolStripItems, 0, false);
            canvas.Cursor = System.Windows.Forms.Cursors.Default;

        }
        public void HandleCanvasMouseMove(object sender, MouseEventArgs e)
        {
            _shapeModel.MouseMove(new Point2(e.X, e.Y));
        }
        public void HandleCanvasMouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < toolbarActive.Count; i++)
            {
                if (toolbarActive[i])
                {
                    _shapeModel.MouseDown((ShapeType)i, new Point2(e.X, e.Y));
                }
            }
        }

        /// <summary>
        /// create shape button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ButtonFunction CreateButtonClick(ComboBox comboBox)
        {
            return (object sender, EventArgs e) =>
            {
                _shapeModel.Add((ShapeType)comboBox.SelectedItem);
            };
        }

        /// <summary>
        /// delete button click with delete model and datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _shapeModel.RemoveIndex(e.RowIndex);
            }
        }

        public ButtonFunction HandleToolStripButtonClick(List<ToolStripItem> toolStripItems, ShapeType shapeType, Canvas canvas)
        {
            return (object sender, EventArgs e) =>
            {
                ClickDrawButton(toolStripItems, (int)shapeType, true);
                canvas.Cursor = System.Windows.Forms.Cursors.Cross;
            };
        }
    }
}
