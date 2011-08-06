using System.Collections.Generic;
using Kallivayalil.Domain;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.QueryParsers;
using Lucene.Net.Util;
using NHibernate;
using System.Linq;
using NHibernate.Search;

namespace Kallivayalil.DataAccess.Repositories
{
    public class ConstituentRepository : Repository
    {
        public ConstituentRepository(ISession session) : base(session)
        {
        }

        public ConstituentRepository() : this(SessionFactory.OpenSession()) {}

        public Constituent Save(Constituent constituent)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent, txn);
                txn.Commit();
                return savedConstituent;
            }
        }

        public Constituent Update(Constituent constituent)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedConstituent = SaveOrUpdate(constituent, txn);
                txn.Commit();
                return savedConstituent;
            }
        }

        public void Delete(int constituentId)
        {
            using (var txn = session.BeginTransaction())
            {
                var constituent = session.Load<Constituent>(constituentId);
                if (constituent != null)
                {
                    session.Delete(constituent);
                }
                txn.Commit();
            }
        }

        public Constituent Load(int constituentId)
        {
            return session.Get<Constituent>(constituentId);
        }

        public IEnumerable<Constituent> SearchByName(string firstName, string lastName)
        {
            var textSession = Search.CreateFullTextSession(session);

            var qp = new QueryParser(Version.LUCENE_CURRENT,"", new StandardAnalyzer(Version.LUCENE_CURRENT));

            var query = string.Format("Name.FirstName:{0} or Name.LastName:{1}", firstName, lastName);

             return textSession.CreateFullTextQuery(qp.Parse(query), typeof(Constituent)).List().Cast<Constituent>();
        }
    }
}