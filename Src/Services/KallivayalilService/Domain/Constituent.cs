using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.Attributes;

namespace Kallivayalil.Domain
{
    [Serializable, Audited]
    public class Constituent : Entity
    {
//        [DocumentId]
//        public override int Id { get; set; }
        public virtual string Gender { get; set; }
        public virtual int BranchName { get; set; }
        public virtual string HouseName { get; set; }
        public virtual DateTime BornOn { get; set; }
        public virtual DateTime? DiedOn { get; set; }
        public virtual bool HasExpired { get; set; }
        public virtual int MaritialStatus { get; set; }
        public virtual bool IsRegistered { get; set; }

//        [IndexedEmbedded]
        public virtual ConstituentName Name { get; set; }
    }
}