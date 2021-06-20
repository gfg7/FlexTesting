using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Token
{
    public class TokenWriteOperations : ITokenWriteOperations
    {
        private readonly ITokenContext _tokenContext;

        public TokenWriteOperations()
        {
            _tokenContext = DbContext.TokenContext;
        }
        
        public async Task<Contract.Models.Token> Create(Contract.Models.Token item)
        {
            await _tokenContext.Tokens.InsertOneAsync(item);
            return item;
        }

        public async Task<Contract.Models.Token> Update(string id, Contract.Models.Token item)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.Id, id);
            var result = await _tokenContext.Tokens.UpdateOneAsync(filter, new ObjectUpdateDefinition<Contract.Models.Token>(item));
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.Token> Delete(string id)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.Id, id);
            var item = await _tokenContext.Tokens.FindSync(filter).FirstOrDefaultAsync();
            var result = await _tokenContext.Tokens.DeleteOneAsync(filter);
            return result.IsAcknowledged ? item : null;
        }

        public async Task<Contract.Models.Token> SafeDelete(string id)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.Id, id);
            var update = Builders<Contract.Models.Token>.Update.Set(x => x.IsDeleted, true);
            var result = await _tokenContext.Tokens.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _tokenContext.Tokens.FindSync(filter).FirstOrDefaultAsync() : null;
        }

        public async Task<Contract.Models.Token> UpdatePayload(string tokenId, string payload)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.Id, tokenId);
            var update = Builders<Contract.Models.Token>.Update.Set(x => x.Payload, payload);
            var result = await _tokenContext.Tokens.UpdateOneAsync(filter, update);
            return result.IsAcknowledged ? await _tokenContext.Tokens.FindSync(filter).FirstOrDefaultAsync() : null;
        }
    }
}