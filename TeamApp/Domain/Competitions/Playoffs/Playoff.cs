using System;
using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Config;
using TeamApp.Domain.Competitions.Config.Playoffs;
using TeamApp.Domain.Schedules;

namespace TeamApp.Domain.Competitions.Playoffs
{
    public class Playoff : Competition
    {
        public virtual int CurrentRound { get; set; }
        public virtual IList<PlayoffSeries> Series { get; set; }

        public Playoff() : base()
        {
        }

        public Playoff(CompetitionConfig competitionConfig, string name, int year, int currentRound, List<PlayoffSeries> series, List<CompetitionTeam> teams, Schedule schedule, IList<TeamRanking> rankings, bool started, bool finished, int? startDay, int? endDay)
            : base(competitionConfig, name, year, schedule, rankings, teams, started, finished, startDay, endDay)
        {
            Series = series;
            Teams = teams;
            CurrentRound = currentRound;
        }

        public override void ProcessEndOfCompetitionDetails(int endingDay)
        {
            //nothing to do for end of series at this point in time
        }

        //this method will sort all rankings groups starting at 1.
        public virtual void SeedRankingsGroups()
        {
            var rankingsDictionary = new Dictionary<string, List<TeamRanking>>();

            Rankings.ToList().ForEach(ranking =>
            {
                if (!rankingsDictionary.ContainsKey(ranking.GroupName)) rankingsDictionary.Add(ranking.GroupName, new List<TeamRanking>());

                rankingsDictionary[ranking.GroupName].Add(ranking);
            });

            rankingsDictionary.Keys.ToList().ForEach(key =>
            {
                rankingsDictionary[key].Sort((a, b) => a.Rank.CompareTo(b.Rank));
                int m = 0;

                rankingsDictionary[key].ForEach(value =>
                {
                    m++;
                    value.Rank = m;
                });
            });
        }

        public virtual IEnumerable<ScheduleGame> BeginRound(int currentDay)
        {
            Started = true;
            var newGames = new List<ScheduleGame>();

            if (IsRoundComplete(CurrentRound)) CurrentRound++;
            //else return;

            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            int previousRoundEnd = GetLastDayOfRound(CurrentRound - 1); //will be -1 if no playoffs yet
            var firstNotStartedDay = Schedule.GetNextNotStartedDay(); //this will be null if all days done!
            int roundStartDay = -1;

            if (firstNotStartedDay == null)
            {
                roundStartDay = previousRoundEnd > -1 ? previousRoundEnd + 1 : currentDay;
            }
            else
            {
                roundStartDay = firstNotStartedDay == null || firstNotStartedDay.DayNumber < previousRoundEnd ? previousRoundEnd + 1 : firstNotStartedDay.DayNumber;
            }

            //most groups are seeded to start with
            //this will seed any new groups
            SeedRankingsGroups();

            //add any missing teams, and setup the games for each series
            Series.Where(s => s.Round == CurrentRound).ToList().ForEach(s =>
            {
                var activeSeriesList = playoffConfig.GetActiveSeriesRules(Year);
                //teams that relied on the previous round may still need their team
                if (s.HomeTeam == null)
                {
                    var rule = activeSeriesList.Where(sr => sr.Name.Equals(s.Name)).FirstOrDefault();
                    s.HomeTeam = playoffConfig.GetTeamByRule(this, rule.HomeFromName, rule.HomeFromValue);
                }

                if (s.AwayTeam == null)
                {
                    var rule = activeSeriesList.Where(sr => sr.Name.Equals(s.Name)).FirstOrDefault();
                    s.AwayTeam = playoffConfig.GetTeamByRule(this, rule.AwayFromName, rule.AwayFromValue);
                }

                newGames.AddRange(SetupSeriesGames(s, roundStartDay).ToList());
            });

            return newGames;
        }

        //currently we assume we want to just add them to next unstarted day
        public virtual IEnumerable<ScheduleGame> SetupSeriesGames(PlayoffSeries series, int startingDay)
        {
            var newGames = series.CreateNeededGamesForSeries();

            Scheduler.AddGamesToSchedule(Schedule, newGames.ToList<ScheduleGame>(), startingDay);

            return newGames;
        }

