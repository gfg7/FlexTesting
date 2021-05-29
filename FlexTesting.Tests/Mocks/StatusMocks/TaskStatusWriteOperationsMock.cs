using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;

namespace FlexTesting.Tests.Mocks.StatusMocks
{
    public class TaskStatusWriteOperationsMock : ITaskStatusWriteOperations
    {
        public async System.Threading.Tasks.Task<Status> Create(Status item)
        {
            Entities.Statuses.Add(item);
            return item;
        }

        public async System.Threading.Tasks.Task<Status> UpdateOne(string id, Status item)
        {
            Entities.Statuses.RemoveAll(x => x.Id == id);
            Entities.Statuses.Add(item);
            return item;
        }

        public async System.Threading.Tasks.Task<Status> Delete(string id)
        {
            var status = Entities.Statuses.FirstOrDefault(x => x.Id == id);
            Entities.Statuses.RemoveAll(x => x.Id == id);
            return status;
        }

        public async System.Threading.Tasks.Task<Status> SafeDelete(string id)
        {
            var status = Entities.Statuses.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (status is not null)
            {
                status.IsDeleted = true;
            }

            return status;
        }

        public async System.Threading.Tasks.Task<Status> UpdateName(string statusId, string newName)
        {
            var status = Entities.Statuses.FirstOrDefault(x => x.Id == statusId && !x.IsDeleted);
            if (status is not null)
            {
                status.Name = newName;
            }

            return status;
        }

        public async Task DeleteAllFromFolder(string folderId, bool safeSelete)
        {
            foreach (var status in Entities.Statuses.Where(x=>x.FolderId == folderId))
            {
                status.IsDeleted = true;
            }
        }
    }
}