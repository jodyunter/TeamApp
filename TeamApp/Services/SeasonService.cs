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
        public void CreateNewSeason(SeasonCompetition seasonConfig, string seasonName, int year)
        {
            var season = new Season(seasonConfig, seasonName, year);            

            //setup divisions
            var divisions = new Dictionary<string, SeasonDivision>();
            var teams = new Dictionary<string, SeasonTeam>();

            seasonConfig.Rules.ForEach(rule => {
                switch(rule.Type)
                {
                    case SeasonRule.DIVISION:
                        AddDivisionToSeason(season, divisions, teams, rule.Division);
                        break;
                    default:
                        throw new NotImplementedException("Season Rule Type: " + rule.Type + " is not implemented");
                }
            });
        }
        
        public void AddDivisionToSeason(Season season, Dictionary<string, SeasonDivision> divisions, Dictionary<string, SeasonTeam> teams, Division divisionToAdd)
        {
            if (!divisions.ContainsKey(divisionToAdd.Name))
            {
                //if the parent hasn't been created, create it first
                if (!divisions.ContainsKey(divisionToAdd.Parent.Name))
                {
                    AddDivisionToSeason(season, divisions, teams, divisionToAdd.Parent);
                }

                //add the current division
                divisions.Add(divisionToAdd.Name, new SeasonDivision(season, divisions[divisionToAdd.Parent.Name], season.Year, divisionToAdd.Name, null));
                var seasonDivision = divisions[divisionToAdd.Name];
                //add the teams.  if they already exists, assume they are done
                divisionToAdd.Teams.ForEach(team =>
                {
                    if (!teams.ContainsKey(team.Name))
                    {
                        var newTeam = new SeasonTeam(team.Name, team.Skill, team, season, seasonDivision, null, team.Owner, season.Year);
                        newTeam.Stats = new SeasonTeamStats(newTeam);

                        seasonDivision.Teams.Add(newTeam);
                    }
                });
            }
            else
            {
                //assume we have already added the teams
                return;
            }
        }
    }
}
