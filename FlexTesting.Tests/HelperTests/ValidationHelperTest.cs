using System.ComponentModel.DataAnnotations;
using FlexTesting.Core.Contract.Dtos;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.HelperTests
{
    [TestFixture]
    public class ValidationHelperTest
    {
        [Test]
        public void ValidateHappyTest()
        {
            Assert.DoesNotThrow(() => ValidationHelper.ValidateAndThrow(UserHelper.NewUserDto));
        }
        
        [Test]
        public void ValidateIncorrectTest()
        {
            var user = new NewUserDto();
            Assert.Throws<ValidationException>(() => ValidationHelper.ValidateAndThrow(user));
        }
    }
}