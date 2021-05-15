using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.FolderTests
{
    public class InviteUserInFolderTest : BaseFolderTest
    {
        [Test]
        public async Task InviteExistingUserTest()
        {
            var result = await _folderService.InviteUser(FolderHelper.ValidFolder.Id, UserHelper.UserModel.Id);
            Assert.NotNull(result);
            Assert.Contains( UserHelper.UserModel.Id, result.InvitedUsers);
        }

        [Test]
        public Task InviteNotExistingUserTest()
        {
            Assert.ThrowsAsync<NotFoundException>(async () =>
                await _folderService.InviteUser(FolderHelper.ValidFolder.Id, "adfdfffdgdf"));
            
            return Task.CompletedTask;
        }
    }
}