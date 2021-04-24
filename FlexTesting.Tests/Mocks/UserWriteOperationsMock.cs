using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;

namespace FlexTesting.Tests.Mocks
{
    public class UserWriteOperationsMock : IUserWriteOperations
    {
        public Task<User> Create(User item)
        {
            Entities.UsersList.Add(item);
            return Task.FromResult(item);
        }

        public Task<User> UpdateOne(string id, User item)
        {
            Entities.UsersList.RemoveAll(x => x.Id == id);
            Entities.UsersList.Add(item);
            return Task.FromResult(item);
        }

        public Task<User> Delete(string id)
        {
            var user = Entities.UsersList.FirstOrDefault(x => x.Id == id);
            Entities.UsersList.RemoveAll(x => x.Id == id);
            return Task.FromResult(user);
        }

        public async Task<User> SafeDelete(string id)
        {
            var user = Entities.UsersList.FirstOrDefault(x => x.Id == id);
            if (user is not null)
            {
                user.IsDeleted = true;
                user.Token = string.Empty;
            }

            return user;
        }

        public async Task<User> UpdatePassword(string userId, string password, string salt)
        {
            var user = Entities.UsersList.FirstOrDefault(x => x.Id == userId);
            if (user is not null)
            {
                user.Password = password;
                user.Salt = salt;
            }

            return user;
        }

        public async Task<User> UpdateUsername(string userId, string userName)
        {
            var user = Entities.UsersList.FirstOrDefault(x => x.Id == userId);
            if(user is not null)
                user.Login = userName;

            return user;
        }

        public async Task<User> UpdateFio(string userId, string firstName, string lastName, string middleName)
        {
            var user = Entities.UsersList.FirstOrDefault(x => x.Id == userId);
            if (user is not null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.MiddleName = middleName;
            }

            return user;
        }

        public async Task<User> SetToken(string userId, string token)
        {
            var user = Entities.UsersList.FirstOrDefault(x => x.Id == userId);
            if(user is not null)
                user.Token = token;

            return user;
        }

        public async Task<User> UnsetToken(string userId)
        {
            throw new System.NotImplementedException();
        }
    }
}