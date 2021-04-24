using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.User;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    [TestFixture]
    public class CurrentUserTest : BaseUserTest
    {
        [Test]
        public async Task GetExistingUserTest()
        {
            var result = await _userService.GetCurrentUser("newtoken");
            Assert.NotNull(result);
            Assert.AreEqual(UserHelper.UserModel.Id, result.Id);
        }

        [Test]
        public async Task GetNotExistingUserTest()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _userService.GetCurrentUser("sdf"));
        }
    }
}