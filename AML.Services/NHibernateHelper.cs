using AML.Services.Maps;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace AML.Services
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory sessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitialSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitialSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())
                .ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>()).ExposeConfiguration(cfg => new SchemaExport(cfg)).BuildSessionFactory();

            //        _sessionFactory = Fluently.Configure()
            //.Database(FluentNHibernate.Cfg.Db.MsSqlConfiguration.MsSql2008.ConnectionString(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString())
            //.ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<CategoryMap>()).ExposeConfiguration(cfg => new SchemaExport(cfg).Execute(true, true, false)).BuildSessionFactory();

        }

        public static ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
