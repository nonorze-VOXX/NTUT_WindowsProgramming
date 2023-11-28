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
        List<bool> _shapeButtonActive;
        /// <summary>
        /// model
        /// </summary>
        /// <param name="model"></param>
        public PresentationModel(ShapeModel model)
        {
            _shapeModel = model;
            _shapeButtonActive = new List<bool>
            {
                false, false, false,false
            };
        }

        /// <summary>
        /// active
        /// </summary>
        /// <returns></returns>
        public List<bool> GetShapeButtonActive()
        {
            return _shapeButtonActive;
        }

        /// <summary>
        /// draw
        /// </summary>
        /// <param name="graphics"></param>
        public void Draw(IGraphics graphics, Canvas canvas)
        {
            _shapeModel.Draw(graphics);
            if (_shapeModel.MouseInCircle())
            {
                canvas.Cursor = Cursors.SizeNWSE;
            }
            else
            {
                canvas.Cursor = Cursors.Default;

            }
        }

        /// <summary>
        /// update tool stript
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="clickedIndex"></param>
        /// <param name="clicked"></param>
        public void UpdateShapeButtonActive(List<System.Windows.Forms.ToolStripItem> toolStripItems, int clickedIndex, bool clicked)
        {
            _shapeButtonActive = ResetToolStripButton(toolStripItems);
            _shapeButtonActive[clickedIndex] = clicked;
            UpdateToolStripButton(toolStripItems, _shapeButtonActive);
        }

        /// <summary>
        /// reset
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <returns></returns>
        List<bool> ResetToolStripButton(List<System.Windows.Forms.ToolStripItem> toolStripItems)
        {
            List<bool> newList = new List<bool>();
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                newList.Add(false);
            }

            return newList;
        }

        /// <summary>
        /// tool
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="shapeButtonActive"></param>
        void UpdateToolStripButton(List<System.Windows.Forms.ToolStripItem> toolStripItems, List<bool> shapeButtonActive)
        {
            for (int i = 0; i < toolStripItems.Count; i++)
            {
                var toolStripButton = (System.Windows.Forms.ToolStripButton)toolStripItems[i];
                toolStripButton.Checked = shapeButtonActive[i];
            }

        }

        /// <summary>
        /// get
        /// </summary>
        /// <returns></returns>
        public BindingList<Shape> GetShapeList()
        {
            return _shapeModel.shapeList;
        }

        #region CanvasMouse

        /// <summary>
        /// mouse up
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="point"></param>
        /// <param name="toolStripItems"></param>
        public void HandleCanvasMouseUp(Canvas canvas, Point2 point, List<System.Windows.Forms.ToolStripItem> toolStripItems)
        {
            _shapeModel.MouseUp(point);
            HandleToolStripPointButtonClick(toolStripItems, canvas)(null, null);
        }

        /// <summary>
        /// mouse move
        /// </summary>
        /// <param name="point"></param>
        public void HandleCanvasMouseMove(Point2 point)
        {
            _shapeModel.MouseMove(point);
        }

        /// <summary>
        /// mouse down
        /// </summary>
        /// <param name="point"></param>
        public void HandleCanvasMouseDown(Point2 point)
        {
            for (int i = 0; i < _shapeButtonActive.Count; i++)
            {
                if (_shapeButtonActive[i])
                {
                    _shapeModel.MouseDown((ShapeType)i, point);
                }
            }
        }
        #endregion

        /// <summary>
        /// create shape button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public ButtonFunction CreateButtonClick(ShapeTypeComboBox comboBox)
        {
            return (object sender, EventArgs e) =>
            {
                _shapeModel.Add((ShapeType)comboBox.GetSelectedItem());
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

        /// <summary>
        /// click
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="shapeType"></param>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public ButtonFunction HandleToolStripButtonClick(List<ToolStripItem> toolStripItems, ShapeType shapeType, Canvas canvas)
        {
            return (object sender, EventArgs e) =>
            {
                UpdateShapeButtonActive(toolStripItems, (int)shapeType, true);
                canvas.Cursor = System.Windows.Forms.Cursors.Cross;
                _shapeModel.SwitchStateDrawing();
            };
        }

        /// <summary>
        /// click
        /// </summary>
        /// <param name="toolStripItems"></param>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public ButtonFunction HandleToolStripPointButtonClick(List<ToolStripItem> toolStripItems, Canvas canvas)
        {
            return (object sender, EventArgs e) =>
            {
                UpdateShapeButtonActive(toolStripItems, 1 + 1 + 1, true);
                canvas.Cursor = System.Windows.Forms.Cursors.Default;
                _shapeModel.SwitchStatePoint();
            };
        }

        /// <summary>
        /// down
        /// </summary>
        /// <param name="e"></param>
        public void HandleKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _shapeModel.DeletePress();
            }
        }
    }
}
