using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using FlexTesting.Tests.Mocks;
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
            Assert.IsTrue(Entities.Statuses.FirstOrDefault(x=>x.FolderId == FolderHelper.FolderForDeletion.Id)?.IsDeleted);
            Assert.True(result.IsDeleted);
        }

        [Test]
        public async Task DeleteNotExistingFolder()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _folderService.DeleteFolder("aaaaaa"));
        }
    }
}