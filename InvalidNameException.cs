using System;

namespace FileHandlerApp.Exceptions
{
    public class InvalidNameException : Exception
    {
        public InvalidNameException(string message) : base(message) { }
    }
}
