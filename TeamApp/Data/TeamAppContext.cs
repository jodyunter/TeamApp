using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Season.Config;
using TeamApp.Domain.Competition.Season;

namespace TeamApp.Data
{
    public class TeamAppContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<SeasonRule> SeasonRules { get; set; }
        public DbSet<SeasonCompetition> SeasonCompetitions { get; set; }

        public DbSet<SeasonTeam> SeasonTeams { get; set; }
        public DbSet<SeasonDivision> SeasonDivisions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonTeamStats> SeasonTeamStats { get; set; }
 }
        
    }
}
