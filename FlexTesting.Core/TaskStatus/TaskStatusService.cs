using System.Threading.Tasks;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.TaskStatus.Dtos;

namespace FlexTesting.Core.TaskStatus
{
    public class TaskStatusService : ITaskStatusService
    {
        public async Task<Contract.Models.TaskStatus> GetByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.TaskStatus> GetBySourceAndUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.TaskStatus> Create(CreateStatusDto createStatusDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.TaskStatus> Delete(string statusId, bool safeDelete)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.TaskStatus> Rename(string statusId, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}