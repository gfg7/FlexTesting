using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.TaskStatusTests
{
    [TestFixture]
    public class GetStatusesByFolderTest : BaseTaskStatusTest
    {
        [Test]
        public async Task GetByFolderNotEmptyTest()
        {
            var result = await _taskStatusService.GetByFolder(FolderHelper.ValidFolder.Id);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task GetByNotExistingFolder()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _taskStatusService.GetByFolder("ddd"));
        }
    }
}