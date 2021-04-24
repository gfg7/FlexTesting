using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Xml.Xsl;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Contract.User.Dtos;
using FlexTesting.Core.User;
using FlexTesting.Tests.Helpers;
using FlexTesting.Tests.Mocks;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    public class UserRegistrationTests : BaseUserTest
    {
        [Test]
        public async Task ValidRegisterTest()
        {
            var user = UserHelper.NewUserDto;
            var result = await _userService.Register(user);
            Assert.IsNotEmpty(result.Id);
            Assert.IsNotEmpty(result.Password);
            Assert.IsNotEmpty(result.Salt);
            Assert.IsNotEmpty(result.Token);
            Assert.IsTrue(Entities.UsersList.Exists(u=>u.Id == result.Id));
        }

        [Test]
        public async Task InvalidRegisterTest()
        {
            var user = new NewUserDto();
            Assert.ThrowsAsync<ValidationException>(async () => await _userService.Register(user));
        }

        [Test]
        public async Task ExistingUserRegisterTest()
        {
            var user = UserHelper.NewUserDto with {Login = UserHelper.UserModel.Login};
            Assert.ThrowsAsync<ExistingUserException>(async () => await _userService.Register(user));
        }
    }
}