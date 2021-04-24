﻿using System.Linq;
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

        public Task Delete(string id)
        {
            Entities.UsersList.RemoveAll(x => x.Id == id);
            return Task.CompletedTask;
        }

        public async Task<User> UpdatePassword(string userId, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> UpdateUsername(string userId, string userName)
        {
            throw new System.NotImplementedException();
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