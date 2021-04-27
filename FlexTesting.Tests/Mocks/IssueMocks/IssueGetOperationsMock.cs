using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Tests.Mocks.IssueMocks
{
    public class IssueGetOperationsMock : IIssueGetOperations
    {
        public async Task<Issue> GetById(string id)
        {
            return Entities.Issues.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            return Entities.Issues.Where(x => !x.IsDeleted);
        }

        public async Task<bool> ExistsById(string id)
        {
            return Entities.Issues.Exists(x=>x.Id == id);
        }

        public async Task<IEnumerable<Issue>> ByStatus(string statusId)
        {
            return Entities.Issues.Where(x => x.StatusId == statusId);
        }

        public async Task<IEnumerable<Issue>> ByFolder(string folderId)
        {
            return Entities.Issues.Where(x => x.FolderId == folderId);
        }

        public async Task<Issue> ByExternalId(string externalId)
        {
            return Entities.Issues.FirstOrDefault(x => x.ExternalId == externalId);
        }
    }
}