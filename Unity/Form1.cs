using System;
using System.Windows.Forms;

namespace Unity
{
    public partial class Form1 : Form
    {
        ShapeModel shapeModel;
        public Form1()
        {
            shapeModel = new ShapeModel();
            InitializeComponent();
            this.dataGridView.CellContentClick += DeleteButton_Click;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            ShapeType shapeType;
            var r = new Random();
            shapeModel.Add(shapeComboBox.Text);
            UpdateDataGridView(shapeModel);
        }

        private void UpdateDataGridView(ShapeModel shapeModel)
        {
            dataGridView.Rows.Clear();
            foreach(var s in shapeModel.shapeList)
            {
                dataGridView.Rows.Add("",s.GetShapeName(),s.GetInfoString()) ;
            }
        }

        private void DeleteButton_Click(object sender, DataGridViewCellEventArgs  e)
        {
            if (e.ColumnIndex == 0&&e.RowIndex!=-1)
            {
                shapeModel.RemoveIndex(e.RowIndex);
                dataGridView.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}