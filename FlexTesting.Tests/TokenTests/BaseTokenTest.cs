using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Token;
using FlexTesting.Tests.Mocks.SourceMocks;
using FlexTesting.Tests.Mocks.TokenMocks;
using FlexTesting.Tests.Mocks.UserMocks;

namespace FlexTesting.Tests.TokenTests
{
    public abstract class BaseTokenTest
    {
        protected ITokenService _tokenService;

        protected BaseTokenTest()
        {
            _tokenService = new TokenService(
                new TokenGetOperationsMock(), 
                new TokenWriteOperationsMock(),
                new UserGetOperationsMock(), 
                new SourceGetOperationsMock());
        }
    }
}