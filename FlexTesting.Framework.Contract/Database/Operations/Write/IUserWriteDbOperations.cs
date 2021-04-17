using System.Threading.Tasks;
using FlexTesting.Framework.Contract.Document;

namespace FlexTesting.Framework.Contract.Database.Operations.Write
{
    public interface IUserWriteDbOperations : IWriteOperations<UserDocument>
    {
        public Task<UserDocument> SetToken(string userId, string token);
    }
}