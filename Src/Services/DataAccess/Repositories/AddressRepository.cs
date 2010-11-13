using System;
using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Kallivayalil.DataAccess.Repositories
{
    public class AddressRepository : Repository
    {
        public AddressRepository(ISession session) : base(session) {}
        public AddressRepository() : base(SessionFactory.OpenSession()) {}

        public Address Save(Address address)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedAddress = SaveOrUpdate(address,txn);
                txn.Commit();
                return savedAddress;
            }
        }

        public Address Update(Address address)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedAddress = SaveOrUpdate(address, txn);
                txn.Commit();
                return savedAddress;
            }
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var address = Load(id);
                if (address != null)
                {
                    session.Delete(address);
                }
                txn.Commit();
            }
        }

        public Address Load(int id)
        {
            return session.Get<Address>(id);
        }

        public IList<Address> LoadAll(int constituentId)
        {
            var criteria = session.CreateCriteria<Address>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            return criteria.List<Address>();
        }


    }
}