using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.TaskStatus.Dtos;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusService
    {
        public Task<IEnumerable<Models.TaskStatus>> GetByFolder(string folderId);
        public Task<Models.TaskStatus> Create(CreateStatusDto createStatusDto);
        public Task<Models.TaskStatus> Delete(string statusId, bool safeDelete = true);
        public Task<Models.TaskStatus> Rename(RenameTaskStatusDto renameTaskStatusDto);
    }
}