using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.ShapeModelState.Tests
{
    [TestClass]
    public class PointStateTests
    {
        private Mock<IGraphics> _mockGraphics;
        private Mock<Line> _mockShape;
        private PrivateObject _pointStatePrivate;
        private PointState _pointState;

        /// <summary>
        /// up
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            _mockGraphics = new Mock<IGraphics>();
            _mockShape = new Mock<Line>(new Point2(0, 0), new Point2(0, 0));
            _pointState = new PointState();
            _pointStatePrivate = new PrivateObject(_pointState);
        }

        /// <summary>
        /// press
        /// </summary>
        [TestMethod()]
        public void TestDeletePress()
        {
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            shapeList.Add(_mockShape.Object);
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(1, 1), shapeList);
            _pointState.DeletePress(shapeList);
            Assert.IsTrue(shapeList.Contains(_mockShape.Object));
        }

        /// <summary>
        /// draw
        /// </summary>
        [TestMethod()]
        public void TestDraw()
        {
            var shapeList = new System.ComponentModel.BindingList<Shape> { };
            _pointState.Draw(_mockGraphics.Object);
        }

        /// <summary>
        /// down
        /// </summary>
        [TestMethod()]
        public void TestMouseDown()
        {
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            _mockShape.Setup(x => x.GetFirst()).Returns(new Point2(10, 10));
            _mockShape.Setup(x => x.GetSecond()).Returns(new Point2(20, 20));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(10, 10), shapeList);
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(1, 1), shapeList);
            _pointState.Draw(_mockGraphics.Object);
        }

        /// <summary>
        /// move
        /// </summary>
        [TestMethod()]
        public void TestMouseMove()
        {
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _pointState.MouseMove(new Point2(1, 1));
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            _mockShape.Setup(x => x.GetFirst()).Returns(new Point2(10, 10));
            _mockShape.Setup(x => x.GetSecond()).Returns(new Point2(20, 20));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(1, 1), shapeList);
            _pointState.MouseMove(new Point2(1, 1));
        }

        /// <summary>
        /// false
        /// </summary>
        [TestMethod()]
        public void TestMouseMoveFalse()
        {
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(false);
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _mockShape.Setup(x => x.GetFirst()).Returns(new Point2(10, 10));
            _mockShape.Setup(x => x.GetSecond()).Returns(new Point2(20, 20));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(1, 1), shapeList);
        }

        /// <summary>
        /// up
        /// </summary>
        [TestMethod()]
        public void TestMouseUp()
        {
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _pointState.MouseUp(new Point2(1, 1), shapeList);
        }

        /// <summary>
        /// scale
        /// </summary>
        [TestMethod()]
        public void TestMouseMoveScale()
        {
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _pointState.MouseMove(new Point2(1, 1));
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            _mockShape.Setup(x => x.GetFirst()).Returns(new Point2(10, 10));
            _mockShape.Setup(x => x.GetSecond()).Returns(new Point2(20, 20));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(15, 15), shapeList);
            Assert.IsNotNull(_pointStatePrivate.GetField("_choosingShape"));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(10, 20), shapeList);
            Assert.IsNotNull(_pointStatePrivate.GetField("_scalePoint"));
            _pointState.MouseMove(new Point2(12, 12));
            _pointState.MouseMove(new Point2(15, 15));
        }
    }
}