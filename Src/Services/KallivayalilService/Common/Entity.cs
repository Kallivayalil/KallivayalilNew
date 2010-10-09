using System;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.Domain.Attributes;

namespace Kallivayalil.Common
{
    [Serializable]
    public abstract class Entity : IEntity, ICloneable
    {

        public virtual int Id { get; set; }

        [DoNotAudit]
        public virtual DateTime? CreatedDateTime { get; set; }

        [DoNotAudit]
        public virtual DateTime? UpdatedDateTime { get; set; }
        
        [DoNotAudit]
        public virtual string CreatedBy { get; set; }

        [DoNotAudit]
        public virtual string UpdatedBy { get; set; }

        public virtual bool HasAttribute(Type attributeType)
        {
            return GetType().GetCustomAttributes(attributeType, false).Length != 0;
        }

        public virtual bool ShouldAudit(string propertyName)
        {
            return GetType().GetProperty(propertyName).GetCustomAttributes(typeof (DoNotAuditAttribute), true).Length == 0;
        }

        public static bool IsNull(Entity entity)
        {
            return entity == null || entity.Id == 0;
        }

        public virtual bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Id == Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return typeof (Entity).IsAssignableFrom(obj.GetType()) && Equals((Entity) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public virtual object Clone()
        {
            return ObjectCopier.Clone(this);
        }

        public virtual bool HasOnlyOnePrimaryEntity<T>(ICollection<T> entities, Func<T, bool> action)
        {
            if (entities == null || entities.Count == 0)
                return true;
            return entities.Count(action) == 1;
        }
    }
}