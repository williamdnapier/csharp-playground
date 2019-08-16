using NUnit.Framework;

namespace Tests
{

    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_validFileLowerCased_ReturnsTrue()
        {
            //Arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            //Act
            bool result = analyzer.isValidLogFileName("whatever.slf");

            //Assert
            Assert.IsTrue(result, "filename should be valid");
        }
    }
}