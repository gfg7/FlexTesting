using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.Folder
{
    public class FolderGetOperations : IFolderGetOperations
    {
        private readonly IFolderContext _folderContext;

        public FolderGetOperations()
        {
            _folderContext = DbContext.FolderContext;
        }
        
        public async Task<Contract.Models.Folder> GetById(string id)
        {
            return await _folderContext.Folders.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract.Models.Folder>> GetAll()
        {
            return await _folderContext.Folders.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> ExistsById(string id)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.Id, id);
            return await _folderContext.Folders.CountDocumentsAsync(filter) != 0;
        }

        public async Task<Contract.Models.Folder> ByNameAndUser(string name, string userId)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.Name, name)
                & Builders<Contract.Models.Folder>.Filter.Eq(x => x.UserId, userId);
            return await _folderContext.Folders.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract.Models.Folder>> ByUser(string userId)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.UserId, userId);
            return await _folderContext.Folders.Find(filter).ToListAsync();
        }
    }
}