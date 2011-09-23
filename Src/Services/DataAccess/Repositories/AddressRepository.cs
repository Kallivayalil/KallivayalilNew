using System.Collections.Generic;
using Kallivayalil.DataAccess.Helper;
using Kallivayalil.Domain;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace Kallivayalil.DataAccess.Repositories
{
    public class AddressRepository : Repository, ISubEntityRepository<Address>
    {
        private NHibernateCriteriaHelper nHibernateCriteriaHelper;

        public AddressRepository(ISession session) : base(session)
        {
            nHibernateCriteriaHelper = new NHibernateCriteriaHelper();
        }
        public AddressRepository() : base(SessionFactory.OpenSession())
        {
            nHibernateCriteriaHelper = new NHibernateCriteriaHelper();
        }

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
            var addressCriteria = session.CreateCriteria<Address>();
           addressCriteria = CreateCriterion(address, city, state, postcode, country, matchAllCriteria,addressCriteria);
            var addresses = addressCriteria.List<Address>();
            return addresses.Select(address1 => address1.Constituent).ToList();
        }

        private ICriteria CreateCriterion(string address, string city, string state, string postcode, string country, bool matchAllCriteria, ICriteria criteria)
        {
            var line1Criterion = nHibernateCriteriaHelper.GetCriterion("Line1", address);
            var line2Criterion = nHibernateCriteriaHelper.GetCriterion("Line2", address);
            var addressCriterion = GetAddressCriterion(line1Criterion, line2Criterion);
            var cityCriterion = nHibernateCriteriaHelper.GetCriterion("City", city);
            var stateCriterion = nHibernateCriteriaHelper.GetCriterion("State", state);
            var postCodeCriterion = nHibernateCriteriaHelper.GetCriterion("PostCode", postcode);
            var countryCriterion = nHibernateCriteriaHelper.GetCriterion("Country", country);
            return nHibernateCriteriaHelper.ConstructCriteria(matchAllCriteria, criteria, addressCriterion, cityCriterion, stateCriterion, postCodeCriterion, countryCriterion);
        }

        private Junction GetAddressCriterion(AbstractCriterion line1Criterion, AbstractCriterion line2Criterion)
        {
            return line1Criterion!= null ? Restrictions.Disjunction().Add(line1Criterion).Add(line2Criterion) : null;
        }
    }
}