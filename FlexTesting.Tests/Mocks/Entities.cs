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

            Sources = new List<Source>
            {
                Core.Contract.Source.Sources.SpaceSource,
                Core.Contract.Source.Sources.TrelloSource
            };

            Tokens = new List<Token>
            {
                TokenHelper.ValidToken,
                TokenHelper.DeletionToken
            };
        }
        public static List<User> UsersList { get; set; }
        public static List<Token> Tokens { get; set; }
        public static List<Source> Sources { get; set; }
    }
}