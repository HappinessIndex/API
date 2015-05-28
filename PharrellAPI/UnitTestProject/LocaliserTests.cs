using System;
using NUnit.Framework;

namespace UnitTestProject
{
    [TestFixture]
    public class LocaliserTests
    {
        [Test]
        public void Localiser_Exists()
        {
            // Arrange
            string expected = "PharrellApi.Localiser.Localiser, PharrellApi";

            // Act
            var actual = Type.GetType(expected);

            // Assert
            Assert.That(actual, Is.Not.Null);
        }
         
    }
}