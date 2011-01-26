using System.Collections.Generic;

namespace Website.Models
{

    public class Emails : List<Email>
    {
    }

    public class Email : Entity
    {
        public virtual int Type { get; set; }
        public virtual string Address { get; set; }
        public virtual Constituent Constituent { get; set; }
    }

}