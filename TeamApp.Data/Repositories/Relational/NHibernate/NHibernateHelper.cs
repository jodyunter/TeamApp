using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Context;
using NHibernate.Event;
using System.IO;
using TeamApp.Data.Repositories.Relational.NHibernate.Mappers;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Playoffs;

namespace TeamApp.Data.Repositories.Relational.NHibernate
{
    public class NHibernateHelper
    {
        private static readonly ISessionFactory sessionFactory;

        static NHibernateHelper()
        {
            sessionFactory = SessionFactory();
        }
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
            var context = settings["SessionContext"];
            var connectionStringFormatter = "ConnectionStrings:{0}:ConnectionString";
            var providerFormatter = "ConnectionStrings:{0}:Provider";
            var driverFormatter = "ConnectionStrings:{0}:Driver";
            var connectionString = settings[string.Format(connectionStringFormatter, settingsToUse)];
            var providerString = settings[string.Format(providerFormatter, settingsToUse)];
            var driverString = settings[string.Format(driverFormatter, settingsToUse)];

            var storeConfig = new StoreConfiguration();

            var hbmExport = @"C:\Users\jody_unterschutz\source\repos\TeamApp\TeamApp.Test.Database\HBM Files\";
            //we need to remap all of the classes explicitly.
            //https://github.com/FluentNHibernate/fluent-nhibernate/wiki
            return Fluently.Configure()
                   .Database(MsSqlConfiguration.MsSql2012
                     .ConnectionString(connectionString)
                     .Provider(providerString)
                     .Driver(driverString)
                     //.ShowSql()
                     )
                   .CurrentSessionContext("thread_static")
                   .Mappings(m =>
                   {
                       m.FluentMappings.Add<TeamMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<PlayerMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<LeagueMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<CompetitionConfigMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<CompetitionConfigFinalRankingRuleMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<CompetitionTeamMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<SeasonTeamMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<PlayoffTeamMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<GameDataMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<PlayerMap>().ExportTo(hbmExport);
                       m.FluentMappings.Add<GameRulesMap>().ExportTo(hbmExport);

                       /*
                       m.AutoMappings.Add(
                           AutoMap.AssemblyOf<Team>(storeConfig)
                           .IgnoreBase<BaseDataObject>()
                           .IncludeBase<CompetitionConfig>()
                           .IncludeBase<PlayoffSeries>()
                           .IncludeBase<Competition>()
                           .IncludeBase<CompetitionConfigFinalRankingRule>()
                           .Conventions.Add(DefaultCascade.All())
                           ).ExportTo(hbmExport);
                           */
                   })
                       .ExposeConfiguration(c => c.EventListeners.PreUpdateEventListeners
                                  = new IPreUpdateEventListener[] { new AuditEventListener() })
                       .ExposeConfiguration(c => c.EventListeners.PreInsertEventListeners
                                  = new IPreInsertEventListener[] { new AuditEventListener() });                       
                    
        }

        public static ISession OpenSession()
        {
            if (!CurrentSessionContext.HasBind(sessionFactory))
                CurrentSessionContext.Bind(sessionFactory.OpenSession());

            return sessionFactory.GetCurrentSession();
            
            
        }

        public static void CloseSession()
        {
            if (sessionFactory != null && CurrentSessionContext.HasBind(sessionFactory))
            {
                var session = CurrentSessionContext.Unbind(sessionFactory);
                session.Close();
            }
        }

        public static FluentConfiguration GetConfiguration()
        {
            return FluentConfig();
        }


    }
}
