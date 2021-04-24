using System.Collections.Generic;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Tests.Helpers;

namespace FlexTesting.Tests.Mocks
{
    public static class Entities
    {
        static Entities()
        {
            UsersList = new List<User>();
            UsersList.Add(UserHelper.UserModel);
            UsersList.Add(UserHelper.OtherUserModel);
            UsersList.Add(UserHelper.DeletingUserModel);
        }
        public static List<User> UsersList { get; set; }
    }
}