using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Tests
{
    [TestClass()]
    public class ShapeTypeComboBoxTests
    {
        /// <summary>
        /// set
        /// </summary>
        [TestMethod()]
        public void GetSelectedItemTest()
        {
            ShapeTypeComboBox shapeTypeComboBox = new ShapeTypeComboBox();
            Assert.IsNull(shapeTypeComboBox.GetSelectedItem());
        }
    }
}