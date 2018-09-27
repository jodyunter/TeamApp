using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using TeamApp.Domain;
using TeamApp.Domain.Competition.Seasons.Config;
using TeamApp.Domain.Competition.Seasons;

namespace TeamApp.Data
{
    public class TeamAppContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<SeasonDivisionRule> SeasonDivisionRules { get; set; }
        public DbSet<SeasonTeamRule> SeasonTeamRules { get; set; }
        public DbSet<SeasonCompetition> SeasonCompetitions { get; set; }

        public DbSet<SeasonTeam> SeasonTeams { get; set; }
        public DbSet<SeasonDivision> SeasonDivisions { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<SeasonTeamStats> SeasonTeamStats { get; set; }
    }


}
