using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Folder.Dtos;

namespace FlexTesting.Core.Folder
{
    public class FolderService : IFolderService
    {
        private readonly IFolderGetOperations _folderGetOperations;
        private readonly IFolderWriteOperations _folderWriteOperations;

        public FolderService(
            IFolderGetOperations folderGetOperations, 
            IFolderWriteOperations folderWriteOperations)
        {
            _folderGetOperations = folderGetOperations;
            _folderWriteOperations = folderWriteOperations;
        }

        public async Task<Contract.Models.Folder> CreateFolder(CreateFolderDto createFolderDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Folder> DeleteFolder(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Contract.Models.Folder>> GetByUser(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}