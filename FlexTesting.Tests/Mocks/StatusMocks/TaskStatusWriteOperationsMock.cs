using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.TaskStatus;
using TaskStatus = FlexTesting.Core.Contract.Models.TaskStatus;

namespace FlexTesting.Tests.Mocks.StatusMocks
{
    public class TaskStatusWriteOperationsMock : ITaskStatusWriteOperations
    {
        public async System.Threading.Tasks.Task<TaskStatus> Create(TaskStatus item)
        {
            Entities.Statuses.Add(item);
            return item;
        }

        public async System.Threading.Tasks.Task<TaskStatus> UpdateOne(string id, TaskStatus item)
        {
            Entities.Statuses.RemoveAll(x => x.Id == id);
            Entities.Statuses.Add(item);
            return item;
        }

        public async System.Threading.Tasks.Task<TaskStatus> Delete(string id)
        {
            var status = Entities.Statuses.FirstOrDefault(x => x.Id == id);
            Entities.Statuses.RemoveAll(x => x.Id == id);
            return status;
        }

        public async System.Threading.Tasks.Task<TaskStatus> SafeDelete(string id)
        {
            var status = Entities.Statuses.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (status is not null)
            {
                status.IsDeleted = true;
            }

            return status;
        }

        public async System.Threading.Tasks.Task<TaskStatus> UpdateName(string statusId, string newName)
        {
            var status = Entities.Statuses.FirstOrDefault(x => x.Id == statusId && !x.IsDeleted);
            if (status is not null)
            {
                status.Name = newName;
            }

            return status;
        }

        public async Task DeleteAllFromFolder(string folderId)
        {
            foreach (var status in Entities.Statuses.Where(x=>x.FolderId == folderId))
            {
                status.IsDeleted = true;
            }
        }
    }
}