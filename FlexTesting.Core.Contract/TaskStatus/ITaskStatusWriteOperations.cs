using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusWriteOperations : IWriteOperations<Models.Status>
    {
        public Task<Models.Status> UpdateName(string statusId, string newName);
        public Task DeleteAllFromFolder( string folderId);
    }
}