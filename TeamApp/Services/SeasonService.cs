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

            AddDivisionsToSeason(seasonConfig.Rules, season, divisions, teams);
        }
        

        public void AddDivisionsToSeason(List<SeasonRule> rules, Season season, Dictionary<string, SeasonDivision> seasonDivisions, Dictionary<string, SeasonTeam> seasonTeams)
        {
            rules.ForEach(rule => {
                switch (rule.Type)
                {
                    case SeasonRule.DIVISION:
                        AddDivisionToSeason(season, seasonDivisions, seasonTeams, rule.Division);
                        break;
                    default:
                        throw new NotImplementedException("Season Rule Type: " + rule.Type + " is not implemented");
                }
            });
        }

        public void AddDivisionToSeason(Season season, Dictionary<string, SeasonDivision> seasonDivisions, Dictionary<string, SeasonTeam> seasonTeams, Division division)
        {
            if (!seasonDivisions.ContainsKey(division.Name))
            {
                //if the parent hasn't been created, create it first
                if (!(division.Parent == null) && !seasonDivisions.ContainsKey(division.Parent.Name))
                {
                    AddDivisionToSeason(season, seasonDivisions, seasonTeams, division.Parent);
                }

                //add the current division
                seasonDivisions.Add(division.Name, new SeasonDivision(season, seasonDivisions[division.Parent.Name], season.Year, division.Name, null));                

                //add the teams.  if they already exists, assume they are done
                AddTeamsToDivision(season, division, seasonDivisions[division.Name], seasonTeams);
            }
        
            //assume we have already added the teams
            
        }
        
        public void AddTeamsToDivision(Season season, Division division, SeasonDivision seasonDivision, Dictionary<string, SeasonTeam> seasonTeams)
        {
            //add season teams to the season division based on the division
            division.Teams.ForEach(team =>
            {
                if (!seasonTeams.ContainsKey(team.Name))
                {
                    var newTeam = new SeasonTeam(team.Name, team.Skill, team, season, seasonDivision, null, team.Owner, season.Year);
                    newTeam.Stats = new SeasonTeamStats(newTeam);

                    seasonDivision.Teams.Add(newTeam);
                }
            });
        }
    }
}
