using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson23.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
        public InvalidPasswordException(string message) : base(message)
        {
            
        }
    }
}
