using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Database;
using MongoDB.Driver;

namespace FlexTesting.Core.Token
{
    public class TokenWriteOperations : WriteOperations<Contract.Models.Token>, ITokenWriteOperations
    {
        public async Task<Contract.Models.Token> UpdatePayload(string tokenId, string payload)
        {
            return await UpdateOne(F.Eq(x => x.Id, tokenId), U.Set(x => x.Payload, payload));
        }

        public TokenWriteOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}