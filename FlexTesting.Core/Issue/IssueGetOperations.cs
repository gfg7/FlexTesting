using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.Issue
{
    public class IssueGetOperations : GetOperations<Contract.Models.Issue>, IIssueGetOperations
    {
        public async Task<IEnumerable<Contract.Models.Issue>> ByStatus(string statusId)
        {
            return await GetList(F.Eq(x => x.StatusId, statusId));
        }

        public async Task<IEnumerable<Contract.Models.Issue>> ByFolder(string folderId)
        {
            return await GetList(F.Eq(x => x.FolderId, folderId));
        }

        public async Task<Contract.Models.Issue> ByExternalId(string externalId)
        {
            return await GetOne(F.Eq(x => x.ExternalId, externalId));
        }

        public IssueGetOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}