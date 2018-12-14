using System.Collections.Generic;
using System.Linq;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Repositories;
using TeamApp.ViewModels.Views;

namespace TeamApp.Services.Implementation
{
    public class StandingsService:BaseService<SeasonTeam, StandingsTeamViewModel>, IStandingsService
    {
        private IStandingsRepository standingsRepository;
        private ITeamRankingRepository teamRankingRepository;

        public StandingsService(IStandingsRepository StandingsRepository, ITeamRankingRepository TeamRankingRepository)
        {
            standingsRepository = StandingsRepository;
            teamRankingRepository = TeamRankingRepository;
        }


        public StandingsViewModel GetStandings(int competitionId)
        {
            var teams = standingsRepository.GetByCompetition(competitionId);
            
            var models = MapDomainToModel(teams.ToList());

            var ranks = teamRankingRepository.GetByCompetition(competitionId).ToList();

            models.ForEach(model =>
            {
                ranks.Where(r => r.Team.Name.Equals(model.TeamName)).ToList().ForEach(rank =>
                {
                    AddRankToModel(rank.GroupName, rank.Rank, model);
                });
            });

            return new StandingsViewModel()
            {
                Teams = models
            };


            
        }

        private void AddRankToModel(string divname, int rank, StandingsTeamViewModel model)
        {
            if (model.Rankings == null)
            {
                model.Rankings = new Dictionary<string, int>();
            }

            if (!model.Rankings.ContainsKey(divname)) model.Rankings.Add(divname, rank);            
        }
        public override StandingsTeamViewModel MapDomainToModel(SeasonTeam obj)
        {
            var model = new StandingsTeamViewModel
            {
                TeamName = obj.Name,
                Division = obj.Division.Name,
                Wins = obj.Stats.Wins,
                Ties = obj.Stats.Ties,
                Loses = obj.Stats.Loses,
                GoalsFor = obj.Stats.GoalsFor,
                GoalsAgainst = obj.Stats.GoalsAgainst,
                GamesPlayed = obj.Stats.Games,
                GoalDifference = obj.Stats.GoalDifference,
                Points = obj.Stats.Points
            };            

            return model;
        }

        public StandingsViewModel GetStandings(int league, int year, int competitionId)
        {
            //command to get the standings from the database/repository
            var teams = new List<StandingsTeamViewModel>();

            for (int i = 0; i < 20; i++)
            {
                teams.Add(new StandingsTeamViewModel()
                {
                    TeamName = "Team " + i,
                    Division = "League",
                    Rank = i + 1,
                    Wins = 0,
                    Loses = 0,
                    Ties = 0,
                    GoalDifference = 0,
                    GoalsFor = 0,
                    GoalsAgainst = 0,
                    GamesPlayed = 0,
                    Points = 0
                });
            }
            var standingsView = new StandingsViewModel()
            {
                StandingsName = "League",
                Teams = teams
            };

            return standingsView;
            
        }
    }
}
