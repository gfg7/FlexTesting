using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusWriteOperations : IWriteOperations<Models.TaskStatus>
    {
        public Task<Models.TaskStatus> UpdateName(string statusId, string newName);
        public Task DeleteAllFromFolder( string folderId);
    }
}