using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.TaskStatus.Dtos;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusService
    {
        public Task<IEnumerable<Models.Status>> GetByFolder(string folderId);
        public Task<Models.Status> Create(CreateStatusDto createStatusDto);
        public Task<Models.Status> Delete(string statusId, bool safeDelete = true);
        public Task<Models.Status> Rename(RenameTaskStatusDto renameTaskStatusDto);
    }
}