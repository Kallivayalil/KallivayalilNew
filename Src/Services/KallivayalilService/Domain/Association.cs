using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Association : Entity
    {
        public virtual AssociationType AssociationType { get; set; }
        public virtual Constituent Constituent { get; set; }
        public virtual Constituent AssociatedConstituent { get; set; }
        public virtual Association ReciprocalAssociation { get; set; }
        public virtual string AssociatedConstituentName { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
    }
}