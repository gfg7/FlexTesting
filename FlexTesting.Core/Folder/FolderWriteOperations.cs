using System.Threading.Tasks;
using FlexTesting.Core.Contract.Folder;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Folder
{
    public class FolderWriteOperations : IFolderWriteOperations
    {
        private readonly IFolderContext _folderContext;

        public FolderWriteOperations()
        {
            _folderContext = DbContext.FolderContext;
        }
        
        public async Task<Contract.Models.Folder> Create(Contract.Models.Folder item)
        {
            await _folderContext.Folders.InsertOneAsync(item);
            return item;
        }

        public async Task<Contract.Models.Folder> UpdateOne(string id, Contract.Models.Folder item)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.Id, id);
            var result = await _folderContext.Folders.UpdateOneAsync(filter, new ObjectUpdateDefinition<Contract.Models.Folder>(item));
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.Folder> Delete(string id)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.Id, id);
            var item = await _folderContext.Folders.FindSync(filter).FirstOrDefaultAsync();
            var result = await _folderContext.Folders.DeleteOneAsync(filter);
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.Folder> SafeDelete(string id)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.Id, id);
            var update = Builders<Contract.Models.Folder>.Update.Set(x => x.IsDeleted, true);
            var result = await _folderContext.Folders.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _folderContext.Folders.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.Folder> UpdateName(string folderId, string name)
        {
            var filter = Builders<Contract.Models.Folder>.Filter.Eq(x => x.Id, folderId);
            var update = Builders<Contract.Models.Folder>.Update.Set(x => x.Name, name);
            var result = await _folderContext.Folders.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _folderContext.Folders.FindSync(filter).FirstOrDefaultAsync() : null;
        }
    }
}