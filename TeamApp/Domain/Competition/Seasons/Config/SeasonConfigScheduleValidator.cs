using System;
using System.Collections.Generic;
using System.Linq;
using static TeamApp.Domain.Competition.Seasons.Config.SeasonScheduleRule;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonConfigScheduleValidator
    {

        public SeasonConfigScheduleValidator(SeasonCompetitionConfig config)
        {
            var divisionsWithTeams = new Dictionary<string, SortedSet<string>>();
            var teamsWithDivisions = new Dictionary<string, SortedSet<string>>();

            //"TeamA:TeamB", 0
            //"TeamA:Home", 0
            //"TeamA:Away", 0
            //"TeamA:Home:DIVISION", 0
            var gameCounts = new Dictionary<string, int>();

            var teamNames = teamsWithDivisions.Keys.ToList();
            var divisionNames = divisionsWithTeams.Keys.ToList();

            for (int i = 0; i < teamNames.Count; i++)
            {
                for (int j = 0; j < teamNames.Count; j++)
                {
                    if (teamNames[i] != teamNames[j])
                    {
                        gameCounts.Add(teamNames[i] + ":" + teamNames[j], 0);
                    }
                }

                for (int j = 0; i < divisionNames.Count; j++)
                {
                    gameCounts.Add(teamNames[i] + ":Away:" + divisionNames[j], 0);
                    gameCounts.Add(teamNames[i] + ":Home:" + divisionNames[j], 0);
                }
            }

            config.DivisionRules.ForEach(divisionRule =>
            {
                if (!divisionsWithTeams.ContainsKey(divisionRule.DivisionName)) divisionsWithTeams.Add(divisionRule.DivisionName, new SortedSet<string>());
            });

            config.TeamRules.ForEach(teamRule =>
            {
                if (!teamsWithDivisions.ContainsKey(teamRule.Team.Name)) teamsWithDivisions.Add(teamRule.Team.Name, new SortedSet<string>());

                divisionsWithTeams[teamRule.Division].Add(teamRule.Team.Name);

                var divRule = config.DivisionRules.Where(dr => dr.DivisionName == teamRule.Division).First();

                while (divRule.ParentName != null)
                {
                    divRule = config.DivisionRules.Where(dr => dr.DivisionName == teamRule.Division).First();
                    divisionsWithTeams[divRule.DivisionName].Add(teamRule.Team.Name);
                }
            });

            //now we've got all of the teams together in their divisions

            config.ScheduleRules.ForEach(sr =>
            {
                var homeTeams = new List<string>();
                var awayTeams = new List<string>();

                string homeDivisionName = null;
                string awayDivisionName = null;

                switch (sr.HomeTeamType)
                {
                    case DIVISION_TYPE:
                        homeTeams.AddRange(divisionsWithTeams[sr.HomeTeamValue]);
                        homeDivisionName = sr.HomeTeamValue;
                        break;
                    case TEAM_TYPE:
                        homeTeams.Add(sr.HomeTeamValue);
                        break;
                }

                switch (sr.AwayTeamType)
                {
                    case DIVISION_TYPE:
                        awayTeams.AddRange(divisionsWithTeams[sr.AwayTeamValue]);
                        awayDivisionName = sr.AwayTeamValue;
                        break;
                    case TEAM_TYPE:
                        awayTeams.Add(sr.AwayTeamValue);
                        break;
                }

                for (int i = 0; i < homeTeams.Count; i++)
                {
                    for (int j = 0; j < awayTeams.Count; j++)
                    {
                        if (homeTeams[i] != awayTeams[i])
                        {
                            gameCounts[homeTeams[i] + ":Home"]++;
                            gameCounts[awayTeams[j] + ":Away"]++;

                            gameCounts[homeTeams[i] + ":" + awayTeams[j]]++;

                            if (sr.HomeAndAway)
                            {
                                gameCounts[awayTeams[i] + ":Home"]++;
                                gameCounts[homeTeams[j] + ":Away"]++;

                                gameCounts[awayTeams[i] + ":" + homeTeams[j]]++;
                            }
                        }
                    }

                }

                if (homeDivisionName != null)
                {
                    for (int i = 0; i < homeTeams.Count; i++)
                    {
                        gameCounts[homeTeams[i] + ":Home" + ":" + awayDivisionName] += awayTeams.Count;
                        if (sr.HomeAndAway)
                            gameCounts[homeTeams[i] + ":Away" + ":" + awayDivisionName] += awayTeams.Count;
                    }
                        
                }
                if (awayDivisionName != null)
                {
                    for (int i = 0; i < awayTeams.Count; i++)
                    {
                        gameCounts[awayTeams[i] + ":Home" + ":" + homeDivisionName] += homeTeams.Count;
                        if (sr.HomeAndAway)
                            gameCounts[awayTeams[i] + ":Home" + ":" + homeDivisionName] += homeTeams.Count;
                    }

                }
                
            });

        }
    }
}
