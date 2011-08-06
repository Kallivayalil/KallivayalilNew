using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Address : PrimaryEntity
    {
        public virtual string Line1 { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string PostCode { get; set; }
        public virtual string Country { get; set; }
        public virtual AddressType Type { get; set; }
        public virtual Constituent Constituent { get; set; }

        public virtual string Description
        {
            get { return string.Format("{0},{1},{2},{3}-{4},{5}", Line1, Line2, City, State, PostCode, Country); }
        }
    }
}