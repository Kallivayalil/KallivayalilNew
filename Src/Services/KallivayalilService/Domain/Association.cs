using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Association : Entity
    {
        public virtual AssociationType Type { get; set; }
        public virtual Constituent Constituent { get; set; }
        public virtual Constituent AssociatedConstituent { get; set; }
        public virtual Association ReciprocalAssociation { get; set; }
        public virtual string AssociatedConstituentName { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }

        public virtual void CreateReciprocal()
        {
            if(IsHardAssociation())
            ReciprocalAssociation = new Association()
                       {
                           Constituent = AssociatedConstituent,
                           AssociatedConstituent = Constituent,
                           AssociatedConstituentName = AssociatedConstituentName,
                           StartDate = StartDate,
                           EndDate = EndDate,
                           ReciprocalAssociation = ReciprocalAssociation,
                           Type = Type.ReciprocalType
                       };
        }

        private bool IsHardAssociation()
        {
            return !IsNull(AssociatedConstituent) && !string.IsNullOrEmpty(AssociatedConstituentName);
        }
    }
}