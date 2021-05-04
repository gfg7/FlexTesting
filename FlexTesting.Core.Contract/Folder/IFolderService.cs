using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder.Dtos;

namespace FlexTesting.Core.Contract.Folder
{
    public interface IFolderService
    {
        public Task<Models.Folder> CreateFolder(CreateFolderDto createFolderDto);
        public Task<Models.Folder> DeleteFolder(string id, bool safeDelete = true);
        public Task<IEnumerable<Models.Folder>> GetByUser(string userId);
        public Task<Models.Folder> RenameFolder(RenameFolderDto renameFolderDto);
        public Task<Models.Folder> ById(string id);
    }
}