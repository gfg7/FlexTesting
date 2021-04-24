using FlexTesting.Core.User;
using FlexTesting.Tests.Mocks;

namespace FlexTesting.Tests.UserTests
{
    public abstract class BaseUserTest
    {
        protected UserService _userService;

        public BaseUserTest()
        {
            _userService = new UserService(new UserGetOperationsMock(), new UserWriteOperationsMock());
        }
    }
}