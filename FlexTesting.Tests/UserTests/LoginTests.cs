using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Dtos;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.User;
using FlexTesting.Tests.Helpers;
using FlexTesting.Tests.Mocks;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    [TestFixture]
    public class LoginTests
    {
        private readonly IUserService _userService;

        public LoginTests()
        {
            _userService = new UserService(new UserGetOperationsMock(), new UserWriteOperationsMock());
        }

        [Test]
        public async Task CorrectLoginTest()
        {
            var result = await _userService.Login(UserHelper.LoginDto);
            Assert.IsNotEmpty(result.Token);
        }
        
        [Test]
        public async Task IncorrectLoginTest()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _userService.Login(new("Aa", "asds")));
        }

        [Test]
        public async Task InvalidPasswordTest()
        {
            Assert.ThrowsAsync<InvalidPasswordException>(async () =>
                await _userService.Login(UserHelper.LoginDto with
                {
                    Password = "1234"
                }));
        }

        [Test]
        public async Task EmptyDtoTest()
        {
            Assert.ThrowsAsync<ValidationException>(async () => await _userService.Login(new LoginDto(null, null)));
        }
    }
}