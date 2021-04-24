using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Token;

namespace FlexTesting.Tests.Mocks.TokenMocks
{
    public class TokenGetOperationsMock : ITokenGetOperations
    {
        public async Task<IEnumerable<Token>> ByUserId(string userId)
        {
            return Entities.Tokens.Where(x => x.UserId == userId && !x.IsDeleted);
        }

        public async Task<IEnumerable<Token>> ByUserAndSourceId(string userId, string sourceId)
        {
            return Entities.Tokens.Where(x => x.UserId == userId && x.SourceId == sourceId && !x.IsDeleted);
        }

        public async Task<Token> GetById(string id)
        {
            return Entities.Tokens.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Token>> GetAll(string id)
        {
            return Entities.Tokens;
        }

        public async Task<bool> ExistsById(string id)
        {
            return Entities.Tokens.Exists(x => x.Id == id);
        }
    }
}