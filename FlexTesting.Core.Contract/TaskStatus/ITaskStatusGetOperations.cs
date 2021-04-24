using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusGetOperations : IGetOperations<Models.Status>
    {
        public Task<IEnumerable<Models.Status>> BySource(string sourceId);
        public Task<IEnumerable<Models.Status>> ByFolder(string folderId);
    }
}