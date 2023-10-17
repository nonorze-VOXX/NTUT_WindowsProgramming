using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form, Interface.IShapeObserver
    {
        ShapeModel _shapeModel;
        PresentationModel _presentationModel;

        public Form1(ShapeModel shapeModel, PresentationModel presentationModel)
        {
            this._presentationModel = presentationModel;
            this._shapeModel = shapeModel;
            InitializeComponent();
            this._dataGridView.CellContentClick += DeleteButtonClick;
            this._dataGridView.DataSource = _shapeModel.shapeList;
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// create shape button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButtonClick(object sender, EventArgs e)
        {
            var random = new Random();
            _shapeModel.Add(_shapeComboBox.Text);
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
                //    _shapeModel.RemoveIndex(e.RowIndex);
                _dataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}