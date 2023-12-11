using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

namespace Unity.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        private MoveCommand _moveCommand;
        private Mock<Shape> _mockShape;
        private BindingList<Shape> _shapes;
        private List<Point> _fromPoints;
        private List<Point> _toPoints;
        private Point _nowCanvas;

        [TestInitialize]
        public void TestInitialize()
        {
            _fromPoints = new List<Point> { new Point(0, 0), new Point(1, 1) };
            _toPoints = new List<Point> { new Point(2, 2), new Point(3, 3) };
            _nowCanvas = new Point(4, 4);
            _moveCommand = new MoveCommand(0, new Point(5, 5), _fromPoints, _nowCanvas);
            _mockShape = new Mock<Shape>(new Point(5, 5), new Point(5, 5), new Point(5, 5));
            _shapes = new BindingList<Shape> { _mockShape.Object };
        }

        [TestMethod]
        public void Excute_SetsShapeProperties()
        {
            _moveCommand.SetTarget(_toPoints);
            _moveCommand.Excute(_shapes);
        }

        [TestMethod]
        public void Unexcute_DoesNothing()
        {
            _moveCommand.Unexcute(_shapes);
            _mockShape.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void to_string_ReturnsMoveAndIndex()
        {
            var result = _moveCommand.to_string();
            Assert.AreEqual("move 0", result);
        }

        [TestMethod]
        public void GetPastPoints_ReturnsFromPoints()
        {
            var result = _moveCommand.GetPastPoints();
            CollectionAssert.AreEqual(_fromPoints, result);
        }

        [TestMethod]
        public void SetTarget_SetsToPoints()
        {
            _moveCommand.SetTarget(_toPoints);
        }
    }
}