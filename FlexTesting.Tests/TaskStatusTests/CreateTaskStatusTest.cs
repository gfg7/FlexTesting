using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FlexTesting.Core.Contract.Exceptions;
using FlexTesting.Core.Contract.Source;
using FlexTesting.Core.Contract.TaskStatus.Dtos;
using NUnit.Framework;

namespace FlexTesting.Tests.TaskStatusTests
{
    [TestFixture]
    public class CreateTaskStatusTest : BaseTaskStatusTest
    {
        [Test]
        public async Task CreateValidStatus()
        {
            var dto = new CreateStatusDto
            {
                Name = "todo",
                SourceId = SourceIds.Flex.ToString()
            };
            var result = await _taskStatusService.Create(dto);
            
            Assert.NotNull(result);
            Assert.IsNotEmpty(result.Id);
            Assert.AreEqual(dto.Name, result.Name);
        }

        [Test]
        public async Task CreateInvalidStatus()
        {
            Assert.ThrowsAsync<ValidationException>(async () => await _taskStatusService.Create(new CreateStatusDto()));
        }
        
        [Test]
        public async Task CreateStatusWithNotExistingFolder()
        {
            var dto = new CreateStatusDto
            {
                Name = "a",
                FolderId = "aaaaa"
            };
            Assert.ThrowsAsync<NotFoundException>(async () => await _taskStatusService.Create(dto));
        }
    }
}