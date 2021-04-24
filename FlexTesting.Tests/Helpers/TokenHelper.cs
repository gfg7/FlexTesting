using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Contract.Token;

namespace FlexTesting.Tests.Helpers
{
    public class TokenHelper
    {
        public static Token ValidToken => new()
        {
            Id = "qwertyuiopsdfghjkl",
            SourceId = SourceIds.Space.ToString(),
            Payload = "apikey_ahahah",
            UserId = UserHelper.UserModel.Id
        };
        
        public static Token DeletionToken => new()
        {
            Id = "del",
            SourceId = SourceIds.Trello.ToString(),
            Payload = "del",
            UserId = UserHelper.UserModel.Id
        };

        public static CreateTokenDto CreateTokenDto => new()
        {
            Payload = "api_key_for_creation",
            SourceId = SourceIds.Trello.ToString(),
            UserId = UserHelper.UserModel.Id
        };
    }
}