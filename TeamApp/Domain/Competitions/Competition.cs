using System;
using System.Collections.Generic;
using TeamApp.Domain.Schedules;
using System.Linq;
using TeamApp.Domain.Competitions.Config;

namespace TeamApp.Domain.Competitions
{
    public abstract class Competition:BaseDataObject
    {
        public virtual CompetitionConfig CompetitionConfig { get; set; }
        public virtual string Name { get; set; }
        public virtual int Year { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual IList<TeamRanking> Rankings { get; set; }
        public virtual IList<CompetitionTeam> Teams { get; set; }        
        public virtual bool Started { get; set; }
        public virtual bool Finished { get; set; }
        public virtual int? StartDay { get; set; }
        public virtual int? EndDay { get; set; }
        public virtual IEnumerable<ScheduleGame> Games { get; set; }
        public abstract IEnumerable<ScheduleGame> ProcessGame(ScheduleGame game, int currentDay); //this might add new games that need to be saved
        public abstract bool AreGamesComplete();
        public abstract void ProcessEndOfCompetitionDetails(int endingDay);
        public abstract List<TeamRanking> GetFinalRankings();
        public virtual void ProcessEndOfCompetition(int endingDay)
        {
            EndDay = endingDay;
            Finished = true;
            ProcessEndOfCompetitionDetails(endingDay);
            Rankings.ToList().AddRange(GetFinalRankings());
        }

        protected Competition():base() { }
        protected Competition(CompetitionConfig competitionConfig, string name, int year, Schedule schedule, IList<TeamRanking> rankings, List<CompetitionTeam> teams, bool started, bool finished, int? startDay, int? endDay)
        {
            CompetitionConfig = competitionConfig;
            Name = name;
            Year = year;
            Schedule = schedule;
            Rankings = rankings;
            if (Rankings == null) Rankings = new List<TeamRanking>();
            Teams = teams;
            if (Teams == null) Teams = new List<CompetitionTeam>();
            StartDay = startDay;
            EndDay = endDay;
            Started = started;
            Finished = finished;
        }

        //does not process game!
        //this needs to take into account the skill of the competition team, not the skill of the parent team
        public virtual void PlayGame(ScheduleGame game, Random random)
        {
            if (!game.IsComplete())
            {
                var homeCompetitionTeam = Teams.Where(t => t.Name.Equals(game.Home.Name) && t.NickName.Equals(game.Away.NickName)).First();
                var awayCompetitionTeam = Teams.Where(t => t.Name.Equals(game.Home.Name) && t.NickName.Equals(game.Away.NickName)).First();
                game.Play(random);
            }
        }

        public virtual List<ScheduleGame> PlayGames(List<ScheduleGame> games, Random random)
        {
            games.ForEach(g => { PlayGame(g, random); });

            return games;
        }

        public virtual List<ScheduleGame> PlayDay(ScheduleDay day, Random random)
        {
            return PlayGames(day.Games, random);
        }

        public virtual List<ScheduleGame> PlayNextDay(Random random)
        {
            var day = GetNextDayToPlay();

            if (day != null)
            {
                PlayGames(day.Games, random);
            }

            return day == null ? null : day.Games;
        }

        public virtual ScheduleDay GetNextDayToPlay()
        {
            var day = Schedule.GetNextInCompleteDay();

            return day == null ? null : day;
        }

        public virtual void SetupSchedule()
        {
            Schedule = new Schedule();
            if (Schedule.Days == null) Schedule.Days = new Dictionary<int, ScheduleDay>();

            Games.ToList().ForEach(game =>
            {
                if (!Schedule.Days.ContainsKey(game.Day)) Schedule.Days.Add(game.Day, new ScheduleDay(game.Day));

                Schedule.Days[game.Day].AddGame(game);
            });
        }        
    }
}
