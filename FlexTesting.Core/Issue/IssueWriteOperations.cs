using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Issue
{
    public class IssueWriteOperations : WriteOperations<Contract.Models.Issue>, IIssueWriteOperations
    {
        private readonly IIssueContext _issueContext;
        
        public async Task<Contract.Models.Issue> UpdateName(string issueId, string name)
        {
            return await UpdateOne(F.Eq(x => x.Id, issueId), U.Set(x => x.Name, name));
        }

        public async Task<Contract.Models.Issue> UpdateDescription(string issueId, string description)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, issueId);
            var update = Builders<Contract.Models.Issue>.Update.Set(x => x.Description, description);
            var result = await _issueContext.Issues.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _issueContext.Issues.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.Issue> UpdateFolder(string issueId, string folderId)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, issueId);
            var update = Builders<Contract.Models.Issue>.Update.Set(x => x.FolderId, folderId);
            var result = await _issueContext.Issues.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _issueContext.Issues.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task DeleteByFolder(string folderId)
        {
            await _issueContext.Issues.DeleteManyAsync(x => x.FolderId == folderId);
        }

        public async Task<Contract.Models.Issue> UpdateStatus(string issueId, string statusId)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, issueId);
            var update = Builders<Contract.Models.Issue>.Update.Set(x => x.StatusId, statusId);
            var result = await _issueContext.Issues.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _issueContext.Issues.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public IssueWriteOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}