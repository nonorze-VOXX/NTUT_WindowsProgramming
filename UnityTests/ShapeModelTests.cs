using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.Tests
{
    [TestClass()]
    public class ShapeModelTests
    {
        private Mock<IShapeObserver> _mockObserver;
        private ShapeModel _model;

        [TestInitialize()]
        public void SetUp()
        {
            _mockObserver = new Mock<IShapeObserver>();
            _model = new ShapeModel();
            _model.Attach(_mockObserver.Object);
        }

        [TestMethod()]
        public void SwitchStateDrawing()
        {
            _model.SwitchStateDrawing();
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Once);
        }

        [TestMethod()]
        public void SwitchStatePoint()
        {
            _model.SwitchStatePoint();
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Never);
        }

        [TestMethod()]
        public void AttachAndDetach()
        {
            _model.Detach(_mockObserver.Object);
            _model.SwitchStateDrawing();
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Never);
        }

        [TestMethod()]
        public void MouseDown()
        {
            _model.MouseDown(ShapeType.Rectangle, new Point2(1, 1));
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Never);
        }

        [TestMethod()]
        public void MouseUp()
        {
            _model.MouseDown(ShapeType.Rectangle, new Point2(1, 1));
            _model.MouseUp(new Point2(2, 2));
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Once);
        }

        [TestMethod()]
        public void DrawTest()
        {
            var graphics = new Mock<IGraphics>();
            _model.Add(ShapeType.Line);
            _model.Draw(graphics.Object);
            graphics.Verify(adapter => adapter.DrawLine(It.IsAny<Point2>(), It.IsAny<Point2>()), Times.Exactly(2));
        }
        [TestMethod()]
        public void MouseMove()
        {
            _model.MouseDown(ShapeType.Rectangle, new Point2(1, 1));
            _model.MouseMove(new Point2(2, 2));
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Once);
        }

        [TestMethod()]
        public void AddShape()
        {
            _model.Add(ShapeType.Rectangle);
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Once);
        }

        [TestMethod()]
        public void AddShapeWithPoints()
        {
            _model.Add(ShapeType.Rectangle, new Point2(1, 1), new Point2(2, 2));
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Once);
        }

        [TestMethod()]
        public void RemoveIndex()
        {
            _model.Add(ShapeType.Rectangle);
            _model.RemoveIndex(0);
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Exactly(2));
        }

        [TestMethod()]
        public void DeletePress()
        {
            _model.DeletePress();
            _mockObserver.Verify(x => x.ReceiveBell(), Times.Once);
        }
    }
}
