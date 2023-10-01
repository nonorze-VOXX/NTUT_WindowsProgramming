using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form
    {
        ShapeModel _shapeModel;
        public Form1()
        {
            _shapeModel = new ShapeModel();
            InitializeComponent();
            this._dataGridView.CellContentClick += DeleteButtonClick;
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
            UpdateDataGridView(_shapeModel);
        }

        /// <summary>
        /// update data grid view same with shape model
        /// </summary>
        /// <param name="shapeModel"></param>
        private void UpdateDataGridView(ShapeModel shapeModel)
        {
            _dataGridView.Rows.Clear();
            foreach (var s in shapeModel.shapeList)
            {
                _dataGridView.Rows.Add("",s.GetShapeName(),s.GetInfoString()) ;
            }
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
                _dataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}