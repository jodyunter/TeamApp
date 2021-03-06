﻿namespace TeamApp.Domain.Competitions.Config.Seasons
{    
    public class SeasonTeamRule:BaseDataObject,ITimePeriod
    {
        public const int TEAM = 0;

        public virtual SeasonCompetitionConfig Competition { get; set; }
        public virtual Team Team { get; set; }
        public virtual SeasonDivisionRule Division { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }

        public SeasonTeamRule() { }
        public SeasonTeamRule(SeasonCompetitionConfig competition, Team team, SeasonDivisionRule division, int? firstYear, int? lastYear)
        {
            Competition = competition;
            Team = team;
            Division = division;
            FirstYear = firstYear;
            LastYear = lastYear;            
        }
    }
}
