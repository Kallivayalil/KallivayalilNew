using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class PhoneRepository : Repository
    {
        public PhoneRepository(ISession session) : base(session) {}
        public PhoneRepository() : base(SessionFactory.OpenSession()) {}

        public Phone Save(Phone phone)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedPhone = SaveOrUpdate(phone, txn);
                txn.Commit();
                return savedPhone;
            }
        }

        public Phone Update(Phone phone)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedPhone = SaveOrUpdate(phone, txn);
                txn.Commit();
                return savedPhone;
            }
        }

        public Phone Load(int id)
        {
            return session.Get<Phone>(id);
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var phone = Load(id);
                if (phone != null)
                {
                    session.Delete(phone);
                }
                txn.Commit();
            }
        }

        public IList<Phone> LoadAll(Constituent constituent)
        {
            var criteria = session.CreateCriteria<Phone>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituent.Id));
            return criteria.List<Phone>();
        }

        public IList<Phone> LoadAll(Address address)
        {
            var criteria = session.CreateCriteria<Phone>();
            criteria.Add(Restrictions.Eq("Address.Id", address.Id));
            return criteria.List<Phone>();
        }
    }
}