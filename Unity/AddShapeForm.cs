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
            _textBox1.Text = "";
            _textBox2.Text = "";
            _textBox3.Text = "";
            _textBox4.Text = "";
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void CreateShape(object sender, EventArgs e)
        {
            _presentationModel.AddShape(shapeType, new Point(_left, _top), new Point(_right, _down));
            _textBox1.Text = "";
            _textBox2.Text = "";
            _textBox3.Text = "";
            _textBox4.Text = "";
            Close();
        }

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void ChangeDown(object sender, EventArgs e)
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

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void ChangeRight(object sender, EventArgs e)
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
        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// a
        /// </summary>
        /// <returns></returns>
        private void CancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
