using System.Collections.Generic;
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

        public bool ValidateScheduleRule(SeasonScheduleRule rule, IList<SeasonTeamRule> teamRules, IList<SeasonDivisionRule> divisionRules)
        {
            bool valid = true;

            //are the teams active?
            //are the divisions active?
            //are the teams the same?
            if (rule.HomeTeam != null && rule.AwayTeam != null && rule.HomeTeam.Id == rule.AwayTeam.Id)
            {
                var type = "SeasonScheduleRule";
                var message = "Cannot have the same team play itself.";
                var data = string.Format("HomeTeam:{0} AwayTeam:{1}", rule.HomeTeam.Id, rule.AwayTeam.Id);
                var result = string.Format(messageFormat, type, message, data);
                Messages.Add(result);
            }
            
            //are the divisions the same?
            return valid;
        }
        
        
    }
}
