using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token.Dtos;

namespace FlexTesting.Core.Contract.Token
{
    public interface ITokenService
    {
        public Task<Models.Token> CreateToken(CreateTokenDto createTokenDto);
        public Task<Models.Token> DeleteToken(string tokenId, bool safeDelete);
        public Task<Models.Token> ChangePayload(ChangeTokenPayloadDto changeTokenPayloadDto);
    }
}