using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.Folder
{
    public class FolderGetOperations : GetOperations<Contract.Models.Folder>, IFolderGetOperations
    {
        public async Task<Contract.Models.Folder> ByNameAndUser(string name, string userId)
        {
            return await GetOne(F.And(F.Eq(x => x.Name, name), F.Eq(x => x.UserId, userId)));
        }

        public async Task<IEnumerable<Contract.Models.Folder>> ByUser(string userId)
        {
            return await GetList(F.Eq(x => x.UserId, userId));
        }

        public FolderGetOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}