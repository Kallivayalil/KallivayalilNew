using System;

namespace Kallivayalil.Common
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime? CreatedDateTime { get; set; }
        DateTime? UpdatedDateTime { get; set; }
        bool HasAttribute(Type attributeType);
        bool ShouldAudit(string propertyName);
    }
}