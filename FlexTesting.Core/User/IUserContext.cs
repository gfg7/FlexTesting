using MongoDB.Driver;

namespace FlexTesting.Core.User
{
    public interface IUserContext
    {
        public IMongoCollection<Contract.Models.User> Users { get; }
    }
}