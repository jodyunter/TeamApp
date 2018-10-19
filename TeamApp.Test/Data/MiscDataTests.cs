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
        private ISessionFactory sessionFactory;
        private Configuration configuration;
        
        public MiscDataTests()
        {         
        }

        public void Dispose()
        {
            sessionFactory.Close();
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
