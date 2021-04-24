using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.Folder
{
    public interface IFolderGetOperations : IGetOperations<Models.Folder>
    {
        public Task<Models.Folder> ByNameAndUser(string name, string userId);
        public Task<IEnumerable<Models.Folder>> ByUser(string userId);
    }
}