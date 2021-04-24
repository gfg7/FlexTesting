using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.User
{
    public interface IUserWriteOperations : IWriteOperations<Models.User>
    {
        public Task<Models.User> UpdatePassword(string userId, string password, string salt);
        public Task<Models.User> UpdateUsername(string userId, string userName);
        public Task<Models.User> UpdateFio(string userId, string firstName, string lastName, string middleName);
        public Task<Models.User> SetToken(string userId, string token);
        public Task<Models.User> UnsetToken(string userId);
    }
}