using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competition.Seasons.Config;
using System.Linq;
using TeamApp.Domain.Competition.Seasons;
using TeamApp.Domain;
using TeamApp.Domain.Schedules;

namespace TeamApp.Services
{
    public class SeasonService
    {
        /*
        public Season CreateNewSeason(SeasonCompetitionConfig seasonConfig, string seasonName, int year)
        {
            var season = new Season(seasonConfig, seasonName, year);            

            //setup divisions
            var divisions = new Dictionary<string, SeasonDivision>();
            var teams = new Dictionary<string, SeasonTeam>();

            ProcessDivisionRules(seasonConfig.DivisionRules, season, divisions);
            ProcessTeamRules(seasonConfig.TeamRules, season, divisions, teams);

            season.Divisions = divisions.Values.ToList();
            season.Teams = teams.Values.ToList();

            CreateSeasonSchedule(season, seasonConfig);

            return season;
        }
        

        public void ProcessDivisionRules(List<SeasonDivisionRule> rules, Season season, Dictionary<string, SeasonDivision> seasonDivisions)
        {
            //first create all the divisions
            rules.ForEach(rule =>
            {
                seasonDivisions.Add(rule.DivisionName, new SeasonDivision(season, null, season.Year, rule.DivisionName, rule.Level, rule.Order, null));    
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
        //todo game numbers are messed up
        public void CreateSeasonSchedule(Season season, SeasonCompetitionConfig competition) 
        {
            int day = 1;

            season.Schedule = new Schedule();

            competition.ScheduleRules.ForEach(rule =>
            {
                if (rule.HomeTeamType == rule.AwayTeamType && rule.HomeTeamValue == rule.AwayTeamValue)
                {
                    throw new ApplicationException("Can't have the same home and away types and values");
                }
                var homeTeams = GetTeams(season, rule.HomeTeamType, rule.HomeTeamValue);
                var awayTeams = GetTeams(season, rule.AwayTeamType, rule.AwayTeamValue);
                
                var nextSchedule = Scheduler.CreateGames(
                    season,
                    season.Year, 
                    1,
                    day, 
                    homeTeams.Select(st => st.Parent).ToList(), 
                    (awayTeams == null || awayTeams.Count == 0) ? null: awayTeams.Select(st => st.Parent).ToList(), 
                    rule.Iterations, 
                    rule.HomeAndAway, 
                    season.CompetitionConfig.GameRules);

                day = Scheduler.MergeSchedulesTryToCompress(season.Schedule, nextSchedule) + 1;
            });
            
        }
        */
        public List<SeasonTeam> GetTeams(Season season, int teamType, string teamValue)
        {
            
            var teams = new List<SeasonTeam>();   
            
            switch (teamType)
            {
                case SeasonScheduleRule.DIVISION_TYPE:
                    teams.AddRange(season.GetAllTeamsInDivision(season.GetDivisionByName(teamValue)));
                    break;
                case SeasonScheduleRule.TEAM_TYPE:
                    teams.Add(season.Teams.Where(t => t.Name.Equals(teamValue)).First());
                    break;
                case SeasonScheduleRule.NONE:
                    return null;
            }

            return teams;
        }
    }
}
