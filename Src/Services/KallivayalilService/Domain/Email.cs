using Kallivayalil.Common;
using Kallivayalil.Domain.ReferenceData;

namespace Kallivayalil.Domain
{
    public class Email : PrimaryEntity
    {
        public virtual EmailType Type { get; set; }
        public virtual string Address { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}