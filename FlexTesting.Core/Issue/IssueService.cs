using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Issue.Dtos;

namespace FlexTesting.Core.Issue
{
    public class IssueService : IIssueService
    {
        public async Task<Contract.Models.Issue> Create(CreateIssueDto createIssueDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Issue> ChangeStatus(ChangeStatusDto changeStatusDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Issue> ChangeInfo(ChangeIssueInfoDto changeIssueInfoDto)
        {
            throw new System.NotImplementedException();
        }
    }
}