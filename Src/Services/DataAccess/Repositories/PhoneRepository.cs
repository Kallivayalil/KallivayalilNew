using System;
using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Kallivayalil.DataAccess.Repositories
{
    public class PhoneRepository : Repository, ISubEntityRepository<Phone>
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

        public IList<Phone> LoadAll(int constituentId)
        {
            var criteria = session.CreateCriteria<Phone>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            return criteria.List<Phone>();
        }

        public Phone GetPrimary(int constituentId)
        {
            var criteria = session.CreateCriteria<Phone>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            criteria.Add(Restrictions.Eq("IsPrimary", true));
            return criteria.UniqueResult<Phone>();
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

        public List<Constituent> SearchByNumber(string number)
        {
            var criteria = session.CreateCriteria<Phone>();
            criteria.Add(Restrictions.Eq("Number", number));
            var phones = criteria.List<Phone>();

            return phones.Select(phone => phone.Constituent).ToList();
        }
    }
}