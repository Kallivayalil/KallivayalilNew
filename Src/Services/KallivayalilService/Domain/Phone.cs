using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Phone : PrimaryEntity
    {
        public virtual PhoneType Type { get; set; }
        public virtual string Number { get; set; }
        public virtual Address Address { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}