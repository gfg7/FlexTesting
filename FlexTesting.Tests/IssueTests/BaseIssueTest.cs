using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Issue;
using FlexTesting.Tests.Mocks.FolderMocks;
using FlexTesting.Tests.Mocks.IssueMocks;
using FlexTesting.Tests.Mocks.StatusMocks;

namespace FlexTesting.Tests.IssueTests
{
    public abstract class BaseIssueTest
    {
        protected readonly IIssueService _issueService;

        public BaseIssueTest()
        {
            _issueService = new IssueService(
                new IssueGetOperationsMock(), 
                new IssueWriteOperationsMock(), 
                new FolderGetOperationsMock(), 
                new TaskStatusGetOperationsMock());
        }
    }
}