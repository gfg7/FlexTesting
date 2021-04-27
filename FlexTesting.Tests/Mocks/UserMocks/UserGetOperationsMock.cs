using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.User;

namespace FlexTesting.Tests.Mocks.UserMocks
{
    public class UserGetOperationsMock : IUserGetOperations
    {
        private static List<User> _users;

        public UserGetOperationsMock()
        {
            _users = Entities.UsersList;
        }
        
        public Task<User> GetById(string id)
        {
            return Task.FromResult(_users.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<User>> GetAll()
        {
            return Task.FromResult(_users.AsEnumerable());
        }

        public Task<bool> ExistsById(string id)
        {
            return Task.FromResult(Entities.UsersList.Exists(x => x.Id == id));
        }

        public Task<User> ByUserName(string userName)
        {
            return Task.FromResult(_users.FirstOrDefault(x => x.Login == userName));
        }

        public Task<User> ByToken(string token)
        {
            return Task.FromResult(_users.FirstOrDefault(x => x.Token == token));
        }
    }
}