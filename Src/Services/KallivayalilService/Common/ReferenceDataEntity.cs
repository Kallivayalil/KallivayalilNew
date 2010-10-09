using System;

namespace Kallivayalil.Common
{
    [Serializable]
    public class ReferenceDataEntity : Entity
    {
        public virtual bool Inactive { get; set; }
        public virtual string Description { get; set; }

        public virtual bool IsInactive()
        {
            return Inactive;
        }
    }
}