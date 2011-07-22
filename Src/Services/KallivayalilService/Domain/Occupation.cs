using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Occupation : Entity
    {
        public virtual OccupationType Type { get; set; }
        public virtual string OccupationName { get; set; }
        public virtual string Description { get; set; }
        public virtual Address Address { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}