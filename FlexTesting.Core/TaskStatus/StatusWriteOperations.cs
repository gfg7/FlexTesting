using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.TaskStatus
{
    public class StatusWriteOperations : WriteOperations<Status>, ITaskStatusWriteOperations
    {
        public async Task<Status> UpdateName(string statusId, string newName)
        {
            return await UpdateOne(F.Eq(x => x.Id, statusId), U.Set(x => x.Name, newName));
        }

        public async Task DeleteAllFromFolder(string folderId, bool safeDelete = true)
        {
            if (safeDelete)
            {
                await Collection.UpdateManyAsync(x => x.FolderId == folderId, 
                    Builders<Status>.Update.Set(x=>x.IsDeleted, true));
            }
            else
            {
                await Collection.DeleteManyAsync(x => x.FolderId == folderId);
            }
        }

        public StatusWriteOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}