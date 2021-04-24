using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.UserTests
{
    [TestFixture]
    public class DeleteUserTest : BaseUserTest
    {
        [Test]
        public async Task DeleteExistingUserTest()
        {
            var result = await _userService.DeleteUser(UserHelper.DeletingUserModel.Id);
            Assert.True(result.IsDeleted);
            Assert.IsEmpty(result.Token);
        }

        [Test]
        public async Task DeleteNotExistingUserTest()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _userService.DeleteUser("odhfsdiohf"));
        }
    }
}