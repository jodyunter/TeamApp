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
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                return
                Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(ConfigurationManager.ConnectionStrings["Jody"].ConnectionString)                                                
                    .ShowSql())
                  .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Team>())
                  .BuildSessionFactory();
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
