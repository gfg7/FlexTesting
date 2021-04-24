using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.TaskStatus;
using TaskStatus = FlexTesting.Core.Contract.Models.TaskStatus;

namespace FlexTesting.Tests.Mocks.StatusMocks
{
    public class TaskStatusGetOperationsMock : ITaskStatusGetOperations
    {
        public async Task<TaskStatus> GetById(string id)
        {
            return Entities.Statuses.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<TaskStatus>> GetAll(string id)
        {
            return Entities.Statuses;
        }

        public async Task<bool> ExistsById(string id)
        {
            return Entities.Statuses.Exists(x => x.Id == id);
        }

        public async Task<IEnumerable<TaskStatus>> BySource(string sourceId)
        {
            return Entities.Statuses.Where(x => x.SourceId == sourceId && !x.IsDeleted);
        }

        public async Task<IEnumerable<TaskStatus>> ByFolder(string folderId)
        {
            return Entities.Statuses.Where(x => x.FolderId == folderId && !x.IsDeleted);
        }
    }
}