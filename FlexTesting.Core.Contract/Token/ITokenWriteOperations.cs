using System.Threading.Tasks;
using FlexTesting.Core.Contract.Operations.WriteOperations;

namespace FlexTesting.Core.Contract.Token
{
    public interface ITokenWriteOperations : IWriteOperations<Models.Token>
    {
        public Task<Models.Token> UpdatePayload(string tokenId, string payload);
    }
}