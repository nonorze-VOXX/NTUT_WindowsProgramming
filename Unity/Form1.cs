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
            this.dataGridView.Rows.Add("", 1, 1, 1);
            this.dataGridView.CellContentClick += DeleteButton_Click;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string str = shapeComboBox.Text;
            ShapeType shapeType;
            var r = new Random();
            if (Enum.TryParse(str, out shapeType))
                str += "SUCC";
            else
                str += "fail";
            textBox1.Text = str;
            shapeModel.Add(shapeComboBox.Text);
            UpdateDataGridView(shapeModel);
        }

        private void UpdateDataGridView(ShapeModel shapeModel)
        {
            dataGridView.Rows.Clear();
            foreach(var s in shapeModel.shapeList)
            {
                dataGridView.Rows.Add("",s.GetShapeName(),s.GetInfo()) ;
            }
        }

        private void DeleteButton_Click(object sender, DataGridViewCellEventArgs  e)
        {
            shapeModel.RemoveIndex(e.RowIndex);
            dataGridView.Rows.RemoveAt(e.RowIndex);
        }
    }
}