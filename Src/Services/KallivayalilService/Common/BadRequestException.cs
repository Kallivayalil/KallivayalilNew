using System;

namespace Kallivayalil.Common
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message) {}
    }
}