        public virtual void AddSeries(PlayoffSeries series)
        {
            if (Series == null) Series = new List<PlayoffSeries>();

            Series.Add(series);
        }

        public override IEnumerable<ScheduleGame> ProcessGame(ScheduleGame game, int currentDay)
        {
            var gameCompetition = game.Competition;
            var newGames = new List<ScheduleGame>();

            if (!(gameCompetition.Name.Equals(Name)) || !(gameCompetition.Year.Equals(Year)) || !(game is PlayoffGame))
            {
                throw new ApplicationException("Trying to process game with the wrong competition.");
            }

            var playoffGame = (PlayoffGame)game;

            playoffGame.Series.ProcessSeriesGame(playoffGame);
            if (playoffGame.Series.IsComplete())
            {
                //process end of series
                ProcessEndOfSeries(playoffGame.Series);
            }

            if (IsRoundComplete(CurrentRound))
                newGames = BeginRound(currentDay).ToList();
            
            newGames.AddRange(SetupSeriesGames(playoffGame.Series, currentDay));

            return newGames;
        }

        public virtual int GetLastDayOfRound(int roundNumber)
        {
            int lastDay = -1;

            if ((Schedule == null || Schedule.Days == null || Schedule.Days.Count == 0) && (StartDay != null))
            {
                //assume it was populated properly
                if (Schedule == null)
                {
                    Schedule = new Schedule();                    
                }
                if (Schedule.Days == null || Schedule.Days.Count == 0)
                {
                    Schedule.Days.Add(StartDay.Value, new ScheduleDay(StartDay.Value));
                }

                return StartDay.Value;
            }
            else
            {

                Schedule.Days.Values.ToList().ForEach(day =>
                {
                    day.Games.ForEach(g =>
                    {
                        if (g.GetType() == typeof(PlayoffGame))
                        {
                            var pg = (PlayoffGame)g;
                            if (pg.Series.Round == roundNumber && pg.Day > lastDay) lastDay = pg.Day;
                        }

                    });
                });

                return lastDay;
            }
        }

        public virtual void ProcessEndOfSeries(PlayoffSeries series)
        {
            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            var seriesRule = playoffConfig.GetActiveSeriesRules(Year).Where(s => s.Name.Equals(series.Name)).First();

            ProcessEndOfSeriesTeam(seriesRule.WinnerGroupName, seriesRule.WinnerRankFrom, series.GetWinner());
            ProcessEndOfSeriesTeam(seriesRule.LoserGroupName, seriesRule.LoserRankFrom, series.GetLoser());
        }

        public virtual void ProcessEndOfSeriesTeam(string newGroupName, string rankSourceGroupName, PlayoffTeam team)
        {
            if (newGroupName != null)
            {
                if (rankSourceGroupName == null) throw new ApplicationException("Can't have a null winner rank from.");

                var rank = Rankings.Where(r => r.GroupName == rankSourceGroupName && r.CompetitionTeam.Id == team.Id).First().Rank;

                Rankings.Add(new TeamRanking(rank, newGroupName, team, -1));
            }
        }

        public virtual bool IsRoundComplete(int round)
        {
            var complete = true;

            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            //get all rules for this orund
            var seriesRulesList = playoffConfig.GetActiveSeriesRules(Year).Where(sr => sr.Round == round).ToList();

            //if no rules, then it is complete
            if (seriesRulesList.Count == 0) return true;

            //for each series rule, check to see if the series exists and if it does, is it complete?
            seriesRulesList.ForEach(sr =>
            {
                var series = Series.Where(s => s.Name == sr.Name).FirstOrDefault();

                complete = complete && series.IsComplete();
            });

            return complete;
        }

        public override bool AreGamesComplete()
        {
            if (Schedule == null) SetupSchedule();

            var complete = true;
            var playoffConfig = (PlayoffCompetitionConfig)CompetitionConfig;

            var activeSeries = playoffConfig.GetActiveSeriesRules(Year).ToList();

            for (int i = 0; i < activeSeries.Count; i++)
            {
                complete = complete && IsRoundComplete(activeSeries[i].Round);
            }

            return complete;
        }

        public override List<TeamRanking> GetFinalRankings()
        {

            //do nothing
            //todo set this up
            return new List<TeamRanking>();
        }
    }
}