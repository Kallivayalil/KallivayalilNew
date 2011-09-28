using System;
using Kallivayalil.Common;

namespace Kallivayalil.Domain
{
    [Serializable]
    public class Upload : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Constituent Constituent { get; set; }
    }
}