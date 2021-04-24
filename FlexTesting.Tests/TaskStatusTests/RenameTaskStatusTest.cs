using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.TaskStatus.Dtos;
using FlexTesting.Tests.Helpers;
using NUnit.Framework;

namespace FlexTesting.Tests.TaskStatusTests
{
    [TestFixture]
    public class RenameTaskStatusTest : BaseTaskStatusTest
    {
        [Test]
        public async Task RenameExistingStatus()
        {
            var dto = new RenameTaskStatusDto
            {
                NewName = "newname",
                TaskStatusId = StatusHelper.ValidStatus.Id
            };

            var result = await _taskStatusService.Rename(dto);
            Assert.AreEqual(dto.NewName, result.Name);
        }

        [Test]
        public async Task RenameNotExistingStatus()
        {
            var dto = new RenameTaskStatusDto
            {
                TaskStatusId = "aa",
                NewName = "a"
            };
            Assert.ThrowsAsync<NotFoundException>(async () => await _taskStatusService.Rename(dto));
        }
        
        [Test]
        public async Task InvalidDtoRenameStatus()
        {
            var dto = new RenameTaskStatusDto();
            Assert.ThrowsAsync<ValidationException>(async () => await _taskStatusService.Rename(dto));
        }
    }
}