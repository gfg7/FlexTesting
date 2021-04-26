using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Issue.Dtos;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.IssueTests
{
    [TestFixture]
    public class IssueChangeStatusTest : BaseIssueTest
    {
        [Test]
        public async Task ChangeValidStatusTest()
        {
            var dto = new ChangeStatusDto
            {
                IssueId = IssueHelper.ValidIssue.Id,
                StatusId = StatusHelper.ValidStatus.Id
            };

            var result = await _issueService.ChangeStatus(dto);
            Assert.AreEqual(dto.StatusId, result.StatusId);
        }
        
        [Test]
        public async Task ChangeInvalidStatusTest()
        {
            var dto = new ChangeStatusDto
            {
                IssueId = IssueHelper.ValidIssue.Id,
                StatusId = "aaa"
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _issueService.ChangeStatus(dto));
        }
        
        [Test]
        public async Task ChangeInvalidIssueTest()
        {
            var dto = new ChangeStatusDto
            {
                IssueId = "IssueHelper.ValidIssue.Id",
                StatusId = StatusHelper.ValidStatus.Id
            };

            Assert.ThrowsAsync<NotFoundException>(async () => await _issueService.ChangeStatus(dto));
        }
    }
}