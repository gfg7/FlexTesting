using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusGetOperations : IGetOperations<Models.TaskStatus>
    {
        public Task<IEnumerable<Models.TaskStatus>> BySource(string sourceId);
        public Task<IEnumerable<Models.TaskStatus>> ByFolder(string folderId);
    }
}