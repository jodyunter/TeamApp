using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.Configuration;
using NHibernate;
using System.IO;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Data.NHibernate.Repositories
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

            var settingsToUse = settings["DatabaseToUse"];

            var connectionStringFormatter = "ConnectionStrings:{0}:ConnectionString";
            var providerFormatter = "ConnectionStrings:{0}:Provider";
            var driverFormatter = "ConnectionStrings:{0}:Driver";

            var connectionString = settings[string.Format(connectionStringFormatter, settingsToUse)];
            var providerString = settings[string.Format(providerFormatter, settingsToUse)];
            var driverString = settings[string.Format(driverFormatter, settingsToUse)];
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
                     .ConnectionString(connectionString)
                     .Provider(providerString)
                     .Driver(driverString)
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
