using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.FolderTests
{
    [TestFixture]
    public class GetFolderByUserTest : BaseFolderTest 
    {
        [Test]
        public async Task GetExistingFolders()
        {
            var result = await _folderService.GetByUser(UserHelper.UserModel.Id);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task GetNotExistingFolders()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _folderService.GetByUser("a"));
        }
    }
}