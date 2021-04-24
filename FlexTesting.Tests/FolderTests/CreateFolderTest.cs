using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.FolderTests
{
    [TestFixture]
    public class CreateFolderTest : BaseFolderTest
    {
        [Test]
        public async Task CreateValidFolder()
        {
            var dto = new CreateFolderDto
            {
                Name = "Directory",
                UserId = UserHelper.UserModel.Id
            };

            var result = await _folderService.CreateFolder(dto);
            Assert.IsNotEmpty(result.Id);
            Assert.AreEqual(UserHelper.UserModel.Id, result.UserId);
        }

        [Test]
        public async Task CreateFolderWithNotExistingUser()
        {
            var dto = new CreateFolderDto
            {
                Name = "aa",
                UserId = "a"
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _folderService.CreateFolder(dto));
        }
        [Test]
        public async Task CreateInvalidFolder()
        {
            var dto = new CreateFolderDto();

            Assert.ThrowsAsync<ValidationException>(async () => await _folderService.CreateFolder(dto));
        }
    }
}