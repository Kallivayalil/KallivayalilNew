using System;

namespace Kallivayalil.Common
{
    [Serializable]
    public abstract class PrimaryEntity : Entity, IPrimaryEntity
    {
        public virtual bool IsPrimary { get; set; }
    }
}