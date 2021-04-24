using FlexTesting.Core.Contract.Token;
using FlexTesting.Core.Token;

namespace FlexTesting.Tests.TokenTests
{
    public abstract class BaseTokenTest
    {
        protected ITokenService _tokenService;

        protected BaseTokenTest()
        {
            _tokenService = new TokenService();
        }
    }
}