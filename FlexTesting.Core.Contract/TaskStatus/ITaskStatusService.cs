using System.Threading.Tasks;
using FlexTesting.Core.Contract.TaskStatus.Dtos;

namespace FlexTesting.Core.Contract.TaskStatus
{
    public interface ITaskStatusService
    {
        public Task<Models.TaskStatus> GetByUser(string userId);
        public Task<Models.TaskStatus> GetBySourceAndUser(string userId);
        public Task<Models.TaskStatus> Create(CreateStatusDto createStatusDto);
        public Task<Models.TaskStatus> Delete(string statusId, bool safeDelete);
        public Task<Models.TaskStatus> Rename(string statusId, string newName);
    }
}