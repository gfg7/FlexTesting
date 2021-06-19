using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue.Dtos;

namespace FlexTesting.Core.Contract.Issue
{
    public interface IIssueService
    {
        public Task<Models.Issue> Create(CreateIssueDto createIssueDto);
        public Task<Models.Issue> ChangeStatus(ChangeStatusDto changeStatusDto);
        public Task<Models.Issue> ChangeInfo(ChangeIssueInfoDto changeIssueInfoDto);
        public Task<Dictionary<string, List<Models.Issue>>> ByFolder(string folderId);
        public Task<Models.Issue> ById(string issueId);
    }
}