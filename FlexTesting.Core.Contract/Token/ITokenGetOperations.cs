using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlexTesting.Core.Contract.Token
{
    public interface ITokenGetOperations
    {
        public Task<IEnumerable<Models.Token>> ByUserId(string userId);
        public Task<IEnumerable<Models.Token>> ByUserAndSourceId(string userId, string sourceId);
    }
}