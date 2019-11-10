using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using FluentNHibernate.Mapping.Providers;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Context;
using NHibernate.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            //var hbmExport = @"C:\Users\jody_unterschutz\source\repos\TeamApp\TeamApp.Test.Database\HBM Files\"; use this if we want to export hbm xml files
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
                       m.FluentMappings.AddFromNamespaceOf<LeagueMap>().Conventions.Add(DefaultCascade.All());
                      

                       /*
                       m.AutoMappings.Add(
                           AutoMap.AssemblyOf<Team>(storeConfig)
                           .IgnoreBase<BaseDataObject>()
                           .IncludeBase<CompetitionConfig>()
                           .IncludeBase<PlayoffSeries>()
                           .IncludeBase<Competition>()
                           .IncludeBase<CompetitionConfigFinalRankingRule>()
                           .Conventions.Add(DefaultCascade.All())
                           );
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

    public static class FluentNHibernateExtensions
    {
        public static FluentMappingsContainer AddFromNamespaceOf<T>(
            this FluentMappingsContainer fmc)
        {
            string ns = typeof(T).Namespace;
            IEnumerable<Type> types = typeof(T).Assembly.GetExportedTypes()
                .Where(t => t.Namespace == ns)
                .Where(x => IsMappingOf<IMappingProvider>(x) ||
                            IsMappingOf<IIndeterminateSubclassMappingProvider>(x) ||
                            IsMappingOf<IExternalComponentMappingProvider>(x) ||
                            IsMappingOf<IFilterDefinition>(x));

            foreach (Type t in types)
            {
                fmc.Add(t);
            }

            return fmc;
        }

        /// <summary>
        /// Private helper method cribbed from FNH source (PersistenModel.cs:151)
        /// </summary>
        private static bool IsMappingOf<T>(Type type)
        {
            return !type.IsGenericType && typeof(T).IsAssignableFrom(type);
        }
    }
}
