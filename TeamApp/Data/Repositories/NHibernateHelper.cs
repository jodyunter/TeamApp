using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Xml;
using TeamApp.Domain;

namespace TeamApp.Data.Repositories
{
    public class NHibernateHelper
    {

        private static ISessionFactory SessionFactory(string connectionString)
        {                             
            return FluentConfig(connectionString).BuildSessionFactory();

        }

        private static ISessionFactory SessionFactory()
        {
            return FluentConfig().BuildSessionFactory();

        }

        private static FluentConfiguration FluentConfig()
        {
                             

            return Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(ConfigurationManager.ConnectionStrings["Jody"].ConnectionString)
                    .Provider("NHibernate.Connection.DriverConnectionProvider")
                    .Driver("NHibernate.Driver.SqlClientDriver")
                    .ShowSql())
                  .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Team>());

        }

        private static FluentConfiguration FluentConfig(string connectionString)
        {
            return Fluently.Configure()
              .Database(MsSqlConfiguration.MsSql2012
                .ConnectionString(connectionString)
                .Provider("NHibernate.Connection.DriverConnectionProvider")
                .Driver("NHibernate.Driver.SqlClientDriver")
                .ShowSql())
              .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<Team>());

        }
        public static ISession OpenSession()
        {
            return SessionFactory().OpenSession();
        }

        public static FluentConfiguration GetConfiguration()
        {
            return FluentConfig();
        }

        public static ISession OpenSession(string connectionString)
        {
            return SessionFactory(connectionString).OpenSession();
        }

        public static FluentConfiguration GetConfiguration(string connectionStrong)
        {
            return FluentConfig(connectionStrong);
        }


    }
}
