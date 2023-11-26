using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Unity.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        private Mock<ShapeModel> _mockShapeModel;
        private PresentationModel _model;

        /// <summary>
        /// set
        /// </summary>
        [TestInitialize()]
        public void SetUp()
        {
            _mockShapeModel = new Mock<ShapeModel>();
            _model = new PresentationModel(_mockShapeModel.Object);
        }

        /// <summary>
        /// constructor
        /// </summary>
        [TestMethod()]
        public void TestConstructor()
        {
            Assert.IsNotNull(_model.GetShapeList());
            Assert.IsNotNull(_model);
            Assert.AreEqual(4, _model.GetShapeButtonActive().Count);
            Assert.IsFalse(_model.GetShapeButtonActive().Any(x => x));
        }

        /// <summary>
        /// draw
        /// </summary>
        [TestMethod()]
        public void TestDraw()
        {
            var mockGraphics = new Mock<IGraphics>();
            _model.Draw(mockGraphics.Object);
            _mockShapeModel.Verify(x => x.Draw(mockGraphics.Object), Times.Once);
        }

        /// <summary>
        /// shape
        /// </summary>
        [TestMethod()]
        public void TestUpdateShapeButtonActive()
        {
            var toolStripItems = new List<ToolStripItem> { new ToolStripButton(), new ToolStripButton(), new ToolStripButton(), new ToolStripButton() };
            _model.UpdateShapeButtonActive(toolStripItems, 1, true);
            Assert.IsTrue(_model.GetShapeButtonActive()[1]);
        }

        /// <summary>
        /// up
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasMouseUp()
        {
            var mockCanvas = new Mock<Canvas>();
            var point = new Point2(1, 1);
            var toolStripItems = new List<ToolStripItem> { new ToolStripButton(), new ToolStripButton(), new ToolStripButton(), new ToolStripButton() };
            _model.HandleCanvasMouseUp(mockCanvas.Object, point, toolStripItems);
            _mockShapeModel.Verify(x => x.MouseUp(point), Times.Once);
        }

        /// <summary>
        /// move
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasMouseMove()
        {
            var point = new Point2(1, 1);
            _model.HandleCanvasMouseMove(point);
            _mockShapeModel.Verify(x => x.MouseMove(point), Times.Once);
        }

        /// <summary>
        /// down
        /// </summary>
        [TestMethod()]
        public void TestHandleCanvasMouseDown()
        {
            var point = new Point2(1, 1);
            _model.GetShapeButtonActive()[0] = true;
            _model.HandleCanvasMouseDown(point);
            _mockShapeModel.Verify(x => x.MouseDown(It.IsAny<ShapeType>(), point), Times.Once);
        }

        /// <summary>
        /// click
        /// </summary>
        [TestMethod()]
        public void TestCreateButtonClick()
        {
            var mockComboBox = new Mock<ShapeTypeComboBox>();
            mockComboBox.Setup(x => x.GetSelectedItem()).Returns(ShapeType.Rectangle);
            var buttonFunction = _model.CreateButtonClick(mockComboBox.Object);
            buttonFunction.Invoke(null, null);
            _mockShapeModel.Verify(x => x.Add(ShapeType.Rectangle), Times.Once);
        }

        /// <summary>
        /// click
        /// </summary>
        [TestMethod()]
        public void TestDeleteButtonClick()
        {
            var eventArgs = new DataGridViewCellEventArgs(0, 0);
            _model.DeleteButtonClick(null, eventArgs);
            _mockShapeModel.Verify(x => x.RemoveIndex(0), Times.Once);
        }

        /// <summary>
        /// down
        /// </summary>
        [TestMethod()]
        public void TestHandleKeyDown()
        {
            var eventArgs = new KeyEventArgs(Keys.Delete);
            _model.HandleKeyDown(eventArgs);
            _mockShapeModel.Verify(x => x.DeletePress(), Times.Once);
        }

        /// <summary>
        /// click
        /// </summary>
        [TestMethod()]
        public void TestHandleToolStripButtonClick()
        {
            var toolStripItems = new List<ToolStripItem> { new ToolStripButton(), new ToolStripButton(), new ToolStripButton(), new ToolStripButton() };
            int index = 1;
            var canvas = new Mock<Canvas>();
            var function = _model.HandleToolStripButtonClick(toolStripItems, (ShapeType)index, canvas.Object);
            function.Invoke(null, null);
            _mockShapeModel.Verify(x => x.SwitchStateDrawing(), Times.Once);
        }
    }
}