using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;

namespace FlexTesting.Tests.Mocks.StatusMocks
{
    public class TaskStatusGetOperationsMock : ITaskStatusGetOperations
    {
        public async Task<Status> GetById(string id)
        {
            return Entities.Statuses.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Status>> GetAll()
        {
            return Entities.Statuses;
        }

        public async Task<bool> ExistsById(string id)
        {
            return Entities.Statuses.Exists(x => x.Id == id);
        }

        public async Task<IEnumerable<Status>> BySource(string sourceId)
        {
            return Entities.Statuses.Where(x => x.SourceId == sourceId && !x.IsDeleted);
        }

        public async Task<IEnumerable<Status>> ByFolder(string folderId)
        {
            return Entities.Statuses.Where(x => x.FolderId == folderId && !x.IsDeleted);
        }
    }
}