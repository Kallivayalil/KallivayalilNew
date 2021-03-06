using System;
using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Kallivayalil.Common;
using Kallivayalil.DataAccess.Mappings;
using NHibernate;
using NHibernate.ByteCode.Spring;
using NHibernate.Event;
using Configuration = NHibernate.Cfg.Configuration;

namespace Kallivayalil.DataAccess
{
    public class ConfigurationFactory
    {
        private static ISessionFactory sessionFactory;
        private static readonly object LOCK_OBJECT = new object();
        public static Configuration Configuration { get; private set; }

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    lock (LOCK_OBJECT)
                    {
                        sessionFactory = ConfigurableSessionFactory(AddListeners);
                        return sessionFactory;
                    }
                }
                return sessionFactory;
            }
        }

        private static ISessionFactory ConfigurableSessionFactory(Action<Configuration> exposedConfiguration)
        {
            var sqlConfiguration = MsSqlConfiguration.MsSql2008
                .ConnectionString(ConfigurationManager.AppSettings.Get("connectionString"))
                .ProxyFactoryFactory(typeof (ProxyFactoryFactory).AssemblyQualifiedName);

            if (ShouldShowSql)
            {
                sqlConfiguration.ShowSql().FormatSql();
            }

            var configuration = Fluently.Configure().Database(sqlConfiguration)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ConstituentMap>())
                .ExposeConfiguration(exposedConfiguration);

            var buildSessionFactory = configuration.BuildSessionFactory();
            return buildSessionFactory;
        }

        private static bool ShouldShowSql
        {
            get { return false; }
        }

        private static void AddListeners(Configuration configuration)
        {
            Configuration = configuration;
            var timeStampListener = new TimeStampListener();
            configuration.EventListeners.PreInsertEventListeners = new IPreInsertEventListener[] {timeStampListener};
            configuration.EventListeners.PreUpdateEventListeners = new IPreUpdateEventListener[] {timeStampListener};
       
        }
    }
}