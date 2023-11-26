﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Unity.ShapeModelState.Tests
{
    [TestClass]
    public class PointStateTests
    {
        private Mock<IGraphics> _mockGraphics;
        private Mock<Line> _mockShape;
        private PointState _pointState;

        [TestInitialize]
        public void SetUp()
        {
            _mockGraphics = new Mock<IGraphics>();
            _mockShape = new Mock<Line>(new Point2(0, 0), new Point2(0, 0));
            _pointState = new PointState();
        }

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

        [TestMethod()]
        public void TestDraw()
        {
            var shapeList = new System.ComponentModel.BindingList<Shape> { };
            _pointState.Draw(_mockGraphics.Object);
        }

        [TestMethod()]
        public void TestMouseDown()
        {
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(true);
            _mockShape.Setup(x => x.GetFirst()).Returns(new Point2(10, 10));
            _mockShape.Setup(x => x.GetSecond()).Returns(new Point2(20, 20));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(1, 1), shapeList);
            _pointState.Draw(_mockGraphics.Object);
        }

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
        [TestMethod()]
        public void TestMouseMoveFalse()
        {
            _mockShape.Setup(s => s.IsPointIn(It.IsAny<Point2>())).Returns(false);
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _mockShape.Setup(x => x.GetFirst()).Returns(new Point2(10, 10));
            _mockShape.Setup(x => x.GetSecond()).Returns(new Point2(20, 20));
            _pointState.MouseDown(ShapeType.Rectangle, new Point2(1, 1), shapeList);
        }

        [TestMethod()]
        public void TestMouseUp()
        {
            var shapeList = new System.ComponentModel.BindingList<Shape> { _mockShape.Object };
            _pointState.MouseUp(new Point2(1, 1), shapeList);
        }
    }
}