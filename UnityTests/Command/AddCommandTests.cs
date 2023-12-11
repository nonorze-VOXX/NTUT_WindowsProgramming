using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

namespace Unity.Tests
{
    [TestClass]
    public class AddCommandTests
    {
        private AddCommand _addCommand;
        private Mock<BindingList<Shape>> _mockShapes;
        private Point _start;
        private Point _end;
        private Point _nowCanvas;

        [TestInitialize]
        public void TestInitialize()
        {
            _start = new Point(0, 0);
            _end = new Point(1, 1);
            _nowCanvas = new Point(2, 2);
            _addCommand = new AddCommand(ShapeType.Line, _start, _end, _nowCanvas);
            _mockShapes = new Mock<BindingList<Shape>>();
        }

        [TestMethod]
        public void Excute_AddsShapeToShapes()
        {
            _addCommand.Excute(_mockShapes.Object);
        }

        [TestMethod]
        public void SetEnd_SetsEndToGivenPoint()
        {
            var newEnd = new Point(3, 3);
            _addCommand.SetEnd(newEnd);
        }

        [TestMethod]
        public void Unexcute_DoesNothing()
        {
            _addCommand.Unexcute(_mockShapes.Object);
            _mockShapes.VerifyNoOtherCalls();
        }

        [TestMethod]
        public void to_string_ReturnsAdd()
        {
            var result = _addCommand.to_string();
            Assert.AreEqual("add", result);
        }
    }
}