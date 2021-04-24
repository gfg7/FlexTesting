using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.Contract.User;

namespace FlexTesting.Core.Folder
{
    public class FolderService : IFolderService
    {
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly IFolderWriteOperations _folderWriteOperations;
        private readonly IUserGetOperations _userGetOperations;
        private readonly ITaskStatusWriteOperations _taskStatusWriteOperations;
        
        public FolderService(
            IFolderGetOperations folderGetOperations, 
            IFolderWriteOperations folderWriteOperations, 
            IUserGetOperations userGetOperations,
            ITaskStatusWriteOperations taskStatusWriteOperations)
        {
            _folderGetOperations = folderGetOperations;
            _folderWriteOperations = folderWriteOperations;
            _userGetOperations = userGetOperations;
            _taskStatusWriteOperations = taskStatusWriteOperations;
        }

        public async Task<Contract.Models.Folder> CreateFolder(CreateFolderDto createFolderDto)
        {
            ValidationHelper.ValidateAndThrow(createFolderDto);
            await CheckExistingUser(createFolderDto.UserId);

            var model = new Contract.Models.Folder
            {
                Id = Guid.NewGuid().ToString(),
                Name = createFolderDto.Name,
                UserId = createFolderDto.UserId
            };

            return await _folderWriteOperations.Create(model);
        }

        public async Task<Contract.Models.Folder> DeleteFolder(string id, bool safeDelete = true)
        {
            if (!await _folderGetOperations.ExistsById(id))
            {
                throw new NotFoundException("Директория не найдена");
            }

            await _taskStatusWriteOperations.DeleteAllFromFolder(id);

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
    }
}