using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    [Serializable]
    public class ConstituentName : Entity
    {

        public override string ToString()
        {
            return string.Format("{3}. {0} {1} {2}", FirstName, MiddleName, LastName, Salutation.Description);
        }

        public virtual string FirstName { get; set; }

        public virtual string MiddleName { get; set; }

        public virtual string LastName { get; set; }

        public virtual string PreferedName { get; set; }
        public virtual SalutationType Salutation { get; set; }
    }
}