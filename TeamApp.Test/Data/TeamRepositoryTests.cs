
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using static Xunit.Assert;
using TeamApp.Data.Repositories;
using TeamApp.Domain;
using TeamApp.Domain.Repositories;
using Xunit;
using System.Linq;

namespace TeamApp.Test.Data
{
    public class TeamRepositoryTests:RepositoryTests<Team>, IDisposable
    {          

        public TeamRepositoryTests():base()
        {
          
        }
        public override void AddData()
        {           
            for (int i = 0; i < 10; i++)
            {
                repository.Add(new Team("Team " + i, "T " + i, "T" + i, i, "T" + i + " Owner", 1, null, true));
            }
        }

        public override void SetupRepository()
        {
            repository = new RepositoryNhibernate<Team>();
        }

        public override Team GetAddItem()
        {
            return new Team("Team Add Test", "Yay", "Shrt", 1, "T1 Owner", 1, null, true);
        }

        public override Team UpdateItem(Team item)
        {
            item.Name = "New Name";
            item.Skill = 12;
            item.ShortName = "BLAH";

            return item;
        }
    }
}
