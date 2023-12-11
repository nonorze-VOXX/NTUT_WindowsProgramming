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
        private Mock<ShapeModel> _mockShapeModel;
        private Canvas _mockCanvas;
        private PresentationModel _presentationModel;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _mockGraphics = new Mock<IGraphics>();
            _mockShapeModel = new Mock<ShapeModel>();
            _mockCanvas = new Canvas();
            _presentationModel = new PresentationModel(_mockShapeModel.Object);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Utils()
        {
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

        }
        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Draw_CallsDrawOnShapeModel()
        {
            // Act
            _presentationModel.Draw(_mockGraphics.Object, _mockCanvas);

            // Assert
            _mockShapeModel.Verify(s => s.Draw(_mockGraphics.Object), Times.Once);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod()]
        public void Draw_SetsCursorToSizeNWSEWhenShapeIsScale()
        {
            // Arrange
            _mockShapeModel.Setup(s => s.IsScale()).Returns(true);

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
            _mockShapeModel.Setup(s => s.IsScale()).Returns(false);

            // Act
            _presentationModel.Draw(_mockGraphics.Object, _mockCanvas);
        }
    }
}