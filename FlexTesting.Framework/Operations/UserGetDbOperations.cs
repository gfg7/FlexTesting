using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Database.Operations.Get;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Operations
{
    public class UserGetDbOperations : IUserGetDbOperations
    {
        public async Task<UserDocument> ById(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<UserDocument>> ByIds(params string[] ids)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<UserDocument>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> ByToken(string token)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> ByCredentials(string login, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> ByLogin(string login)
        {
            throw new System.NotImplementedException();
        }
    }
}