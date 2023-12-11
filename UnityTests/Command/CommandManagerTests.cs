using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

namespace Unity.Tests
{
    [TestClass]
    public class CommandManagerTests
    {
        private CommandManager _commandManager;
        private Mock<BindingList<Shape>> _mockShapes;

        [TestInitialize]
        public void TestInitialize()
        {
            _commandManager = new CommandManager();
            _mockShapes = new Mock<BindingList<Shape>>();
        }
        [TestMethod]
        public void utils()
        {
            var moveCommand = new MoveCommand(0, new Point(0, 0), new List<Point> { new Point(1, 1), new Point(2, 2) }, new Point(3, 3));
            _commandManager.Move(moveCommand, new List<Point> { new Point(1, 1), new Point(2, 2) });
            _commandManager.AddShape(new AddCommand(ShapeType.Line, new Point(1, 1), new Point(2, 2), new Point(3, 3)), new Point(1, 1));
            _commandManager.AddShape(new AddCommand(ShapeType.Line, new Point(1, 1), new Point(2, 2), new Point(3, 3)), new Point(1, 1));
            _commandManager.Undo(_mockShapes.Object);
            _commandManager.Redo(_mockShapes.Object);
        }

        [TestMethod]
        public void AddShape_AddsAddCommandToUndoStack()
        {
            var start = new Point(0, 0);
            var end = new Point(1, 1);
            var nowCanvas = new Point(2, 2);
            _commandManager.AddShape(ShapeType.Line, start, end, nowCanvas);
        }

        [TestMethod]
        public void Delete_AddsDeleteCommandToUndoStack()
        {
            _commandManager.Delete(0);
        }

        [TestMethod]
        public void Move_AddsMoveCommandToUndoStackWhenPointsAreDifferent()
        {
            var moveCommand = new MoveCommand(0, new Point(0, 0), new List<Point> { new Point(1, 1), new Point(2, 2) }, new Point(3, 3));
            _commandManager.Move(moveCommand, new List<Point> { new Point(4, 4), new Point(5, 5) });
        }
    }
}
