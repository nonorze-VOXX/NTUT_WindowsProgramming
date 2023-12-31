using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Drawing;
using System.Windows.Forms;

namespace Unity.Tests
{
    [TestClass]
    public class PresentationModelTests
    {
        private Mock<IGraphics> _mockGraphics;
        private Mock<PageModel> _mockShapeModel;
        private Canvas _mockCanvas;
        private PresentationModel _presentationModel;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _mockGraphics = new Mock<IGraphics>();
            _mockShapeModel = new Mock<PageModel>();
            _mockCanvas = new Canvas();
            _presentationModel = new PresentationModel(_mockShapeModel.Object);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Utils()
        {
            var form = new Form1(_presentationModel);
            _presentationModel.InitAddPage(0, form);
            _presentationModel.HandleCanvasMouseMove(new Point(1, 1));
            _presentationModel.HandleCanvasMouseDown(new Point(1, 1));
            var eventArgs = new DataGridViewCellEventArgs(0, 0);
            _presentationModel.DeleteButtonClick(null, eventArgs);
            _presentationModel.Undo();
            _presentationModel.Redo();

            int index = 0;
            var canvas = new Mock<Canvas>();
            _presentationModel.HandleToolStripButtonClick(null, (ShapeType)index, canvas.Object);
            var e = new KeyEventArgs(Keys.Delete);
            _presentationModel.HandleKeyDown(e);
            _presentationModel.HandleCanvasMouseDown(new Point(1, 1));
            _presentationModel.HandleCanvasMouseUp(_mockCanvas, new Point(1, 1), null);
            _presentationModel.DeletePage(form);
            _presentationModel.DeletePage(form);
            _presentationModel.AddShape(ShapeType.Line, new Point(1, 1), new Point(2, 2));
            _presentationModel.AddPageButtonClick();
            _presentationModel.AddPageButtonClick();
            _presentationModel.AddPageButtonClick();
            _presentationModel.GetNowPage();
            _presentationModel.SetFocusSlide(true);
            _presentationModel.HandleKeyDown(e);
            var test = _presentationModel.shapeListUnit;
            _presentationModel.SetNowPageIndex(2);
            _presentationModel.DeletePage(form);

            /*TODO
            _presentationModel.Save();
            _presentationModel.Load(form);
            _presentationModel.AddPageButtonClick();
            _presentationModel.AddPageButtonClick();
            _presentationModel.AddPageButtonClick();
            _presentationModel.Load(form);
            */
        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Draw_CallsDrawOnShapeModel()
        {
            _presentationModel.InitAddPage(0, new Form1(_presentationModel));
            // Act
            _presentationModel.Draw(_mockGraphics.Object, _mockCanvas);

            // Assert
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Draw_SetsCursorToSizeNWSEWhenShapeIsScale()
        {
            _presentationModel.InitAddPage(0, new Form1(_presentationModel));
            // Arrange

            // Act
            _presentationModel.Draw(_mockGraphics.Object, _mockCanvas);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Draw_SetsCursorToDefaultWhenShapeIsNotScaleAndCursorIsNotCross()
        {
            // Arrange
            //_mockShapeModel.Setup(s => s.IsScale()).Returns(false);

            _presentationModel.InitAddPage(0, new Form1(_presentationModel));
            // Act
            _presentationModel.Draw(_mockGraphics.Object, _mockCanvas);
        }
    }
}