using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1
    {
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void AddPage(int index)
        {
            var slide = new Button();
            slide.Anchor = ((AnchorStyles)(((AnchorStyles.Right | AnchorStyles.Left) | AnchorStyles.Top)));
            slide.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            var width = _splitContainer1.Panel1.Width - SIX;
            var height = width / TEN_SIX * NINE;
            slide.Size = new Size(width, height);
            slide.Location = new Point(THREE, THREE + _splitContainer1.Panel1.Controls.Count * height);
            slide.Name = SLIDE;
            slide.BackColor = Color.White;
            slide.Focus();
            this._splitContainer1.Panel1.Controls.Add(slide);
            slide.Click += HandleSlideClick(_splitContainer1.Panel1.Controls, slide);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private EventHandler HandleSlideClick(Control.ControlCollection panel1Controls, Button slide)
        {
            return (object sender, EventArgs e) =>
            {
                var control = _splitContainer1.Panel1.Controls;
                var index = 0;
                for (int i = 0; i < control.Count; i++)
                {
                    if (control[i] == slide)
                    {
                        index = i;
                        break;
                    }
                }
                _presentationModel.ClickSlide(index, _dataGridView);
                slide.Focus();
            };
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void HandleUndoButtonState(bool undo, bool redo)
        {
            _undoButton.Enabled = undo;
            _redoButton.Enabled = redo;
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void RemovePage(int pagesCount)
        {
            var control = _splitContainer1.Panel1.Controls;
            control.RemoveAt(pagesCount);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void SwitchToSlide(int index)
        {
            var control = _splitContainer1.Panel1.Controls;
            HandleSlideClick(control, (Button)control[index])(null, null);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void DeletePage()
        {
            _presentationModel.DeletePage(this);
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        public void DeletePageAt(int index)
        {
            _splitContainer1.Panel1.Controls.RemoveAt(index);
        }

        SaveForm _saveForm;

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void LoadButtonClick(object sender, EventArgs e)
        {
            _loadForm.ShowDialog();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void SaveButtonClick(object sender, EventArgs e)
        {
            _saveForm.ShowDialog();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void CreateButtonClick(object sender, EventArgs e)
        {
            _addShapeForm.SetShapeType((ShapeType)_shapeComboBox.GetSelectedItem());
            _addShapeForm.ShowDialog();
        }
    }
}
