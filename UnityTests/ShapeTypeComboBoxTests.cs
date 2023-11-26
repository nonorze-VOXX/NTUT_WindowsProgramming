using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Tests
{
    [TestClass()]
    public class ShapeTypeComboBoxTests
    {
        [TestMethod()]
        public void GetSelectedItemTest()
        {
            ShapeTypeComboBox shapeTypeComboBox = new ShapeTypeComboBox();
            Assert.IsNull(shapeTypeComboBox.GetSelectedItem());
        }
    }
}