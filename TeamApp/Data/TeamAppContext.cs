using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Competition.Seasons;

namespace TeamApp.Data
{
    public class TeamAppContext:DbContext
    {
        public TeamAppContext():base("Data Source=localhost;Initial Catalog=TeamAppTest;Integrated Security=True"){}

        public DbSet<Team> Teams { get; set; }
    }


}
