using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Tests.Mocks.FolderMocks
{
    public class FolderGetOperationsMock : IFolderGetOperations
    {
        public async Task<Folder> GetById(string id)
        {
            return Entities.Folders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<IEnumerable<Folder>> GetAll()
        {
            return Entities.Folders;
        }

        public async Task<bool> ExistsById(string id)
        {
            return Entities.Folders.Exists(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<Folder> ByNameAndUser(string name, string userId)
        {
            return Entities.Folders.FirstOrDefault(x => x.Name == name && x.UserId == userId && !x.IsDeleted);
        }

        public async Task<IEnumerable<Folder>> ByUser(string userId)
        {
            return Entities.Folders.Where(x => x.UserId == userId && !x.IsDeleted);
        }
    }
}