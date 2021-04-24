using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.FolderTests
{
    [TestFixture]
    public class DeleteFolderTest : BaseFolderTest
    {
        [Test]
        public async Task DeleteExistingFolder()
        {
            var result = await _folderService.DeleteFolder(FolderHelper.FolderForDeletion.Id);
            Assert.True(result.IsDeleted);
        }

        [Test]
        public async Task DeleteNotExistingFolder()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _folderService.DeleteFolder("aaaaaa"));
        }
    }
}