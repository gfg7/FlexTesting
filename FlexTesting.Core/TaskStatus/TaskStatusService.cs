using System.Collections.Generic;
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

        public async Task<IEnumerable<Contract.Models.Status>> GetByFolder(string folderId)
        {
            if (!await _folderGetOperations.ExistsById(folderId))
            {
                throw new NotFoundException("Директория не найдена");
            }

            return await _taskStatusGetOperations.ByFolder(folderId);
        }

        public async Task<Contract.Models.Status> Create(CreateStatusDto createStatusDto)
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

            var model = new Contract.Models.Status
            {
                Name = createStatusDto.Name,
                FolderId = createStatusDto.FolderId,
                SourceId = createStatusDto.SourceId,
                ExternalId = createStatusDto.ExternalId
            };

            return await _taskStatusWriteOperations.Create(model);
        }

        public async Task<Contract.Models.Status> Delete(string statusId, bool safeDelete = true)
        {
            if (!await _taskStatusGetOperations.ExistsById(statusId))
            {
                throw new NotFoundException("Статус не найден");
            }

            return safeDelete
                ? await _taskStatusWriteOperations.SafeDelete(statusId)
                : await _taskStatusWriteOperations.Delete(statusId);
        }

        public async Task<Contract.Models.Status> Rename(RenameTaskStatusDto renameTaskStatusDto)
        {
            ValidationHelper.ValidateAndThrow(renameTaskStatusDto);

            if (!await _taskStatusGetOperations.ExistsById(renameTaskStatusDto.TaskStatusId))
            {
                throw new NotFoundException("Статус не найден");
            }

            return await _taskStatusWriteOperations.UpdateName(renameTaskStatusDto.TaskStatusId,
                renameTaskStatusDto.NewName);
        }
    }
}