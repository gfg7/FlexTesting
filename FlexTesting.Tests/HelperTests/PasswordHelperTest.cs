using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.HelperTests
{
    [TestFixture]
    public class PasswordHelperTest
    {
        [Test]
        [Order(0)]
        public void GeneratePasswordTest()
        {
            var password = "ahah_12_sasas";
            var result = PasswordHelper.GeneratePassword(password);
            Assert.IsFalse(string.IsNullOrEmpty(result.Hash));
            Assert.IsFalse(string.IsNullOrEmpty(result.Salt));
        }

        [Test]
        public void ComparePasswordTest()
        {
            var result = PasswordHelper.ComparePassword(UserHelper.UserModel, "ahah_12_sasas");
            Assert.IsTrue(result);
        }

        [Test]
        public void IncorrectPasswordTest()
        {
            var result = PasswordHelper.ComparePassword(UserHelper.UserModel, "12345");
            Assert.IsFalse(result);
        }
    }
}