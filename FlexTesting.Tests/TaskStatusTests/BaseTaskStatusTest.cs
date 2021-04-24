using FlexTesting.Core.Contract.TaskStatus;
using FlexTesting.Core.TaskStatus;

namespace FlexTesting.Tests.TaskStatusTests
{
    public abstract class BaseTaskStatusTest
    {
        protected ITaskStatusService _taskStatusService;

        protected BaseTaskStatusTest()
        {
            _taskStatusService = new TaskStatusService();
        }
    }
}