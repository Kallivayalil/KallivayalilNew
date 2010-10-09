using System;

namespace Kallivayalil.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TimeStampedAttribute : Attribute
    {        
    }
    
    [AttributeUsage(AttributeTargets.Class)]
    public class AuditedAttribute : Attribute
    {        
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class DoNotAuditAttribute : Attribute
    {        
    }
}