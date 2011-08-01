using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kallivayalil.Domain;
using Lucene.Net.Analysis;
using Lucene.Net.QueryParsers;
using Lucene.Net.Util;
using NHibernate;
using NHibernate.Search;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ConstituentNameRepository : Repository
    {
        public ConstituentNameRepository(ISession session) : base(session) {}
        public ConstituentNameRepository() : base(SessionFactory.OpenSession()) {}

        public ConstituentName Save(ConstituentName constituentName)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituentName = SaveOrUpdate(constituentName, txn);
                txn.Commit();
                return savedConstituentName;
            }
        }


        public ConstituentName Update(ConstituentName constituentName)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituentName = SaveOrUpdate(constituentName, txn);
                txn.Commit();
                return savedConstituentName;
            }
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var constituentName = session.Load<ConstituentName>(id);
                if (constituentName != null)
                {
                    session.Delete(constituentName);
                }
                txn.Commit();
            }
        }

        public ConstituentName Load(int id)
        {
            return Load<ConstituentName>(id);
        }

        public IList SearchByName(string firstName, string lastName)
        {
            var textSession = Search.CreateFullTextSession(session);

            var qp = new QueryParser(Version.LUCENE_20, "id", new StopAnalyzer(Version.LUCENE_20));

            var query = string.Format("FirstName:{0} or LastName:{1}", firstName, lastName);

            var constituentNames = textSession.CreateFullTextQuery(qp.Parse(query), typeof(ConstituentName)).List().Cast<ConstituentName>();

            return constituentNames.Select(constituentName => constituentName.Id).ToList();
        }
    }
}