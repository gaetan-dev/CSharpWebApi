using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.UnitTests.Example.Model
{
    [TestClass]
    public class UnitTestIsEmpty
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void ShouldReturnTrueWhenAllPropertiesIsEmpty()
        {
            // Act
            ExampleModel example = new ExampleModel();
            bool expect = example.IsEmpty();

            // Assert
            Assert.IsTrue(expect);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenAtLeastOneIsNoNull()
        {
            // Act
            ExampleModel example = new ExampleModel
            {
                Id = "1"
            };
            bool expect = example.IsEmpty();

            // Assert
            Assert.IsFalse(expect);
        }
    }
}
