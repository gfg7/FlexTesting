using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.Folder
{
    public interface IFolderGetOperations : IGetOperations<Models.Folder>
    {
        public Task<Models.Folder> ByName(string name);
        public Task<Models.Folder> ByUser(string userId);
    }
}