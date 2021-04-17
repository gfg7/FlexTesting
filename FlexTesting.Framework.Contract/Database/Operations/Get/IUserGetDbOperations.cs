using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Database.Operations.Get
{
    public interface IUserGetDbOperations : IGetOperations<UserDocument>
    {
        public Task<UserDocument> ByToken(string token);
        public Task<UserDocument> ByCredentials(string login, string password);
        public Task<UserDocument> ByLogin(string login);
    }
}