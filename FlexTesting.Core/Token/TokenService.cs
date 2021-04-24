using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Contract.Token.Dtos;

namespace FlexTesting.Core.Token
{
    public class TokenService : ITokenService
    {
        public async Task<Contract.Models.Token> CreateToken(CreateTokenDto createTokenDto)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Token> DeleteToken(string tokenId, bool safeDelete)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Contract.Models.Token> ChangePayload(ChangeTokenPayloadDto changeTokenPayloadDto)
        {
            throw new System.NotImplementedException();
        }
    }
}