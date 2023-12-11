using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.Drawing;
using Unity.Command;

namespace Unity.Tests
{
    [TestClass]
    public class DeleteCommandTests
    {
        private DeleteCommand _deleteCommand;
        private BindingList<Shape> _mockShapes;

        /// <summary>
        /// a
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            _deleteCommand = new DeleteCommand(0);
            _mockShapes = new BindingList<Shape>();
            _mockShapes.Add(new Line(new Point(1, 1), new Point(1, 1), new Point(1, 1)));

        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Excute_RemovesShapeAtGivenIndex()
        {
            _deleteCommand.Execute(_mockShapes);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void Unexcute_DoesNothing()
        {
            _deleteCommand.ExecuteNo(_mockShapes);
        }

        /// <summary>
        /// a
        /// </summary>
        [TestMethod]
        public void to_string_ReturnsCorrectString()
        {
        }
    }
}