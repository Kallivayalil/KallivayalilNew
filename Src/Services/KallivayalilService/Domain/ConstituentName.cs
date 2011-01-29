using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    [Serializable]
    public class ConstituentName : Entity
    {
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PreferedName { get; set; }
        public virtual SalutationType Salutation { get; set; }
    }
}