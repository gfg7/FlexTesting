using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.User
{
    public interface IUserWriteOperations : IWriteOperations<Models.User>
    {
        public Task<Models.User> UpdatePassword(string userId, string password);
        public Task<Models.User> UpdateUsername(string userId, string userName);
        public Task<Models.User> SetToken(string userId, string token);
        public Task<Models.User> UnsetToken(string userId);
    }
}