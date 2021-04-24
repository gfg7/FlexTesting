using System;

namespace FlexTesting.Core.Contract.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message){}
    }
    
    public class ExistingUserException : Exception
    {
        public ExistingUserException() : base("Пользователь уже существует"){}
    }
    
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException() : base("Неверный пароль"){}
    }
}