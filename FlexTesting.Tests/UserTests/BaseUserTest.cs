using FlexTesting.Core.User;
using FlexTesting.Tests.Mocks;
using FlexTesting.Tests.Mocks.UserMocks;

namespace FlexTesting.Tests.UserTests
{
    public abstract class BaseUserTest
    {
        protected UserService _userService;

        public BaseUserTest()
        {
            _userService = new UserService(new UserGetOperationsMock(), new UserWriteOperationsMock(), new EmailService(new UserGetOperationsMock(), new UserWriteOperationsMock()));
        }
    }
}