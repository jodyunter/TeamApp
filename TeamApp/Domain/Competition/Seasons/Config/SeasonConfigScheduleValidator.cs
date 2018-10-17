using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Domain.Competition.Seasons.Config
{
    public class SeasonConfigScheduleValidator
    {

        public void SeasonConfigScheduleValidator(SeasonCompetitionConfig config)
        {
            var divisionsWithTeams = new Dictionary<string, SortedSet<string>>();
            var teamsWithDivisions = new Dictionary<string, SortedSet<string>>();

            //"TeamA:TeamB", 0
            //"TeamA:Home", 0
            //"TeamA:Away", 0
            //"TeamA:DIVISION", 0

            var gameCounts = new Dictionary<string, int>();  
            
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
                
            });


        }
    }
}
