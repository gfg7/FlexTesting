using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.TaskStatusTests
{
    [TestFixture]
    public class DeleteTaskStatusTest : BaseTaskStatusTest
    {
        public async Task DeleteExistingStatus()
        {
            var result = await _taskStatusService.Delete(StatusHelper.DeletionStatus.Id);
            Assert.True(result.IsDeleted);
        }

        public async Task DeleteNotExistingStatus()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => await _taskStatusService.Delete("aa"));
        }
    }
}