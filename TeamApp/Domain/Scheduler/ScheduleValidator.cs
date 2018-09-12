using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TeamApp.Domain.Scheduler
{
    public class ScheduleValidator
    {
        public Dictionary<string, int> TeamDaysPlayed { get; set; }

        public List<string> ErrorMessages { get; set; }


        public ScheduleValidator()
        {
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
            return !game.HomeTeam.Name.Equals(game.AwayTeam.Name);
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


