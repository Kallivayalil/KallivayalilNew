using System;
using System.Collections;
using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

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
            return session.Get<Event>(id);
        }

        public IList<Event> LoadAll(bool isApproved)
        {
            var criteria = session.CreateCriteria<Event>();
            criteria.Add(Restrictions.Ge("StartDate", DateTime.Today));
            criteria.Add(Restrictions.Ge("EndDate", DateTime.Today));
            criteria.Add(Restrictions.Eq("IsApproved", isApproved));
            return criteria.List<Event>();
        }
    }
}