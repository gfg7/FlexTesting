using MongoDB.Driver;

namespace FlexTesting.Core.Token
{
    public interface ITokenContext
    {
        public IMongoCollection<Contract.Models.Token> Tokens { get; }
    }
}