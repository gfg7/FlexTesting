using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Folder.Dtos;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.User;

namespace FlexTesting.Core.Folder
{
    public class FolderService : IFolderService
    {
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly IFolderWriteOperations _folderWriteOperations;
        private readonly IUserGetOperations _userGetOperations;
        
        public FolderService(
            IFolderGetOperations folderGetOperations, 
            IFolderWriteOperations folderWriteOperations, 
            IUserGetOperations userGetOperations)
        {
            _folderGetOperations = folderGetOperations;
            _folderWriteOperations = folderWriteOperations;
            _userGetOperations = userGetOperations;
        }

        public async Task<Contract.Models.Folder> CreateFolder(CreateFolderDto createFolderDto)
        {
            ValidationHelper.ValidateAndThrow(createFolderDto);
            if (!await _userGetOperations.ExistsById(createFolderDto.UserId))
            {
                throw new NotFoundException("Пользователь не найден");
            }

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
            
            //todo: delete all tasks in folder

            return safeDelete
                ? await _folderWriteOperations.SafeDelete(id)
                : await _folderWriteOperations.Delete(id);
        }

        public async Task<IEnumerable<Contract.Models.Folder>> GetByUser(string userId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Folder> RenameFolder(RenameFolderDto renameFolderDto)
        {
            throw new NotImplementedException();
        }
    }
}