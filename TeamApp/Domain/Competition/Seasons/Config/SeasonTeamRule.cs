﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Competition.Seasons.Config
{    
    public class SeasonTeamRule
    {
        public const int TEAM = 0;        

        public SeasonCompetition Competition { get; set; }
        public Team Team { get; set; }
        public string Division { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }        

        public SeasonTeamRule(SeasonCompetition competition, Team team, string division, int? firstYear, int? lastYear)
        {
            Competition = competition;
            Team = team;
            Division = division;
            FirstYear = firstYear;
            LastYear = lastYear;            
        }
    }
}