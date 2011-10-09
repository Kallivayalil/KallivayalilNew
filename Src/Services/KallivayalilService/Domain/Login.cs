using System;
using Kallivayalil.Common;

namespace Kallivayalil.Domain
{
    public class Login : Entity
    {
        public virtual Email Email { get; set; }
        public virtual string Password { get; set; }
        public virtual bool IsAdmin { get; set; }
    }
}