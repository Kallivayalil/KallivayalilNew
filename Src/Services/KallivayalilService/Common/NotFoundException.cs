using System;

namespace Kallivayalil.Common
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) {}
    }
}