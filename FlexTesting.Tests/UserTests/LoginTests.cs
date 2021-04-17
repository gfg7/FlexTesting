using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Input;
using FlexTesting.Framework.Contract.Services;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    public class LoginTests
    {
        private readonly IUserService _userService;

        public LoginTests(IUserService userService)
        {
            _userService = userService;
        }

        public async Task CorrectLoginTest()
        {
            var input = new LoginDto("tt@ew.w", "Qwerty123!");

            var result = await _userService.Login(input);
            
            Assert.NotNull(result);
            Assert.AreEqual(input.Login, result.Login);
        }
    }
}