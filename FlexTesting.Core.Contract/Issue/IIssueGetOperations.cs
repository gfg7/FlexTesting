using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.Issue
{
    public interface IIssueGetOperations : IGetOperations<Models.Issue>
    {
        public Task<IEnumerable<Models.Issue>> ByStatus(string statusId);
        public Task<IEnumerable<Models.Issue>> ByFolder(string folderId);
        public Task<Models.Issue> ByExternalId(string externalId);
    }
}