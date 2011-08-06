using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    [Serializable]
    public class Event : Entity
    {
        public virtual string EventTitle { get; set; }
        
        public virtual string EventDescription { get; set; }

        public virtual EventType Type { get; set; }

        public virtual bool IsApproved { get; set; }

        public virtual string ContactPerson { get; set; }

        public virtual string ContactNumber { get; set; }

        public virtual Constituent Constituent { get; set; }
        
        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

    }
}