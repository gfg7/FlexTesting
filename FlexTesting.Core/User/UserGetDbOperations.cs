using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.User
{
    public class UserGetDbOperations : IUserGetOperations
    {
        private readonly IUserContext _userContext;
        public UserGetDbOperations()
        {
            _userContext = DbContext.UserContext;
        }
        public async Task<Contract.Models.User> GetById(string id)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, id);
            return await _userContext.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract.Models.User>> GetAll()
        {
            return await _userContext.Users.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> ExistsById(string id)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, id);
            return await _userContext.Users.CountDocumentsAsync(filter) != 0;
        }

        public async Task<Contract.Models.User> ByUserName(string userName)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Login, userName);
            return await _userContext.Users.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<Contract.Models.User> ByToken(string token)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Token, token);
            return await _userContext.Users.Find(filter).FirstOrDefaultAsync();
        }
    }
}