﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TeamApp.Domain.Scheduler
{
    public class ScheduleValidator
    {
        public Dictionary<string, int> TeamDaysPlayed { get; set; }
        public Dictionary<string, int> TeamGamesPlayed { get; set; }
        public Dictionary<string, int> TeamHomeGamesPlayed { get; set; }
        public Dictionary<string, int> TeamAwayGamesPlayed { get; set; }

        public List<string> ErrorMessages { get; set; }
        public bool IsUnevenHomeAwayOkay { get; set; }        
        public bool IsUnevenScheduleOkay { get; set; }

        public Schedule Schedule { get; set; }
        public bool IsValid {  get { return IsScheduleValid(); } }

        public ScheduleValidator(Schedule schedule)
        {

        }

        private void AddStringKeyToDictionary(string key, params Dictionary<string, int>[] dictionaries)
        {
            dictionaries.ToList().ForEach(dictionary =>
            {
                dictionary.Add(key, 0);
            });
        }
        public bool IsScheduleValid()
        {
            var gameMessages = new List<string>();
            var dayMessages = new List<string>();
            var scheduleMessages = new List<string>();
            var dayValidators = new List<ScheduleDayValidator>();
            TeamGamesPlayed = new Dictionary<string, int>();
            TeamDaysPlayed = new Dictionary<string, int>();
            TeamHomeGamesPlayed = new Dictionary<string, int>();
            TeamAwayGamesPlayed = new Dictionary<string, int>();

            Schedule.Days.Keys.ToList().ForEach(dayNumber =>
            {
                var day = Schedule.Days[dayNumber];
                var validator = new ScheduleDayValidator(Schedule.Days[dayNumber]);

                day.Games.ForEach(game =>
                {
                    var gameValidator = new ScheduleGameValidator(game);
                    if (!gameValidator.IsValid)
                    {
                        gameMessages.AddRange(gameValidator.Messages);
                    }
                });

                if (!validator.IsValid)
                {
                    dayMessages.AddRange(validator.Messages);
                }
                
                foreach(KeyValuePair<string, int> pair in validator.HomeTeamCounts)
                {
                    if (!TeamHomeGamesPlayed.ContainsKey(pair.Key))
                    {
                        AddStringKeyToDictionary(pair.Key, TeamHomeGamesPlayed, TeamAwayGamesPlayed, TeamDaysPlayed, TeamGamesPlayed);
                    }

                    TeamHomeGamesPlayed[pair.Key] += pair.Value;
                    TeamGamesPlayed[pair.Key] += pair.Value;
                    TeamDaysPlayed[pair.Key] += pair.Value;
                }

                foreach (KeyValuePair<string, int> pair in validator.AwayTeamCounts)
                {
                    if (!TeamAwayGamesPlayed.ContainsKey(pair.Key))
                    {
                        AddStringKeyToDictionary(pair.Key, TeamHomeGamesPlayed, TeamAwayGamesPlayed, TeamDaysPlayed, TeamGamesPlayed);
                    }

                    TeamAwayGamesPlayed[pair.Key] += pair.Value;
                    TeamGamesPlayed[pair.Key] += pair.Value;
                    TeamDaysPlayed[pair.Key] += pair.Value;
                }

            });

            if (!IsUnevenScheduleOkay)
            {
                //this means all teams must have the same number of games
            }

            if (!IsUnevenHomeAwayOkay)
            {
                //this means all teams must have even amount of home and away games
            }

            return false;
        }
        //validates if there are any duplicate teams
        public bool IsDayValid(ScheduleDay day)
        {
            var validator = new ScheduleDayValidator(day);

            return validator.IsValid;
        }

        public bool IsGameValid(ScheduleGame game)
        {
            //does the game match its rules?
            //does the home tema not equal away
            var validator = new ScheduleGameValidator(game).IsValid;

            return validator;
        }

    }

    public class ScheduleGameValidator
    {
        public List<string> Messages { get; set; }
        public bool IsValid { get; set; }
        public ScheduleGameValidator(ScheduleGame game)
        {
            Messages = new List<string>();
            IsValid = !(game.HomeTeam.Name.Equals(game.AwayTeam.Name));
            if (!IsValid) Messages.Add("Game:" + game.GameNumber + " day: " + game.Day + " has the same Home and Away team");
        }
    }

    public class ScheduleDayValidator
    {
        public HashSet<string> Teams { get; set; }
        public Dictionary<string, int> HomeTeamCounts { get; set; }
        public Dictionary<string, int> AwayTeamCounts { get; set; }
        public List<string> Messages { get; set; }
        public int DayNumber { get; set; }
        public ScheduleDayValidator(ScheduleDay day)
        {
            HomeTeamCounts = new Dictionary<string, int>();
            AwayTeamCounts = new Dictionary<string, int>();
            Teams = new HashSet<string>();
            Messages = new List<string>();

            DayNumber = day.DayNumber;


            day.Games.ForEach(g =>
            {
                AddHomeTeam(g.HomeTeam.Name);
                AddAwayTeam(g.AwayTeam.Name);
            });
        }

        public int GetTotalGamesByTeam(string teamName)
        {
            return (HomeTeamCounts.ContainsKey(teamName) ? HomeTeamCounts[teamName] : 0) +
                (AwayTeamCounts.ContainsKey(teamName) ? AwayTeamCounts[teamName] : 0);
        }

        public void AddHomeTeam(string teamName)
        {
            AddTeam(teamName, HomeTeamCounts);
        }

        public void AddAwayTeam(string teamName)
        {
            AddTeam(teamName, AwayTeamCounts);
        }

        public void AddTeam(string teamName, Dictionary<string, int> teamCounts)
        {
            if (!teamCounts.ContainsKey(teamName)) teamCounts[teamName] = 0;

            teamCounts[teamName]++;
            Teams.Add(teamName);
        }

        public bool IsValid
        {
            get
            {
                {
                    bool valid = true;

                    Teams.ToList().ForEach(t =>
                    {
                        var gamesForTeam = GetTotalGamesByTeam(t);
                        var validForTeam = true;

                        validForTeam = gamesForTeam <= 1;

                        if (!validForTeam) Messages.Add(DayNumber + ": " + t + " has " + gamesForTeam + " games");

                        valid = valid && validForTeam;
                    });

                    return valid;
                }
            }

        }
    }
}


