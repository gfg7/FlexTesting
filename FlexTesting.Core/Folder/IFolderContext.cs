using MongoDB.Driver;

namespace FlexTesting.Core.Folder
{
    public interface IFolderContext
    {
        public IMongoCollection<Contract.Models.Folder> Folders { get; }
    }
}