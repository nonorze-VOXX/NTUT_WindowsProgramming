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

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _start = new Point(0, 0);
            _end = new Point(1, 1);
            _nowCanvas = new Point(2, 2);
            _addCommand = new AddCommand(ShapeType.Line, _start, _end, _nowCanvas);
            _mockShapes = new Mock<BindingList<Shape>>();
        }
        /// <summary>
        /// a
        /// </summary>

        [TestMethod]
        public void Excute_AddsShapeToShapes()
        {
            _addCommand.Execute(_mockShapes.Object);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void SetEnd_SetsEndToGivenPoint()
        {
            var newEnd = new Point(3, 3);
            _addCommand.SetEnd(newEnd);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Unexcute_DoesNothing()
        {
            _addCommand.ExecuteNo(_mockShapes.Object);
            _mockShapes.VerifyNoOtherCalls();
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void to_string_ReturnsAdd()
        {
        }
    }
}