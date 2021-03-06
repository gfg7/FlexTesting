using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.Issue;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexTesting.Core.Folder
{
    public class FolderService : IFolderService
    {
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly IFolderWriteOperations _folderWriteOperations;
        private readonly IUserGetOperations _userGetOperations;
        private readonly ITaskStatusWriteOperations _taskStatusWriteOperations;
        private readonly IIssueWriteOperations _issueWriteOperations;

        public FolderService(
            IFolderGetOperations folderGetOperations,
            IFolderWriteOperations folderWriteOperations,
            IUserGetOperations userGetOperations,
            ITaskStatusWriteOperations taskStatusWriteOperations,
            IIssueWriteOperations issueWriteOperations)
        {
            _folderGetOperations = folderGetOperations;
            _folderWriteOperations = folderWriteOperations;
            _userGetOperations = userGetOperations;
            _taskStatusWriteOperations = taskStatusWriteOperations;
            _issueWriteOperations = issueWriteOperations;
        }

        public async Task<Contract.Models.Folder> CreateFolder(CreateFolderDto createFolderDto)
        {
            ValidationHelper.ValidateAndThrow(createFolderDto);
            await CheckExistingUser(createFolderDto.UserId);
            var statuseIds = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                statuseIds.Add(Guid.NewGuid().ToString());
            }
            var model = new Contract.Models.Folder
            {
                Id = Guid.NewGuid().ToString(),
                Name = createFolderDto.Name,
                UserId = createFolderDto.UserId,
                StatusesOrder = statuseIds
            };
            await InitializeFolder(model);


            return await _folderWriteOperations.Create(model);
        }

        public async Task<Contract.Models.Folder> DeleteFolder(string id, bool safeDelete = true)
        {
            if (!await _folderGetOperations.ExistsById(id))
            {
                throw new NotFoundException("Директория не найдена");
            }

            await _taskStatusWriteOperations.DeleteAllFromFolder(id, safeDelete);
            await _issueWriteOperations.DeleteByFolder(id);
            return safeDelete
                ? await _folderWriteOperations.SafeDelete(id)
                : await _folderWriteOperations.Delete(id);
        }

        public async Task<IEnumerable<Contract.Models.Folder>> GetByUser(string userId)
        {
            await CheckExistingUser(userId);
            return await _folderGetOperations.ByUser(userId);
        }

        public async Task<Contract.Models.Folder> RenameFolder(RenameFolderDto renameFolderDto)
        {
            ValidationHelper.ValidateAndThrow(renameFolderDto);
            await CheckExistingFolder(renameFolderDto.FolderId);

            return await _folderWriteOperations.UpdateName(renameFolderDto.FolderId, renameFolderDto.NewName);
        }

        public async Task<Contract.Models.Folder> ById(string id)
        {
            return await _folderGetOperations.GetById(id);
        }

        public async Task<Contract.Models.Folder> InviteUser(string folderId, string userId)
        {
            await CheckExistingFolder(folderId);
            await CheckExistingUser(userId);

            return await _folderWriteOperations.InviteUser(folderId, userId);
        }

        public async Task<Contract.Models.Folder> DeleteInviteUser(string folderId, string userId)
        {
            await CheckExistingFolder(folderId);
            await CheckExistingUser(userId);

            return await _folderWriteOperations.DeleteInvitedUser(folderId, userId);
        }

        private async Task CheckExistingUser(string userId)
        {
            if (!await _userGetOperations.ExistsById(userId))
            {
                throw new NotFoundException("Пользователь не найден");
            }
        }

        private async Task CheckExistingFolder(string folderId)
        {
            if (!await _folderGetOperations.ExistsById(folderId))
            {
                throw new NotFoundException("Директория не найдена");
            }
        }

        private async Task InitializeFolder(Contract.Models.Folder folder, string sourceId = null, string externalId = null)
        {
            var testCaseStatus = new Status
            {
                Id = folder.StatusesOrder[0],
                SourceId = sourceId,
                ExternalId = externalId,
                Name = "Test Case",
                FolderId = folder.Id
            };
            var readyStatus = new Status
            {
                Id = folder.StatusesOrder[1],
                SourceId = sourceId,
                ExternalId = externalId,
                Name = "Ready for QA",
                FolderId = folder.Id
            };

            var progressStatus = new Status
            {
                Id = folder.StatusesOrder[2],
                SourceId = sourceId,
                ExternalId = externalId,
                Name = "QA in process",
                FolderId = folder.Id
            };

            var doneStatus = new Status
            {
                Id = folder.StatusesOrder[3],
                SourceId = sourceId,
                ExternalId = externalId,
                Name = "Done",
                FolderId = folder.Id
            };

            var statuses = new[] { testCaseStatus, readyStatus, progressStatus, doneStatus };
            foreach (var status in statuses)
            {
                await _taskStatusWriteOperations.Create(status);
            }
        }
    }
}