using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Token;

namespace FlexTesting.Tests.Mocks.TokenMocks
{
    public class TokenWriteOperationsMock : ITokenWriteOperations
    {
        public async Task<Token> Create(Token item)
        {
            Entities.Tokens.Add(item);
            return item;
        }

        public async Task<Token> Update(string id, Token item)
        {
            Entities.Tokens.RemoveAll(x => x.Id == id);
            Entities.Tokens.Add(item);
            return item;
        }

        public async Task<Token> Delete(string id)
        {
            var token = Entities.Tokens.FirstOrDefault(x => x.Id == id);
            Entities.Tokens.RemoveAll(x => x.Id == id);

            return token;
        }

        public async Task<Token> SafeDelete(string id)
        {
            var token = Entities.Tokens.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if(token is not null)
                token.IsDeleted = true;
            
            return token;
        }

        public async Task<Token> UpdatePayload(string tokenId, string payload)
        {
            var token = Entities.Tokens.FirstOrDefault(x => x.Id == tokenId && !x.IsDeleted);
            if(token is not null)
                token.Payload = payload;
            
            return token;
        }
    }
}