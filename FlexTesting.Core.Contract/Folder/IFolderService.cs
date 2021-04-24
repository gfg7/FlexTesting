using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder.Dtos;

namespace FlexTesting.Core.Contract.Folder
{
    public interface IFolderService
    {
        public Task<Models.Folder> CreateFolder(CreateFolderDto createFolderDto);
        public Task<Models.Folder> DeleteFolder(string id);
        public Task<IEnumerable<Models.Folder>> GetByUser(string userId);
    }
}