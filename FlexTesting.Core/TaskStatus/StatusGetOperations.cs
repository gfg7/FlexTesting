using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.TaskStatus
{
    public class StatusGetOperations : GetOperations<Status>, ITaskStatusGetOperations
    {
        public async Task<IEnumerable<Status>> BySource(string sourceId)
        {
            return await GetList(F.Eq(x => x.SourceId, sourceId));
        }

        public async Task<IEnumerable<Status>> ByFolder(string folderId)
        {
            return await GetList(F.Eq(x => x.FolderId, folderId));
        }

        public StatusGetOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}