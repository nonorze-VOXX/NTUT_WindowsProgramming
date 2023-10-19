using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form, IShapeObserver
    {
        ShapeModel _shapeModel;
        PresentationModel _presentationModel;

        public Form1(ShapeModel shapeModel, PresentationModel presentationModel)
        {
            _presentationModel = presentationModel;
            _shapeModel = shapeModel;
            InitializeComponent();
            _shapeComboBox.DataSource = Enum.GetValues(typeof(ShapeType));
            _dataGridView.CellContentClick += DeleteButtonClick;
            _dataGridView.DataSource = _shapeModel.shapeList;
            _canvas.Paint += HandleCanvasPaint;
        }

        public void Bell()
        {
            Invalidate(true);
        }

        public void HandleCanvasPaint(object sender,
        System.Windows.Forms.PaintEventArgs e)
        {
            _presentationModel.Draw(e.Graphics);
        }

        /// <summary>
        /// create shape button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButtonClick(object sender, EventArgs e)
        {
            _shapeModel.Add((ShapeType)_shapeComboBox.SelectedItem);
        }

        /// <summary>
        /// delete button click with delete model and datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                _shapeModel.RemoveIndex(e.RowIndex);
            }
        }
    }
}