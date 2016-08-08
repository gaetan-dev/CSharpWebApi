using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiStarter.Commons.ExtensionMethods;
using WebApiStarter.Components.Example.Model;

namespace WebApiStarter.UnitTests.ExtensionMethods
{
    [TestClass]
    public class UnitTestIsNullOrEmpty
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [TestMethod]
        public void ShouldReturnTrueWhenEnumerableIsNull()
        {
            // Act
            List<ExampleModel> examples = null;
            bool expect = examples.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(expect);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenEnumerableIsEmpty()
        {
            // Act
            List<ExampleModel> examples = new List<ExampleModel>();
            bool expect = examples.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(expect);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenEnumerableIsNotNullAndEmpty()
        {
            // Act
            List<ExampleModel> examples = new List<ExampleModel>
            {
                new ExampleModel()
            };
            bool expect = examples.IsNullOrEmpty();

            // Assert
            Assert.IsFalse(expect);
        }
    }
}
