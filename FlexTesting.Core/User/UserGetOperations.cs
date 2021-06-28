using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.User
{
    public class UserGetOperations : GetOperations<Contract.Models.User>, IUserGetOperations
    {
        public async Task<Contract.Models.User> ByUserName(string userName)
        {
            return await GetOne(F.Eq(x => x.Login, userName));
        }

        public async Task<Contract.Models.User> ByToken(string token)
        {
            return await GetOne(F.Eq(x => x.Token, token));
        }

        public UserGetOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}