using System;

namespace FlexTesting.Core.Contract.Exceptions
{
    public class UserNoConfirmException : BusinessException
    {
        public UserNoConfirmException(Models.User user) : base($"{user.FirstName} {user.MiddleName}, ваш email не подтверждён. Проверьте почту {user.Email}")
        {}
    }
}