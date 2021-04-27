using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.Token
{
    public class TokenGetOperations : ITokenGetOperations
    {
        private readonly ITokenContext _tokenContext;

        public TokenGetOperations()
        {
            _tokenContext = DbContext.TokenContext;
        }
        
        public async Task<Contract.Models.Token> GetById(string id)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.Id, id);
            return await _tokenContext.Tokens.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Contract.Models.Token>> GetAll()
        {
            return await _tokenContext.Tokens.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<bool> ExistsById(string id)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.Id, id);
            return await _tokenContext.Tokens.CountDocumentsAsync(filter) != 0;
        }

        public async Task<IEnumerable<Contract.Models.Token>> ByUserId(string userId)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.UserId, userId);
            return await _tokenContext.Tokens.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Contract.Models.Token>> ByUserAndSourceId(string userId, string sourceId)
        {
            var filter = Builders<Contract.Models.Token>.Filter.Eq(x => x.UserId, userId) 
                         & Builders<Contract.Models.Token>.Filter.Eq(x => x.SourceId, sourceId);
            return await _tokenContext.Tokens.Find(filter).ToListAsync();
        }
    }
}