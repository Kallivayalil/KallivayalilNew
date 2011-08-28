using System;
using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Kallivayalil.DataAccess.Repositories
{
    public class EmailRepository : Repository, ISubEntityRepository<Email>
    {
        public EmailRepository(ISession session) : base(session) {}
        public EmailRepository() : base(SessionFactory.OpenSession()) {}


        public Email Save(Email email)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedEmail = SaveOrUpdate(email, txn);
                txn.Commit();
                return savedEmail;
            }
        }

        public Email Update(Email email)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedEmail = SaveOrUpdate(email, txn);
                txn.Commit();
                return savedEmail;
            }
        }

        public Email Load(int id)
        {
            return session.Get<Email>(id);
        }

        public IList<Email> LoadAll(int constituentId)
        {
            var criteria = session.CreateCriteria<Email>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            return criteria.List<Email>();
        }

        public Email GetPrimary(int constituentId)
        {
            var criteria = session.CreateCriteria<Email>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            criteria.Add(Restrictions.Eq("IsPrimary", true));
            return criteria.UniqueResult<Email>();
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var email = Load(id);
                if (email != null)
                {
                    session.Delete(email);
                }
                txn.Commit();
            }
        }

        public Email Load(string address)
        {
            var criteria = session.CreateCriteria<Email>();
            criteria.Add(Restrictions.Eq("Address", address));
            return (Email) criteria.UniqueResult();
        }

        public List<Constituent> SearchByEmail(string email)
        {
            var criteria = session.CreateCriteria<Email>();
            criteria.Add(Restrictions.InsensitiveLike("Address", email));
            var emails = criteria.List<Email>();
            return emails.Select(email1 => email1.Constituent).ToList();

        }
    }
}