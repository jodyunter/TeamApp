using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons.Config;
using System.Linq;
using TeamApp.Domain.Competition.Seasons;
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
            var teams = new Dictionary<string, SeasonTeam>();

            ProcessDivisionRules(seasonConfig.DivisionRules, season, divisions);
            ProcessTeamRules(seasonConfig.TeamRules, season, divisions, teams);

            season.Divisions = divisions.Values.ToList();
            season.Teams = teams.Values.ToList();
            return season;
        }
        

        public void ProcessDivisionRules(List<SeasonDivisionRule> rules, Season season, Dictionary<string, SeasonDivision> seasonDivisions)
        {
            //first create all the divisions
            rules.ForEach(rule =>
            {
                seasonDivisions.Add(rule.DivisionName, new SeasonDivision(season, null, season.Year, rule.DivisionName, null));    
            });

            //now setup parent divisions relationships
            rules.ForEach(rule =>
            {
                if (rule.ParentName != null)
                {
                    seasonDivisions[rule.DivisionName].ParentDivision = seasonDivisions[rule.ParentName];
                }
            });

        }
        public void ProcessTeamRules(List<SeasonTeamRule> rules, Season season, Dictionary<string, SeasonDivision> seasonDivisions, Dictionary<string, SeasonTeam> teams)
        {
            rules.ForEach(rule =>
            {
                AddTeamToDivision(rule.Team, seasonDivisions[rule.Division], teams);
            });
        }

        
        public void AddTeamToDivision(Team team, SeasonDivision seasonDivision, Dictionary<string, SeasonTeam> teams)
        {
            var newTeam = new SeasonTeam(team.Name, team.Skill, team, seasonDivision.Season, seasonDivision, null, team.Owner, seasonDivision.Season.Year);
            newTeam.Stats = new SeasonTeamStats(newTeam);

            seasonDivision.AddTeam(newTeam);
            teams.Add(newTeam.Name, newTeam);

        }
    }
}
