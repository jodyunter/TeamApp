using System.Collections.Generic;
using System.Linq;
using static TeamApp.Domain.Competitions.Seasons.Config.SeasonScheduleRule;

namespace TeamApp.Domain.Competitions.Seasons.Config
{
    //todo must stop relying on team name
    public class SeasonCompetitionConfigValidator
    {   
        public Dictionary<string, int> GameCounts { get; set; } //use teamname + nickname? or just parent team id
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

     
        }        

        public bool Validate(SeasonCompetitionConfig config, int year)
        {
            var activeTeamRules = config.TeamRules.Where(t => t.IsActive(year)).ToList();
            var activeDivisionRules = config.DivisionRules.Where(d => d.IsActive(year)).ToList();
            var activeScheduleRules = config.ScheduleRules.Where(s => s.IsActive(year)).ToList();

            bool valid = true;
            //are all teams active?

            valid = valid && ValidateActiveTeams(activeTeamRules, year);
            valid = valid && ValidateDivisionRuleExistsForTeamRules(activeDivisionRules, activeTeamRules);
            valid = valid && ValidateScheduleRules(activeScheduleRules, activeTeamRules, activeDivisionRules, year);

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
        //todo maybe get rid of the string and change it to a divisionrule?

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

        public bool ValidateScheduleRules(List<SeasonScheduleRule> scheduleRules, IList<SeasonTeamRule> teamRules, IList<SeasonDivisionRule> divisionRules, int year)
        {
            bool valid = true;

            scheduleRules.ForEach(rule =>
            {
                valid = valid && ValidateScheduleRule(rule, teamRules, divisionRules, year);
            });

            return valid;
        }

        public bool ValidateScheduleRule(SeasonScheduleRule rule, IList<SeasonTeamRule> teamRules, IList<SeasonDivisionRule> divisionRules, int year)
        {
            bool valid = true;
            var type = "SeasonScheduleRule";
            //are the teams active?
            if (rule.HomeTeam != null && (!rule.HomeTeam.Active && !rule.HomeTeam.IsActive(year)))
            {
                valid = false;                
                var message = "Home Team is Not Active.";
                var data = string.Format("HomeTeam:{0} Id:{1}", rule.HomeTeam.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            if (rule.AwayTeam != null && (!rule.AwayTeam.Active && !rule.AwayTeam.IsActive(year)))
            {
                valid = false;                
                var message = "Away Team is Not Active.";
                var data = string.Format("AwayTeam:{0} Id:{1}", rule.AwayTeam.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            //are the divisions active?
            if (rule.HomeDivisionRule != null && !rule.HomeDivisionRule.IsActive(year))
            {                
                var message = "Home Division is Not Active.";
                var data = string.Format("HomeDivisionRule:{0} Id:{1}", rule.HomeDivisionRule.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            if (rule.AwayDivisionRule != null && !rule.AwayDivisionRule.IsActive(year))
            {                
                var message = "Away Division is Not Active.";
                var data = string.Format("AwayDivisionRule:{0} Id:{1}", rule.AwayDivisionRule.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            //are the teams the same?
            if (rule.HomeTeam != null && rule.AwayTeam != null && rule.HomeTeam.Id == rule.AwayTeam.Id)
            {
                valid = false;                                    
                var message = "Cannot have the same team play itself.";
                var data = string.Format("HomeTeam:{0} AwayTeam:{1} Rule:{2}", rule.HomeTeam.Id, rule.AwayTeam.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            
            //are the divisions the same?
            if (rule.HomeDivisionRule != null && rule.AwayDivisionRule != null && rule.AwayDivisionRule.Id == rule.HomeDivisionRule.Id)
            {
                valid = false;                
                var message = "Cannot have the same division play itself.";
                var data = string.Format("HomeDivisionRule:{0} AwayDivisionRule:{1} Rule:{2}", rule.HomeDivisionRule.Id, rule.AwayDivisionRule.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            //are hometeam and division populated?
            if (rule.HomeTeam != null && rule.HomeDivisionRule != null)
            {
                valid = false;
                var message = "Cannot have home and away teams populated";
                var data = string.Format("HomeTeam:{0} HomeDivision:{1} Rule:{2}", rule.HomeTeam.Id, rule.HomeDivisionRule.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            //are awayteam and division populated?
            if (rule.AwayTeam != null && rule.AwayDivisionRule != null)
            {
                valid = false;
                var message = "Cannot have home and away teams populated";
                var data = string.Format("AwayTeam:{0} AwayDivision:{1} Rule:{2}", rule.AwayTeam.Id, rule.AwayDivisionRule.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            //are home team and at least away div or away team populated?
            if (rule.HomeTeam != null && (rule.AwayDivisionRule == null && rule.AwayTeam == null))
            {
                valid = false;
                var message = "If home team is populated, either away team or away division must be";
                var data = string.Format("HomeTeam:{0}  Rule:{1}", rule.HomeTeam.Id, rule.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            //does the team exist for home?
            if (rule.HomeTeam != null)
            {
                var teamRule = teamRules.Where(tr => tr.Team.Id == rule.HomeTeam.Id).FirstOrDefault();

                if (teamRule == null)
                {
                    valid = false;
                    var message = "No home team rule for home team.";
                    var data = string.Format("HomeTeam:{0}  Rule:{1}", rule.HomeTeam.Id, rule.Id);
                    var result = string.Format(messageFormat, type, message, data);
                    Messages.Add(result);
                }
            }
            //does the team exist for away?
            if (rule.AwayTeam != null)
            {
                var teamRule = teamRules.Where(tr => tr.Team.Id == rule.AwayTeam.Id).FirstOrDefault();

                if (teamRule == null)
                {
                    valid = false;
                    var message = "No away team rule for home team.";
                    var data = string.Format("AwayTeam:{0}  Rule:{1}", rule.HomeTeam.Id, rule.Id);
                    var result = string.Format(messageFormat, type, message, data);
                    Messages.Add(result);
                }
            }
            return valid;
        }
               
        
    }
}
