using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Dtos;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    [TestFixture]
    public class ChangePasswordTest : BaseUserTest
    {
        [Test]
        public async Task ValidPasswordChangeTet()
        {
            var dto = new UserChangePasswordDto
            {
                UserId = UserHelper.OtherUserModel.Id,
                OldPassword = UserHelper.LoginDto.Password,
                NewPassword = "qwer_1212+2ea"
            };

            var result = await _userService.ChangePassword(dto);
            
            Assert.AreEqual(UserHelper.OtherUserModel.Id, dto.UserId);
            Assert.IsNotEmpty(result.Token);
        }

        [Test]
        public async Task InvalidPasswordChangeTest()
        {
            var dto = new UserChangePasswordDto();
            Assert.ThrowsAsync<ValidationException>(async () => await _userService.ChangePassword(dto));
        }
    }
}