using Kallivayalil.Domain;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class EventRepository : Repository
    {
        public EventRepository(ISession session) : base(session) {}
        public EventRepository() : base(SessionFactory.OpenSession()) {}

        public Event Save(Event @event)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedEvent = SaveOrUpdate(@event, txn);
                txn.Commit();
                return savedEvent;
            }
        }

        public Event Update(Event @event)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedEvent = SaveOrUpdate(@event, txn);
                txn.Commit();
                return savedEvent;
            }
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var @event = session.Load<Event>(id);
                if (@event != null)
                {
                    session.Delete(@event);
                }
                txn.Commit();
            }
        }

        public Event Load(int id)
        {
            return Load<Event>(id);
        }
    }
}