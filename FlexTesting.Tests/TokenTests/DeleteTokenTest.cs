using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using NUnit.Framework;

namespace FlexTesting.Tests.TokenTests
{
    [TestFixture]
    public class DeleteTokenTest : BaseTokenTest
    {
        [Test]
        public async Task DeleteExistingTokenTest()
        {
            var result = await _tokenService.DeleteToken("del");
            Assert.True(result.IsDeleted);
        }

        [Test]
        public async Task DeleteNotExistingTokenTest()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _tokenService.DeleteToken("aaaaaaaaa"));
        }
    }
}