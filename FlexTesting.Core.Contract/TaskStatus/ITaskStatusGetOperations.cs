using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusGetOperations : IGetOperations<Models.TaskStatus>
    {
        public Task<Models.TaskStatus> BySourceAndUser(string sourceId, string userId);
        public Task<IEnumerable<Models.TaskStatus>> ByUser(string userId);
        public Task<IEnumerable<Models.TaskStatus>> ByFolder(string folderId);
    }
}