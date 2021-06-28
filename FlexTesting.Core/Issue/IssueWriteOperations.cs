using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Issue
{
    public class IssueWriteOperations : WriteOperations<Contract.Models.Issue>, IIssueWriteOperations
    {
        public async Task<Contract.Models.Issue> UpdateName(string issueId, string name)
        {
            return await UpdateOne(F.Eq(x => x.Id, issueId), U.Set(x => x.Name, name));
        }

        public async Task<Contract.Models.Issue> UpdateDescription(string issueId, string description)
        {
            return await UpdateOne(F.Eq(x => x.Id, issueId), U.Set(x => x.Description, description));
        }

        public async Task<Contract.Models.Issue> UpdateFolder(string issueId, string folderId)
        {
            return await UpdateOne(F.Eq(x => x.Id, issueId), U.Set(x => x.FolderId, folderId));
        }

        public async Task DeleteByFolder(string folderId)
        {
            await Collection.DeleteManyAsync(x => x.FolderId == folderId);
        }

        public async Task<Contract.Models.Issue> UpdateStatus(string issueId, string statusId)
        {
            return await UpdateOne(F.Eq(x => x.Id, issueId), U.Set(x => x.StatusId, statusId));
        }

        public IssueWriteOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}