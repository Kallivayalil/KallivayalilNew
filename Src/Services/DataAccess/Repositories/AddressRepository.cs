using System;
using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Kallivayalil.DataAccess.Repositories
{
    public class AddressRepository : Repository, ISubEntityRepository<Address>
    {
        public AddressRepository(ISession session) : base(session) {}
        public AddressRepository() : base(SessionFactory.OpenSession()) {}

        public Address Save(Address entity)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedAddress = SaveOrUpdate(entity, txn);
                txn.Commit();
                return savedAddress;
            }
        }

        public Address Update(Address entity)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedAddress = SaveOrUpdate(entity, txn);
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

        public Address GetPrimary(int constituentId)
        {
            var criteria = session.CreateCriteria<Address>();
            criteria.Add(Restrictions.Eq("Constituent.Id", constituentId));
            criteria.Add(Restrictions.Eq("IsPrimary", true));
            return criteria.UniqueResult<Address>();
        }

        public IList<Constituent> SearchAddressBy(string address, string state, string city, string country, string postcode)
        {
            var criteria = session.CreateCriteria<Address>();
            criteria.Add(Restrictions.InsensitiveLike("Line1", address) || Restrictions.InsensitiveLike("Line2", address) || Restrictions.InsensitiveLike("City", city)
                || Restrictions.InsensitiveLike("State", state) || Restrictions.InsensitiveLike("PostCode", postcode) || Restrictions.InsensitiveLike("Country", country));
            var addresses = criteria.List<Address>();
            return addresses.Select(address1 => address1.Constituent).ToList();
        }
    }
}