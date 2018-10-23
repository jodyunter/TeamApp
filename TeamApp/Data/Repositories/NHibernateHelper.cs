using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.Configuration;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Playoffs.Config;
using TeamApp.Domain.Competitions.Seasons.Config;

namespace TeamApp.Data.Repositories
{
    public class NHibernateHelper
    {

        private static ISessionFactory SessionFactory()
        {
            return FluentConfig().BuildSessionFactory();

        }

        private static FluentConfiguration FluentConfig()
        {

            var settings = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json")
                .AddEnvironmentVariables().Build();


            /*
           return Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(settings["ConnectionStrings:JodyTest:ConnectionString"])
                    .Provider("NHibernate.Connection.DriverConnectionProvider")
                    .Driver("NHibernate.Driver.SqlClientDriver")
                    .ShowSql())
                  .Mappings(m => m
                    .FluentMappings.AddFromAssemblyOf<Team>());
                    */
            var storeConfig = new StoreConfiguration();

            return Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2012
                     .ConnectionString(settings["ConnectionStrings:JodyTest:ConnectionString"])
                     .Provider("NHibernate.Connection.DriverConnectionProvider")
                     .Driver("NHibernate.Driver.SqlClientDriver")
                     .ShowSql())
                   .Mappings(m =>
                   m.AutoMappings.Add(
                       AutoMap.AssemblyOf<Team>(storeConfig)
                       .IgnoreBase<BaseDataObject>()           
                       .IncludeBase<CompetitionConfig>()
                       .IncludeBase<PlayoffSeries>()
                       .IncludeBase<Competition>()
                       .Conventions.Add(DefaultCascade.All())
                       ));
                    
        }

        public static ISession OpenSession()
        {
            return SessionFactory().OpenSession();
        }

        public static FluentConfiguration GetConfiguration()
        {
            return FluentConfig();
        }


    }
}
