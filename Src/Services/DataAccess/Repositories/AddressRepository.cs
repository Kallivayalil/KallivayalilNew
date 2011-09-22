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

        public List<Constituent> SearchAddressBy(string address, string state, string city, string country, string postcode, bool matchAllCriteria)
        {
            var criteria = session.CreateCriteria<Address>();
            criteria.Add(AbstractCriterion(address, city, state, postcode, country,matchAllCriteria));
            var addresses = criteria.List<Address>();
            return addresses.Select(address1 => address1.Constituent).ToList();
        }

        private AbstractCriterion AbstractCriterion(string address, string city, string state, string postcode, string country, bool matchAllCriteria)
        {
            return matchAllCriteria ? ((Restrictions.InsensitiveLike("Line1", GetPropertyValue(address)) || Restrictions.InsensitiveLike("Line2", GetPropertyValue(address))) && Restrictions.InsensitiveLike("City", GetPropertyValue(city))
                   && Restrictions.InsensitiveLike("State", GetPropertyValue(state)) && Restrictions.InsensitiveLike("PostCode", GetPropertyValue(postcode)) && Restrictions.InsensitiveLike("Country", GetPropertyValue(country)))
                   :
                    (Restrictions.InsensitiveLike("Line1", GetPropertyValue(address)) || Restrictions.InsensitiveLike("Line2", GetPropertyValue(address)) || Restrictions.InsensitiveLike("City", GetPropertyValue(city))
                   || Restrictions.InsensitiveLike("State", GetPropertyValue(state)) || Restrictions.InsensitiveLike("PostCode", GetPropertyValue(postcode)) || Restrictions.InsensitiveLike("Country", GetPropertyValue(country)));
        }

        private string GetPropertyValue(string propertyValue)
        {
            return string.IsNullOrEmpty(propertyValue) ? propertyValue : string.Format("%{0}%", propertyValue);
        }
    }
}