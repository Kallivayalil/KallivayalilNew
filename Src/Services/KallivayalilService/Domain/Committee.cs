using System;
using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Committee : PrimaryEntity
    {
        public virtual PositionType Type { get; set; }        
        
        public virtual DateTime StartDate { get; set; }

        public virtual DateTime EndDate { get; set; }

        public virtual Constituent Constituent { get; set; }
    }
}