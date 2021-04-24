using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.TaskStatus.Dtos;

namespace FlexTesting.Core.TaskStatus
{
    public class TaskStatusService : ITaskStatusService
    {
        private readonly ITaskStatusGetOperations _taskStatusGetOperations;
        private readonly ITaskStatusWriteOperations _taskStatusWriteOperations;
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly ISourceGetOperations _sourceGetOperations;

        public TaskStatusService(ITaskStatusGetOperations taskStatusGetOperations,
            ITaskStatusWriteOperations taskStatusWriteOperations, 
            IFolderGetOperations folderGetOperations, 
            ISourceGetOperations sourceGetOperations)
        {
            _taskStatusGetOperations = taskStatusGetOperations;
            _taskStatusWriteOperations = taskStatusWriteOperations;
            _folderGetOperations = folderGetOperations;
            _sourceGetOperations = sourceGetOperations;
        }

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
            ValidationHelper.ValidateAndThrow(createStatusDto);
            if (!await _folderGetOperations.ExistsById(createStatusDto.FolderId))
            {
                throw new NotFoundException("Директория для статуса не найдена");
            }

            if (!await _sourceGetOperations.ExistsById(createStatusDto.SourceId))
            {
                createStatusDto.SourceId = SourceIds.Flex.ToString();
            }

            var model = new Contract.Models.TaskStatus
            {
                Name = createStatusDto.Name,
                FolderId = createStatusDto.FolderId,
                SourceId = createStatusDto.SourceId,
                ExternalId = createStatusDto.ExternalId
            };

            return await _taskStatusWriteOperations.Create(model);
        }

        public async Task<Contract.Models.TaskStatus> Delete(string statusId, bool safeDelete = true)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.TaskStatus> Rename(string statusId, string newName)
        {
            throw new System.NotImplementedException();
        }
    }
}