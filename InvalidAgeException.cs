using System;

namespace FileHandlerApp.Exceptions
{
    public class InvalidAgeException : Exception
    {
        public InvalidAgeException(string message) : base(message) { }
    }
}
