using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.Folder
{
    public interface IFolderWriteOperations : IWriteOperations<Models.Folder>
    {
        public Task<Models.Folder> UpdateName(string folderId, string name);
        public Task<Models.Folder> InviteUser(string folderId, string userId);
    }
}