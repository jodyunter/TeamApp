using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TeamApp.Data.Repositories;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using Xunit;

namespace TeamApp.Test.Data
{
    public class MiscDataTests:IDisposable
    {
        string connString = "Data Source = localhost; Initial Catalog = JodyTest; Integrated Security = True";

        private ISession session;
        private Configuration configuration;
        
        public MiscDataTests()
        {
            session = NHibernateHelper.OpenSession();
            configuration = NHibernateHelper.GetConfiguration().BuildConfiguration();
        }

        public void Dispose()
        {            
            var schemaExport = new SchemaExport(configuration);
            schemaExport.Drop(false, true);            
            session.Close();
        }

        [Fact]
        public void ShouldExportSchema()
        {            
            var schemaExport = new SchemaExport(configuration);
            schemaExport.SetOutputFile("../../../sqloutput/ddl.sql");
            schemaExport.Execute(false, true, false);
            
        }
        [Fact]
        public void ShouldAddTeam()
        {            
            var team = new Team("Team Add Test", "Yay", "Shrt", 1, "T1 Owner", 1, null, true);

            ITeamRepository repository = new TeamRepository();
            repository.Add(team);
        }
    }
}
