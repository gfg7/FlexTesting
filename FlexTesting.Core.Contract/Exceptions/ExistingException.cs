using System;

namespace FlexTesting.Core.Contract.Exceptions
{
    public class ExistingException : BusinessException
    {
        public ExistingException(string message) : base(message)
        {}
    }
}