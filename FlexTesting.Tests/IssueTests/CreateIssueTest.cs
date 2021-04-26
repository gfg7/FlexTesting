using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Issue.Dtos;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.IssueTests
{
    [TestFixture]
    public class CreateIssueTest : BaseIssueTest
    {
        [Test]
        public async Task CreateValidTest()
        {
            var dto = new CreateIssueDto
            {
                Name = "name",
                Description = "description",
                FolderId = FolderHelper.ValidFolder.Id,
                StatusId = StatusHelper.ValidStatus.Id
            };

            var result = await _issueService.Create(dto);
            Assert.IsNotEmpty(result.Id);
            Assert.AreEqual(dto.Name, result.Name);
        }
        
        [Test]
        public async Task CreateInValidTest()
        {
            var dto = new CreateIssueDto();

            Assert.ThrowsAsync<ValidationException>(async () => await _issueService.Create(dto));
        }
        
        [Test]
        public async Task CreateInNotExistingFolderTest()
        {
            var dto = new CreateIssueDto
            {
                Name = "name",
                Description = "description",
                FolderId = "aaaaa",
                StatusId = StatusHelper.ValidStatus.Id
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _issueService.Create(dto));
        }
        
        [Test]
        public async Task CreateInNotExistingStatusTest()
        {
            var dto = new CreateIssueDto
            {
                Name = "name",
                Description = "description",
                FolderId = FolderHelper.ValidFolder.Id,
                StatusId = "StatusHelper.ValidStatus.Id"
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _issueService.Create(dto));
        }
    }
}