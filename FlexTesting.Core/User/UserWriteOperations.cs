using System.Threading.Tasks;
using FlexTesting.Core.Contract.User;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.User
{
    public class UserWriteOperations : IUserWriteOperations
    {
        private readonly IUserContext _userContext;

        public UserWriteOperations()
        {
            _userContext = DbContext.UserContext;
        }
        public async Task<Contract.Models.User> Create(Contract.Models.User item)
        {
            await _userContext.Users.InsertOneAsync(item);
            return item;
        }

        public async Task<Contract.Models.User> UpdateOne(string id, Contract.Models.User item)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, id);
            var result = await _userContext.Users.UpdateOneAsync(filter, new ObjectUpdateDefinition<Contract.Models.User>(item));
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.User> Delete(string id)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, id);
            var item = await _userContext.Users.FindSync(filter).FirstOrDefaultAsync();
            var result = await _userContext.Users.DeleteOneAsync(filter);
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.User> SafeDelete(string id)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, id);
            var update = Builders<Contract.Models.User>.Update.Set(x => x.IsDeleted, true);
            var result = await _userContext.Users.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _userContext.Users.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.User> UpdatePassword(string userId, string password, string salt)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<Contract.Models.User>.Update.Set(x => x.Password, password).Set(x=>x.Salt, salt);
            var result = await _userContext.Users.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _userContext.Users.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.User> UpdateUsername(string userId, string userName)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<Contract.Models.User>.Update.Set(x => x.Login, userName);
            var result = await _userContext.Users.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _userContext.Users.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.User> UpdateFio(string userId, string firstName, string lastName, string middleName)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<Contract.Models.User>.Update
                .Set(x => x.FirstName, firstName)
                .Set(x=>x.LastName, lastName)
                .Set(x=>x.MiddleName, middleName);
            var result = await _userContext.Users.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _userContext.Users.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.User> SetToken(string userId, string token)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<Contract.Models.User>.Update.Set(x => x.Token, token);
            var result = await _userContext.Users.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _userContext.Users.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.User> UnsetToken(string userId)
        {
            var filter = Builders<Contract.Models.User>.Filter.Eq(x => x.Id, userId);
            var update = Builders<Contract.Models.User>.Update.Unset(x => x.Token);
            var result = await _userContext.Users.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _userContext.Users.FindSync(filter).FirstOrDefaultAsync() : null;
        }
    }
}