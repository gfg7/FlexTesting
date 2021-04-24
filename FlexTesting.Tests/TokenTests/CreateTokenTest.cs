using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Token;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.TokenTests
{
    [TestFixture]
    public class CreateTokenTest : BaseTokenTest
    {
        [Test]
        public async Task CreateValidTokenTest()
        {
            var result = await _tokenService.CreateToken(TokenHelper.CreateTokenDto);
            Assert.NotNull(result);
            Assert.AreEqual(TokenHelper.CreateTokenDto.UserId, result.UserId);
            Assert.AreEqual(TokenHelper.CreateTokenDto.SourceId, result.SourceId);
        }

        [Test]
        public async Task CreateInvalidTokenTest()
        {
            var dto = new CreateTokenDto();
            Assert.ThrowsAsync<ValidationException>(async () => await _tokenService.CreateToken(dto));
        }
    }
}