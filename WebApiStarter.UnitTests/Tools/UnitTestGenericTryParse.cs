using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebApiStarter.UnitTests.Tools
{
    [TestClass]
    public class UnitTestGenericTryParse
    {
        [TestMethod]
        public void ShouldReturnIntWhenGenericIsInt()
        {
            // Act
            const string entry = "123456";
            int result = Commons.Tools.GenericTryParse<int>(entry);

            // Assert
            Assert.AreEqual(123456, result);
        }

        [TestMethod]
        public void ShouldReturnDoubleWhenGenericIsDouble()
        {
            // Act
            const string entry = "123,456";
            double result = Commons.Tools.GenericTryParse<double>(entry);

            // Assert
            Assert.AreEqual(123.456, result);
        }

        [TestMethod]
        public void ShouldReturnFloatWhenGenericIsFloat()
        {
            // Act
            const string entry = "123,456";
            float result = Commons.Tools.GenericTryParse<float>(entry);

            // Assert
            Assert.AreEqual(123.456f, result);
        }

        [TestMethod]
        public void ShouldReturCharWhenGenericIsChar()
        {
            // Act
            const string entry = "h";
            char result = Commons.Tools.GenericTryParse<char>(entry);

            // Assert
            Assert.AreEqual('h', result);
        }

        [TestMethod]
        public void ShouldReturStringWhenGenericIsString()
        {
            // Act
            const string entry = "hello";
            string result = Commons.Tools.GenericTryParse<string>(entry);

            // Assert
            Assert.AreEqual("hello", result);
        }
    }
}
