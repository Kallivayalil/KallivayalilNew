using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.Attributes;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    [Serializable, Audited]
    public class Constituent : Entity
    {
        public virtual string Gender { get; set; }
        public virtual BranchType BranchName { get; set; }
        public virtual string HouseName { get; set; }
        public virtual DateTime BornOn { get; set; }
        public virtual DateTime? DiedOn { get; set; }
        public virtual bool HasExpired { get; set; }
        public virtual int MaritialStatus { get; set; }
        public virtual bool IsRegistered { get; set; }

        public virtual ConstituentName Name { get; set; }
    }
}