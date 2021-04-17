using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Database.Operations.Write;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Operations
{
    public class UserWriteDbOperations : IUserWriteDbOperations
    {
        public async Task<UserDocument> Insert(UserDocument item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> Upsert(UserDocument item)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> Update()
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> SafeDelete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> UnsafeDelete(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserDocument> SetToken(string userId, string token)
        {
            throw new System.NotImplementedException();
        }
    }
}