using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Issue;

namespace FlexTesting.Tests.IssueTests
{
    public abstract class BaseIssueTest
    {
        protected readonly IIssueService _issueService;

        public BaseIssueTest()
        {
            _issueService = new IssueService();
        }
    }
}