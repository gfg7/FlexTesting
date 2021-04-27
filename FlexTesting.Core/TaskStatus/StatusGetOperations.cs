using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.TaskStatus
{
    public class StatusGetOperations : ITaskStatusGetOperations
    {
        private readonly IStatusContext _statusContext;

        public StatusGetOperations()
        {
            _statusContext = DbContext.StatusContext;
        }
        
        public async Task<Status> GetById(string id)
        {
            var filter = Builders<Status>.Filter.Eq(x => x.Id, id);
            return await _statusContext.Statuses.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Status>> GetAll()
        {
            return await _statusContext.Statuses.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> ExistsById(string id)
        {
            var filter = Builders<Contract.Models.Status>.Filter.Eq(x => x.Id, id);
            return await _statusContext.Statuses.CountDocumentsAsync(filter) != 0;
        }

        public async Task<IEnumerable<Status>> BySource(string sourceId)
        {
            var filter = Builders<Contract.Models.Status>.Filter.Eq(x => x.SourceId, sourceId);
            return await _statusContext.Statuses.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Status>> ByFolder(string folderId)
        {
            var filter = Builders<Contract.Models.Status>.Filter.Eq(x => x.FolderId, folderId);
            return await _statusContext.Statuses.Find(filter).ToListAsync();
        }
    }
}