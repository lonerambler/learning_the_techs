using System;
using NetCoreTesting.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NetCoreTesting.Tests
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        [TestMethod]
        public void DefaultPasswordLengthShouldBeEight()
        {
            var passwordGenerator = new PasswordGenerator();
            var password = passwordGenerator.Generate();

            Assert.AreEqual(password.Length, 8, $"Password lenght was {password.Length} and should have been 8");
        }

        [TestMethod]
        public void NegativePasswordLengthShouldThrowException()
        {
            var passwordGenerator = new PasswordGenerator(-1);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => passwordGenerator.Generate());
        }

    }
}
