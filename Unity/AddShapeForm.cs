using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unity
{

    public partial class AddShapeForm : Form
    {
        private ShapeType shapeType;
        int _top;
        int _left;
        int _right;
        int _down;
        PresentationModel _presentationModel;
        public AddShapeForm(PresentationModel presentationModel)
        {
            this._presentationModel = presentationModel;

            InitializeComponent();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void CreateShape(object sender, EventArgs e)
        {
            _presentationModel.AddShape(shapeType, new Point(_left, _top), new Point(_right, _down));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            Close();
        }

        private void DownChange(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            try
            {
                _down = Convert.ToInt32(box.Text);
            }
            catch (Exception)
            {
                _down = 0;
            }
            ChangeOkState();
        }

        private void TopChange(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            try
            {
                _top = Convert.ToInt32(box.Text);
            }
            catch (Exception)
            {
                _top = 0;
            }
            ChangeOkState();
        }
        private void RightChange(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            try
            {
                _right = Convert.ToInt32(box.Text);
            }
            catch (Exception)
            {
                _right = 0;
            }
            ChangeOkState();
        }
        private void LeftChange(object sender, EventArgs e)
        {
            var box = (TextBox)sender;
            try
            {
                _left = Convert.ToInt32(box.Text);
            }
            catch (Exception)
            {
                _left = 0;
            }

            ChangeOkState();
        }

        void ChangeOkState()
        {
            if (_left >= _right)
            {
                _createButton.Enabled = false;
                return;
            }
            if (_top >= _down)
            {
                _createButton.Enabled = false;
                return;
            }
            _createButton.Enabled = true;
        }

        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
