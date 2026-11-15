using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson23.Exceptions
{
    internal class InvalidValueException : Exception
    {
        public override string Message { get; } = string.Empty;
        public DateTime ThrownAt { get; init; } = DateTime.UtcNow;

        public InvalidValueException(string message) 
            : base(message)
        {
            Message = message;
        }
    }
}
