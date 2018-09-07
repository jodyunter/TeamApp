using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Season.Config;
using System.Linq;
using TeamApp.Domain.Competition.Season;
using TeamApp.Domain;

namespace TeamApp.Services
{
    public class SeasonService
    {
        public Season CreateNewSeason(SeasonCompetition seasonConfig, string seasonName, int year)
        {
            var season = new Season(seasonConfig, seasonName, year);            

            //setup divisions
            var divisions = new Dictionary<string, SeasonDivision>();            

            ProcessRules(seasonConfig.Rules, season, divisions);

            return season;
        }
        

        public void ProcessRules(List<SeasonRule> rules, Season season, Dictionary<string, SeasonDivision> seasonDivisions)
        {
            rules.ForEach(rule => {
                switch (rule.Type)
                {
                    case SeasonRule.DIVISION:
                        AddDivisionToSeason(season, seasonDivisions,  rule.Division);
                        AddTeamToDivision(rule.Team, seasonDivisions[rule.Division.Name]);

                        break;
                    default:
                        throw new NotImplementedException("Season Rule Type: " + rule.Type + " is not implemented");
                }
            });
        }

        public void AddDivisionToSeason(Season season, Dictionary<string, SeasonDivision> seasonDivisions,Division division)
        {
            if (!seasonDivisions.ContainsKey(division.Name))
            {                
                //if the parent hasn't been created, create it first
                if (!(division.Parent == null) && !seasonDivisions.ContainsKey(division.Parent.Name))
                {
                    AddDivisionToSeason(season, seasonDivisions, division.Parent);                    
                }

                var newParentDivision = division.Parent == null ? null : seasonDivisions[division.Parent.Name];
                var newSeasonDivision = new SeasonDivision(season, newParentDivision, season.Year, division.Name, null);
                
                seasonDivisions.Add(division.Name, newSeasonDivision);                                     
            }
                               
        }
        
        public void AddTeamToDivision(Team team, SeasonDivision seasonDivision)
        {
            var newTeam = new SeasonTeam(team.Name, team.Skill, team, seasonDivision.Season, seasonDivision, null, team.Owner, seasonDivision.Season.Year);
            newTeam.Stats = new SeasonTeamStats(newTeam);

            seasonDivision.AddTeam(newTeam);

        }
    }
}
