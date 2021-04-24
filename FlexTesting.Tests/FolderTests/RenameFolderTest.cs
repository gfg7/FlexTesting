using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Tests.Helpers;
using FlexTesting.Tests.UserTests;
using NUnit.Framework;

namespace FlexTesting.Tests.FolderTests
{
    [TestFixture]
    public class RenameFolderTest : BaseFolderTest
    {
        [Test]
        public async Task RenameExistingFolder()
        {
            var dto = new RenameFolderDto
            {
                FolderId = FolderHelper.ValidFolder.Id,
                NewName = "New Name"
            };

            var result = await _folderService.RenameFolder(dto);
            Assert.AreEqual(result.Name, dto.NewName);
        }

        [Test]
        public async Task RenameNotExistingFolder()
        {
            var dto = new RenameFolderDto
            {
                NewName = "a",
                FolderId = "aaaaa"
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _folderService.RenameFolder(dto));
        }
    }
}