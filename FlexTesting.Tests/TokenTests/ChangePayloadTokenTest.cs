using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Models;
using FlexTesting.Core.Contract.Token.Dtos;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.TokenTests
{
    [TestFixture]
    public class ChangePayloadTokenTest : BaseTokenTest
    {
        [Test]
        public async Task ChangeValidPayloadTest()
        {
            var dto = new ChangeTokenPayloadDto
            {
                Payload = "new_payload",
                TokenId = TokenHelper.ValidToken.Id
            };

            var result = await _tokenService.ChangePayload(dto);
            Assert.AreEqual(TokenHelper.ValidToken.Id, result.Id);
        }

        [Test]
        public async Task ChangeInvalidTokenPayloadTest()
        {
            var dto = new ChangeTokenPayloadDto();
            Assert.ThrowsAsync<ValidationException>(async () => await _tokenService.ChangePayload(dto));
        }
        
        [Test]
        public async Task ChangeNotExistingTokenPayloadTest()
        {
            var dto = new ChangeTokenPayloadDto
            {
                TokenId = "sssssss",
                Payload = "a"
            };
            Assert.ThrowsAsync<NotFoundException>(async () => await _tokenService.ChangePayload(dto));
        }
    }
}