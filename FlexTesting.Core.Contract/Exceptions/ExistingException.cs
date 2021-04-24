using System;

namespace FlexTesting.Core.Contract.Exceptions
{
    public class ExistingException : Exception
    {
        public ExistingException(string message) : base(message)
        {}
    }
}