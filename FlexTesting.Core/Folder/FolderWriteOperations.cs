using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Folder
{
    public class FolderWriteOperations : WriteOperations<Contract.Models.Folder>, IFolderWriteOperations
    {
        public async Task<Contract.Models.Folder> UpdateName(string folderId, string name)
        {
            return await UpdateOne(F.Eq(x => x.Id, folderId), U.Set(x => x.Name, name));
        }

        public async Task<Contract.Models.Folder> InviteUser(string folderId, string userId)
        {
            return await UpdateOne(F.Eq(x => x.Id, folderId), U.Push(x => x.InvitedUsers, userId));
        }

        public async Task<Contract.Models.Folder> DeleteInvitedUser(string folderId, string userId)
        {
            return await UpdateOne(F.Eq(x => x.Id, folderId), U.Pull(x => x.InvitedUsers, userId));
        }

        public FolderWriteOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}