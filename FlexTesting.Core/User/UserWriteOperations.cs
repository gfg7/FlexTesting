using System.Threading.Tasks;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.User
{
    public class UserWriteOperations : WriteOperations<Contract.Models.User>, IUserWriteOperations
    {
        public async Task<Contract.Models.User> UpdatePassword(string userId, string password, string salt)
        {
            return await UpdateOne(
                F.Eq(x => x.Id, userId), 
                U.Set(x => x.Password, password).Set(x => x.Salt, salt));
        }

        public async Task<Contract.Models.User> UpdateUsername(string userId, string userName)
        {
            return await UpdateOne(F.Eq(x => x.Id, userId), U.Set(x => x.Login, userName));
        }

        public async Task<Contract.Models.User> UpdateFio(string userId, string firstName, string lastName, string middleName)
        {
            var filter = F.Eq(x => x.Id, userId);
            var update = U
                .Set(x => x.FirstName, firstName)
                .Set(x=>x.LastName, lastName)
                .Set(x=>x.MiddleName, middleName);
            return await UpdateOne(filter, update);
        }

        public async Task<Contract.Models.User> SetToken(string userId, string token)
        {
            return await UpdateOne(F.Eq(x => x.Id, userId), U.Set(x => x.Token, token));
        }

        public async Task<Contract.Models.User> UnsetToken(string token)
        {
            return await UpdateOne(F.Eq(x => x.Token, token), U.Set(x => x.Token, null));
        }

        public async Task<Contract.Models.User> ConfirmEmail(string userId)
        {
            return await UpdateOne(F.Eq(x => x.Id, userId), U.Set(x => x.IsEmailConfirmed, true));
        }

        public async Task<Contract.Models.User> SetEmailCode(string userId, string code)
        {
            return await UpdateOne(F.Eq(x => x.Id, userId), U.Set(x => x.EmailCode, code));
        }

        public UserWriteOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}