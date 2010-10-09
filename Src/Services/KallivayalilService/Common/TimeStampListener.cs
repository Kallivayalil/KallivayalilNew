using System;
using NHibernate.Event;
using NHibernate.Persister.Entity;

namespace Kallivayalil.Common
{
    public class TimeStampListener : AbstractPersistenceListener, IPreInsertEventListener, IPreUpdateEventListener
    {

        public bool OnPreInsert(PreInsertEvent preInsertEvent)
        {
            var entity = preInsertEvent.Entity as Entity;
            if (entity == null) return false;

            var userName = "bla";
            var now = DateTime.Now;

            Set(preInsertEvent.Persister, preInsertEvent.State, "CreatedDateTime", now);
            Set(preInsertEvent.Persister, preInsertEvent.State, "CreatedBy", userName);
            Set(preInsertEvent.Persister, preInsertEvent.State, "UpdatedBy", userName);
            Set(preInsertEvent.Persister, preInsertEvent.State, "UpdatedDateTime", now);

            entity.CreatedDateTime = now;
            entity.UpdatedDateTime = now;
            entity.CreatedBy = userName;
            entity.UpdatedBy = userName;

            return false;
        }

        public bool OnPreUpdate(PreUpdateEvent preUpdateEvent)
        {
            var entity = preUpdateEvent.Entity as Entity;
            if (entity == null) return false;

            var now = DateTime.Now;

            Set(preUpdateEvent.Persister, preUpdateEvent.State, "UpdatedDateTime", now);

            var userName="bla";
            Set(preUpdateEvent.Persister, preUpdateEvent.State, "UpdatedBy", userName);

            entity.UpdatedDateTime = now;
            entity.UpdatedBy = userName;

            return false;
        }

        private static void Set(IEntityPersister persister, object[] locale, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1) return;
            locale[index] = value;
        }
    }
}