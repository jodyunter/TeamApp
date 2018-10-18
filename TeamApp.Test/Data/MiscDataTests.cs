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
    public class MiscDataTests
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        public MiscDataTests()
        {
            var teamAssembly = typeof(Team).Assembly;
            var stream = teamAssembly.GetManifestResourceStream("TeamApp.Data.hibernate.cfg.xml");
            _configuration = new Configuration();

            _configuration.AddInputStream(stream);
            _configuration.Configure();
            _configuration.AddAssembly(teamAssembly);            
            _sessionFactory = _configuration.BuildSessionFactory();            
            
            new SchemaExport(_configuration).Execute(false, true, false);
        }

        public void Dispose()
        {
            
        }
        [Fact]
        public void ShouldGenerateSchema()
        {
            var cfg = new Configuration();
            
            cfg.Configure();
            cfg.AddAssembly(typeof(Team).Assembly);

            new SchemaExport(cfg).Execute(false, true, false);
        }
        [Fact]
        public void ShouldAddTeam()
        {
            var team = new Team("Team Add Test", 1, "T1 Owner", 1, null, true);

            ITeamRepository repository = new TeamRepository();
            repository.Add(team);
        }
    }
}
