using System;
using Kallivayalil.DataAccess;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;
using NHibernate;

namespace Tests.Common.Helpers
{
    public class TestDataHelper {
        private ConstituentRepository constituentRepository;
        private ISession session;

        public TestDataHelper()
        {
            session = ConfigurationFactory.SessionFactory.OpenSession();
            constituentRepository = new ConstituentRepository(session);
        }

        public Constituent CreateConstituent(Constituent constituent)
        {
            return constituentRepository.Save(constituent);
        }

        public void HardDeleteConstituents()
        {
            var sqlQuery = session.CreateSQLQuery("delete from constituents");
            sqlQuery.ExecuteUpdate();
            session.Flush();
        }

        public void HardDeleteConstituentNames()
        {
            var sqlQuery = session.CreateSQLQuery("delete from constituentNames");
            sqlQuery.ExecuteUpdate();
            session.Flush();
        }
    }
}