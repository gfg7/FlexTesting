using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Issue
{
    public class IssueWriteOperations : IIssueWriteOperations
    {
        private readonly IIssueContext _issueContext;

        public IssueWriteOperations()
        {
            _issueContext = DbContext.IssueContext;
        }
        
        public async Task<Contract.Models.Issue> Create(Contract.Models.Issue item)
        {
            await _issueContext.Issues.InsertOneAsync(item);
            return item;
        }

        public async Task<Contract.Models.Issue> UpdateOne(string id, Contract.Models.Issue item)
        {
            var filter = MongoDB.Driver.Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, id);
            var result = await _issueContext.Issues.UpdateOneAsync(filter, new MongoDB.Driver.ObjectUpdateDefinition<Contract.Models.Issue>(item));
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.Issue> Delete(string id)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, id);
            var item = await _issueContext.Issues.FindSync(filter).FirstOrDefaultAsync();
            var result = await _issueContext.Issues.DeleteOneAsync(filter);
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.Issue> SafeDelete(string id)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, id);
            var update = Builders<Contract.Models.Issue>.Update.Set(x => x.IsDeleted, true);
            var result = await _issueContext.Issues.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _issueContext.Issues.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.Issue> UpdateName(string issueId, string name)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, issueId);
            var update = Builders<Contract.Models.Issue>.Update.Set(x => x.Name, name);
            var result = await _issueContext.Issues.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _issueContext.Issues.FindSync(filter).FirstOrDefaultAsync() : null;
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
    }
}