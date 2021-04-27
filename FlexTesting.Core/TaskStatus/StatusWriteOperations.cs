using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.TaskStatus
{
    public class StatusWriteOperations : ITaskStatusWriteOperations
    {
        private readonly IStatusContext _statusContext;

        public StatusWriteOperations()
        {
            _statusContext = DbContext.StatusContext;
        }
        
        public async Task<Status> Create(Status item)
        {
            await _statusContext.Statuses.InsertOneAsync(item);
            return item;
        }

        public async Task<Status> UpdateOne(string id, Status item)
        {
            var filter = MongoDB.Driver.Builders<Contract.Models.Status>.Filter.Eq(x => x.Id, id);
            var result = await _statusContext.Statuses.UpdateOneAsync(filter, new MongoDB.Driver.ObjectUpdateDefinition<Contract.Models.Status>(item));
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Status> Delete(string id)
        {
            var filter = Builders<Contract.Models.Status>.Filter.Eq(x => x.Id, id);
            var item = await _statusContext.Statuses.FindSync(filter).FirstOrDefaultAsync();
            var result = await _statusContext.Statuses.DeleteOneAsync(filter);
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Status> SafeDelete(string id)
        {
            var filter = Builders<Contract.Models.Status>.Filter.Eq(x => x.Id, id);
            var update = Builders<Contract.Models.Status>.Update.Set(x => x.IsDeleted, true);
            var result = await _statusContext.Statuses.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _statusContext.Statuses.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Status> UpdateName(string statusId, string newName)
        {
            var filter = Builders<Contract.Models.Status>.Filter.Eq(x => x.Id, statusId);
            var update = Builders<Contract.Models.Status>.Update.Set(x => x.Name, newName);
            var result = await _statusContext.Statuses.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _statusContext.Statuses.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task DeleteAllFromFolder(string folderId)
        {
            await _statusContext.Statuses.DeleteManyAsync(x => x.FolderId == folderId);
        }
    }
}