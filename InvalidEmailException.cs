using System;

namespace FileHandlerApp.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message, string innerMessage)
            : base(message, new Exception(innerMessage)) { }
    }
}
