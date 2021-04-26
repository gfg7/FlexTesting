using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.Issue
{
    public interface IIssueWriteOperations : IWriteOperations<Models.Issue>
    {
        public Task<Models.Issue> UpdateName(string issueId, string name);
        public Task<Models.Issue> UpdateDescription(string issueId, string description);
        public Task<Models.Issue> UpdateFolder(string issueId, string folderId);
        public Task DeleteByFolder(string folderId);
        public Task<Models.Issue> UpdateStatus(string issueId, string statusId);
    }
}