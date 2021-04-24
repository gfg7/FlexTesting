using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.GetOperations;

namespace FlexTesting.Core.Contract.Token
{
    public interface ITokenGetOperations : IGetOperations<Models.Token>
    {
        public Task<IEnumerable<Models.Token>> ByUserId(string userId);
        public Task<IEnumerable<Models.Token>> ByUserAndSourceId(string userId, string sourceId);
    }
}