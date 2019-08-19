using System;
using NUnit.Framework;

namespace Tests
{

    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer m_analyzer = null;

        //[OneTimeSetUp]
        //public void Setup()
        //{
        //    //Arrange
        //    m_analyzer = new LogAnalyzer();
        //}

        [Test]
        public void IsValidFileName_validFileLowerCased_ReturnsTrue()
        {
            //Arrange
            m_analyzer = new LogAnalyzer();

            //Act
            bool result = m_analyzer.IsValidLogFileName("whatever.slf");

            //Assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void IsValidFileName_validFileUpperCased_ReturnsTrue()
        {
            //Arrange
            m_analyzer = new LogAnalyzer();

            //Act
            bool result = m_analyzer.IsValidLogFileName("whatever.SLF");

            //Assert
            Assert.IsTrue(result, "filename should be valid!");
        }

        [Test]
        public void IsValidFileName_EmptyFileName_ReturnsFalse()
        {
            //Arrange
            m_analyzer = new LogAnalyzer();

            //Act & Assert
            Assert.IsFalse(m_analyzer.IsValidLogFileName(string.Empty));
        }

        [TearDown]
        public void TearDown()
        {

            m_analyzer = null;
        }
    }
}