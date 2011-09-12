using System;
using System.Collections.Generic;
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
        public virtual IList<Email> Emails { get; set; }
        public virtual IList<Address> Addresses { get; set; }
        public virtual IList<Phone> Phones { get; set; }
        public virtual IList<Occupation> Occupations { get; set; }
        public virtual IList<EducationDetail> EducationDetails { get; set; }
    }
}