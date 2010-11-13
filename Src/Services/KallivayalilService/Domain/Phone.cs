using Kallivayalil.Common;

namespace Kallivayalil.Domain
{
    public class Phone : Entity
    {
        public virtual int Type { get; set; }
        public virtual string Number { get; set; }
        public virtual Address Address { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}