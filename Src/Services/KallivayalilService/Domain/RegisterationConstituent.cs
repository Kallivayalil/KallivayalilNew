using System;
using Kallivayalil.Domain.Attributes;

namespace Kallivayalil.Domain
{
    [Serializable, Audited]
    public class RegisterationConstituent
    {
        public Constituent Constituent { get; set; }
        public Phone Phone { get; set; }        
        public Address Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}