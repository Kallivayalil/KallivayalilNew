using Kallivayalil.Common;

namespace Kallivayalil.Domain.ReferenceData
{
    public class AssociationType : Entity
    {
        public virtual AssociationType ReciprocalType { get; set; }
        public virtual string Description { get; set; }
    }
}