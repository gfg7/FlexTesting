using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Database;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlexTesting.Core.Token
{
    public class TokenGetOperations : GetOperations<Contract.Models.Token>, ITokenGetOperations
    {
        public async Task<IEnumerable<Contract.Models.Token>> ByUserId(string userId)
        {
            return await GetList(F.Eq(x => x.UserId, userId));
        }

        public async Task<IEnumerable<Contract.Models.Token>> ByUserAndSourceId(string userId, string sourceId)
        {
            return await GetList(F.And(F.Eq(x => x.UserId, userId), F.Eq(x => x.SourceId, sourceId)));
        }

        public TokenGetOperations(DbContext dbContext) : base(dbContext)
        {
        }
    }
}