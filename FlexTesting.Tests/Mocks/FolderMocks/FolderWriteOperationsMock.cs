using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Contract.Models;

namespace FlexTesting.Tests.Mocks.FolderMocks
{
    public class FolderWriteOperationsMock : IFolderWriteOperations
    {
        public async Task<Folder> Create(Folder item)
        {
            Entities.Folders.Add(item);
            return item;
        }

        public async Task<Folder> Update(string id, Folder item)
        {
            Entities.Folders.RemoveAll(x => x.Id == id && !x.IsDeleted);
            Entities.Folders.Add(item);
            return item;
        }

        public async Task<Folder> Delete(string id)
        {
            var folder = Entities.Folders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            Entities.Folders.RemoveAll(x => x.Id == id);
            return folder;
        }

        public async Task<Folder> SafeDelete(string id)
        {
            var folder = Entities.Folders.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (folder is not null)
            {
                folder.IsDeleted = true;
            }

            return folder;
        }

        public Task<Folder> UpdateName(string folderId, string name)
        {
            var folder = Entities.Folders.FirstOrDefault(x => x.Id == folderId && !x.IsDeleted);
            if (folder is not null)
            {
                folder.Name = name;
            }

            return Task.FromResult(folder);
        }

        public Task<Folder> InviteUser(string folderId, string userId)
        {
            var folder = Entities.Folders.FirstOrDefault(x => x.Id == folderId && !x.IsDeleted);
            folder?.InvitedUsers.Add(userId);

            return Task.FromResult(folder);
        }

        public Task<Folder> DeleteInvitedUser(string folderId, string userId)
        {
            var folder = Entities.Folders.FirstOrDefault(x => x.Id == folderId && !x.IsDeleted);
            folder?.InvitedUsers.RemoveAll(x=>x == userId);

            return Task.FromResult(folder);
        }
    }
}