﻿using System.Collections.Generic;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions
{
    public abstract class Competition:BaseDataObject
    {
        public virtual CompetitionConfig CompetitionConfig { get; set; }
        public virtual string Name { get; set; }
        public virtual int Year { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual IList<TeamRanking> Rankings { get; set; }
        public virtual IList<SingleYearTeam> Teams { get; set; }
        public abstract void ProcessGame(ScheduleGame game);
        public abstract bool IsComplete();

        public Competition() : base() { }
        protected Competition(CompetitionConfig competitionConfig, string name, int year, Schedule schedule, IList<TeamRanking> rankings, List<SingleYearTeam> teams)
        {
            CompetitionConfig = competitionConfig;
            Name = name;
            Year = year;
            Schedule = schedule;
            Rankings = rankings;
            if (Rankings == null) Rankings = new List<TeamRanking>();
            Teams = teams;
            if (Teams == null) Teams = new List<SingleYearTeam>();
        }
    }
}
