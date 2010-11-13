using System;
using Kallivayalil.Common;

namespace Kallivayalil.Domain {
    
    public class Email :Entity {
        public virtual int Type { get; set; }
        public virtual string Address { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}
