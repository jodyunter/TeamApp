﻿using System.Collections.Generic;
using System.Linq;
using static TeamApp.Domain.Competitions.Seasons.Config.SeasonScheduleRule;

namespace TeamApp.Domain.Competitions.Seasons.Config
{
    //todo must stop relying on team name
    public class SeasonCompetitionConfigValidator
    {   
        public Dictionary<string, int> GameCounts { get; set; }
        public List<string> Messages { get; set; }

        private string messageFormat = "{0}\t{1}\t{2}";

        public SeasonCompetitionConfigValidator() { Messages = new List<string>(); }
        public SeasonCompetitionConfigValidator(SeasonCompetitionConfig config)
        {
            var divisionCounts = new Dictionary<string, SortedSet<string>>();
            var teamCounts = new Dictionary<long, SortedSet<string>>();
            Messages = new List<string>() { "Setting up validator" };

            //"TeamA:TeamB", 0
            //"TeamA:Home", 0
            //"TeamA:Away", 0
            //"TeamA:Home:DIVISION", 0
            var gameCounts = new Dictionary<string, int>();

            var teamNames = config.TeamRules.Select(tr => tr.Team.Name).ToList();
            var divisionNames = config.DivisionRules.Select(dr => dr.DivisionName).ToList();

            for (int i = 0; i < teamNames.Count; i++)
            {
                for (int j = 0; j < teamNames.Count; j++)
                {
                    if (teamNames[i] != teamNames[j])
                    {
                        gameCounts.Add(teamNames[i] + ":" + teamNames[j], 0);
                    }
                }

                for (int j = 0; j < divisionNames.Count; j++)
                {
                    gameCounts.Add(teamNames[i] + ":Away:" + divisionNames[j], 0);
                    gameCounts.Add(teamNames[i] + ":Home:" + divisionNames[j], 0);
                }

                gameCounts.Add(teamNames[i] + ":Away", 0);
                gameCounts.Add(teamNames[i] + ":Home", 0);
                gameCounts.Add(teamNames[i], 0);
            }

            config.DivisionRules.ToList().ForEach(divisionRule =>
            {
                if (!divisionCounts.ContainsKey(divisionRule.DivisionName)) divisionCounts.Add(divisionRule.DivisionName, new SortedSet<string>());
            });

            config.TeamRules.ToList().ForEach(teamRule =>
            {
                if (!teamCounts.ContainsKey(teamRule.Team.Id)) teamCounts.Add(teamRule.Team.Id, new SortedSet<string>());

                divisionCounts[teamRule.Division].Add(teamRule.Team.Name);

                var parentName = config.DivisionRules.Where(dr => dr.DivisionName == teamRule.Division).First().ParentName;

                while (parentName != null)
                {
                    divisionCounts[parentName].Add(teamRule.Team.Name);
                    parentName = config.DivisionRules.Where(dr => dr.DivisionName == parentName).First().ParentName;
                }
            });

            //now we've got all of the teams together in their divisions

            config.ScheduleRules.ToList().ForEach(sr =>
            {
                var homeTeams = new List<string>();
                var awayTeams = new List<string>();

                string homeDivisionName = null;
                string awayDivisionName = null;

                switch (sr.HomeTeamType)
                {
                    case DIVISION_TYPE:
                        homeTeams.AddRange(divisionCounts[sr.HomeTeamValue]);
                        homeDivisionName = sr.HomeTeamValue;
                        break;
                    case TEAM_TYPE:
                        homeTeams.Add(sr.HomeTeamValue);
                        break;
                }

                switch (sr.AwayTeamType)
                {
                    case DIVISION_TYPE:
                        awayTeams.AddRange(divisionCounts[sr.AwayTeamValue]);
                        awayDivisionName = sr.AwayTeamValue;
                        break;
                    case TEAM_TYPE:
                        awayTeams.Add(sr.AwayTeamValue);
                        break;
                    case NONE:
                        awayTeams.AddRange(homeTeams);
                        break;                        
                }                
                
           

                //same teams
                if (sr.AwayTeamType == NONE) {
                    for (int i = 0; i < homeTeams.Count - 1; i++)
                    {
                        var homeTeamName = homeTeams[i];
                        var jStart = sr.HomeAndAway ? i + 1 : 0;

                        for (int j = jStart; j < awayTeams.Count; j++)
                        {
                            var awayTeamName = awayTeams[j];
                            if (!homeTeamName.Equals(awayTeamName))
                            {
                                gameCounts[homeTeamName + ":Home"] += sr.Iterations;
                                gameCounts[awayTeamName + ":Away"] += sr.Iterations;
                                gameCounts[homeTeamName] += sr.Iterations;
                                gameCounts[awayTeamName] += sr.Iterations;

                                gameCounts[homeTeamName + ":" + awayTeamName] += sr.Iterations;

                                if (sr.HomeAndAway)
                                {
                                    gameCounts[homeTeamName + ":Away"] += sr.Iterations;
                                    gameCounts[awayTeamName + ":Home"] += sr.Iterations;
                                    gameCounts[homeTeamName] += sr.Iterations;
                                    gameCounts[awayTeamName] += sr.Iterations;

                                    gameCounts[awayTeamName + ":" + homeTeamName] += sr.Iterations;
                                }
                            }

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < homeTeams.Count; i++)
                    {
                        var homeTeamName = homeTeams[i];
                        var jStart = sr.HomeAndAway ? i + 1 : 0;

                        for (int j = 0; j < awayTeams.Count; j++)
                        {
                            var awayTeamName = awayTeams[j];
                            if (!homeTeamName.Equals(awayTeamName))
                            {
                                gameCounts[homeTeamName + ":Home"] += sr.Iterations;
                                gameCounts[awayTeamName + ":Away"] += sr.Iterations;
                                gameCounts[homeTeamName] += sr.Iterations;
                                gameCounts[awayTeamName] += sr.Iterations;

                                gameCounts[homeTeamName + ":" + awayTeamName] += sr.Iterations;

                                if (sr.HomeAndAway)
                                {
                                    gameCounts[homeTeamName + ":Away"] += sr.Iterations;
                                    gameCounts[awayTeamName + ":Home"] += sr.Iterations;
                                    gameCounts[homeTeamName] += sr.Iterations;
                                    gameCounts[awayTeamName] += sr.Iterations;

                                    gameCounts[awayTeamName + ":" + homeTeamName] += sr.Iterations;
                                }
                            }

                        }
                    }
                }
                
            });

            GameCounts = gameCounts;
        }        

        public bool Validate(SeasonCompetitionConfig config, int year)
        {
            var activeTeamRules = config.TeamRules.Where(t => t.IsActive(year)).ToList();
            var activeDivisionRules = config.DivisionRules.Where(d => d.IsActive(year)).ToList();

            bool valid = true;
            //are all teams active?

            valid = valid && ValidateActiveTeams(activeTeamRules, year);
            valid = valid && ValidateDivisionRuleExistsForTeamRules(activeDivisionRules, activeTeamRules);

            return valid;
        }
        
        public bool ValidateActiveTeams(List<SeasonTeamRule> teamRules, int year)
        {
            bool valid = true;

            teamRules.ForEach(rule =>
            {
                var active = rule.Team.IsActive(year) && rule.Team.Active;
                if (!active)
                {
                    var type = "SeasonTeamRule";
                    var message = "Team is not active for year.";
                    var data = string.Format("Id:{0} Name:{1} Year:{2}", rule.Id, rule.Team.Name, year);
                    var result = string.Format(messageFormat, type, message, data);
                    Messages.Add(result);
                }

                valid = valid && active;
            });
            
            return valid;
        }

        public bool ValidateDivisionRuleExistsForTeamRules(List<SeasonDivisionRule> divisionRules, List<SeasonTeamRule> teamRules)
        {
            bool valid = true;

            teamRules.ForEach(rule =>
            {
                var active = DoesSeasonDivisionRuleExistForSeasonTeamRule(divisionRules, rule);
                if (!active)
                {
                    var type = "SeasonDivisionRule";
                    var message = "Rule does not exist for division.";
                    var data = string.Format("Division:{0} TeamRule:{1}", rule.Division, rule.Id);
                    var result = string.Format(messageFormat, type, message, data);
                    Messages.Add(result);
                }

                valid = valid && active;
            });

            return valid;
        }

        //does not check for active divisions
        public bool DoesSeasonDivisionRuleExistForSeasonTeamRule(IList<SeasonDivisionRule> currentDivisionRules, SeasonTeamRule seasonTeamRule)
        {
            var found = false;

            found = currentDivisionRules.Where(dr => dr.DivisionName.Equals(seasonTeamRule.Division)).Count() > 0;
            
            return found;
        }        

        /*todo after re-working the SeasonScheduleRule to contain references instead of strings
        public bool ValidateScheduleRule(SeasonScheduleRule rule, IList<SeasonTeamRule> teamRules, IList<SeasonDivisionRule> divisionRules)
        {
            bool valid = true;

            switch(rule.HomeTeamType)
            {
                case DIVISION_TYPE:
                    var found = divisionRules.Where(dr => dr.DivisionName.Equals(rule.HomeTeamValue)).ToList().Count > 0;
                    if (!found)
                    {
                        var type = "SeasonScheduleRule";
                        var message = "Division not found.";
                        var data = string.Format("Division:{0} ScheduleRule:{1}", rule.HomeTeamValue, rule.Id);
                        var result = string.Format(messageFormat, type, message, data);
                        Messages.Add(result);
                    }
                    break;
                case TEAM_TYPE:
                    var found = teamRules.Where(tr => tr.Team.)
                    break;
            }
            return valid;
        }
        */
        
    }
}
