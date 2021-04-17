using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Input;
using FlexTesting.Framework.Contract.Services;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    public class RegisterTests
    {
        private readonly IUserService _userService;

        public RegisterTests(IUserService userService)
        {
            _userService = userService;
        }

        [Test]
        public async Task RegistrationHappyTest()
        {
            var input = new RegisterDto
            {
                FirstName = "Иван",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Bio = "Некоторая биография",
                Login = "tt@e.re",
                Password = "Йцукен123!"
            };

            var result = await _userService.Register(input);
            Assert.IsNotNull(result);
            Assert.AreEqual("Иванов Иван Иванович",result.Fio);
            Assert.AreEqual(input.Login, result.Login);
            Assert.IsNotEmpty(result.CurrentToken);
        }

        [Test]
        public async Task RegisterValidationFailTest()
        {
            var input = new RegisterDto
            {
                FirstName = "",
                LastName = "Иванов",
                MiddleName = "Иванович",
                Bio = "Некоторая биография",
                Login = "tt",
                Password = "!"
            };

            Assert.ThrowsAsync<ValidationException>(async () => await _userService.Register(input));
        }
    }
}