using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.TaskStatus;
using FlexTesting.Tests.Mocks.FolderMocks;
using FlexTesting.Tests.Mocks.SourceMocks;
using FlexTesting.Tests.Mocks.StatusMocks;

namespace FlexTesting.Tests.TaskStatusTests
{
    public abstract class BaseTaskStatusTest
    {
        protected ITaskStatusService _taskStatusService;

        protected BaseTaskStatusTest()
        {
            _taskStatusService = new TaskStatusService(
                new TaskStatusGetOperationsMock(),
                new TaskStatusWriteOperationsMock(),
                new FolderGetOperationsMock(),
                new SourceGetOperationsMock());
        }
    }
}