using System.Threading.Tasks;
using FlexTesting.Core.Contract.Dtos;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    [TestFixture]
    public class ChangeFioTest : BaseUserTest
    {
        [Test]
        public async Task ChangeValidFioTest()
        {
            var dto = new UserChangeFioDto
            {
                UserId = UserHelper.OtherUserModel.Id,
                FirstName = "Алексей",
                LastName = "Будь здоров"
            };

            var result = await _userService.SetFio(dto);
            Assert.AreEqual(dto.FirstName, result.FirstName);
            Assert.AreEqual(dto.LastName, result.LastName);
            Assert.AreEqual(dto.MiddleName, result.MiddleName);
        }

        [Test]
        public async Task InvalidUserChangeFioTest()
        {
            var dto = new UserChangeFioDto
            {
                UserId = "UserHelper.OtherUserModel.Id",
                FirstName = "Алексей",
                LastName = "Будь здоров"
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _userService.SetFio(dto));
        }
    }
}