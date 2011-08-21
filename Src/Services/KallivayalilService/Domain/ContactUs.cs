using System;
using Kallivayalil.Common;

namespace Kallivayalil.Domain
{
    [Serializable]
    public class ContactUs : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Comments { get; set; }
        public virtual string Email { get; set; }
    }
}