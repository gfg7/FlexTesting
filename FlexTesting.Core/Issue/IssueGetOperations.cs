using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.Issue
{
    public class IssueGetOperations : IIssueGetOperations
    {
        private readonly IIssueContext _issueContext;

        public IssueGetOperations()
        {
            _issueContext = DbContext.IssueContext;
        }
        
        public async Task<Contract.Models.Issue> GetById(string id)
        {
            return await _issueContext.Issues.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract.Models.Issue>> GetAll()
        {
            return await _issueContext.Issues.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> ExistsById(string id)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.Id, id);
            return await _issueContext.Issues.CountDocumentsAsync(filter) != 0;
        }

        public async Task<IEnumerable<Contract.Models.Issue>> ByStatus(string statusId)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.StatusId, statusId);
            return await _issueContext.Issues.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Contract.Models.Issue>> ByFolder(string folderId)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.FolderId, folderId);
            return await _issueContext.Issues.Find(filter).ToListAsync();
        }

        public async Task<Contract.Models.Issue> ByExternalId(string externalId)
        {
            var filter = Builders<Contract.Models.Issue>.Filter.Eq(x => x.ExternalId, externalId);
            return await _issueContext.Issues.Find(filter).FirstOrDefaultAsync();
        }
    }
}