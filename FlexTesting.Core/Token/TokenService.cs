using System;
using System.Linq;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Helpers;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Contract.Token.Dtos;
using FlexTesting.Core.Contract.User;

namespace FlexTesting.Core.Token
{
    public class TokenService : ITokenService
    {
        private readonly ITokenGetOperations _tokenGetOperations;
        private readonly ITokenWriteOperations _tokenWriteOperations;
        private readonly IUserGetOperations _userGetOperations;
        private readonly ISourceGetOperations _sourceGetOperations;

        public TokenService(ITokenGetOperations tokenGetOperations, 
            ITokenWriteOperations tokenWriteOperations, 
            IUserGetOperations userGetOperations, 
            ISourceGetOperations sourceGetOperations)
        {
            _tokenGetOperations = tokenGetOperations;
            _tokenWriteOperations = tokenWriteOperations;
            _userGetOperations = userGetOperations;
            _sourceGetOperations = sourceGetOperations;
        }

        public async Task<Contract.Models.Token> CreateToken(CreateTokenDto createTokenDto)
        {
            ValidationHelper.ValidateAndThrow(createTokenDto);
            
            if (!await _userGetOperations.ExistsById(createTokenDto.UserId))
            {
                throw new NotFoundException("Пользователь не найден");
            }

            if (!await _sourceGetOperations.ExistsById(createTokenDto.SourceId))
            {
                throw new NotFoundException("Источник не найден");
            }

            var model = new Contract.Models.Token
            {
                Id = Guid.NewGuid().ToString(),
                Payload = createTokenDto.Payload,
                SourceId = createTokenDto.SourceId,
                UserId = createTokenDto.UserId
            };

            return await _tokenWriteOperations.Create(model);
        }

        public async Task<Contract.Models.Token> DeleteToken(string tokenId, bool safeDelete = true)
        {
            if (!await _tokenGetOperations.ExistsById(tokenId))
            {
                throw new NotFoundException("Токен не найден");
            }

            return safeDelete
                ? await _tokenWriteOperations.SafeDelete(tokenId)
                : await _tokenWriteOperations.Delete(tokenId);
        }

        public async Task<Contract.Models.Token> ChangePayload(ChangeTokenPayloadDto changeTokenPayloadDto)
        {
            throw new System.NotImplementedException();
        }
    }
}