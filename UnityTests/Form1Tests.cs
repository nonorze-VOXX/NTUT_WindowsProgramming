using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unity.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void Form1Test()
        {
            new Form1(new PresentationModel(new ShapeModel()));
        }
    }
}