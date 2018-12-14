using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Data.Repositories.NHibernate;
using TeamApp.Domain;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.Domain.Schedules;
using TeamApp.Test.Helpers;
using Xunit;
using static Xunit.Assert;

namespace TeamApp.Test.Data
{
    public class StandingsRepositoryTests : RepositoryTests<SeasonTeam>
    {

        public override void AddData()
        {
            var test = new RepositoryNHibernate<League>();
            var seasonRepo = new RepositoryNHibernate<Season>();
            var playoffRepo = new RepositoryNHibernate<Playoff>();
            var gameRepo = new RepositoryNHibernate<ScheduleGame>();

            var league = Data2.CreateBasicLeague("NHL");
            var seasonConfig = Data2.CreateBasicSeasonConfiguration(league);
            var playoffConfig = Data2.CreateBasicPlayoffConfiguration(seasonConfig);

            var season = seasonConfig.CreateCompetition(1, null);

            var random = new Random(55123);

            while (!season.IsComplete())
            {
                season.PlayNextDay(random).ForEach(g =>
                {
                    gameRepo.Update(g);
                });

            }

            ((Season)season).SortAllTeams();            
            seasonRepo.Update((Season)season);

            var playoff = playoffConfig.CreateCompetition(1, new List<Competition> { season });

            while (!playoff.IsComplete())
            {
                playoff.PlayNextDay(random).ForEach(g =>
                {
                    gameRepo.Update(g);
                });
            }
            playoffRepo.Update((Playoff)playoff);

            test.Update(league);
            session.Flush();
        }

        public StandingsRepositoryTests() : base(false, true, true)
        {
        }

        [Fact]
        public void ShouldPopulateDatabase()
        {            
            var repo = (StandingsRepositoryNHibernate)repository;

            var data = repo.GetByCompetition(1);

            Equal(7, data.Count);

        }
        public override void SetupRepository()
        {
            this.repository = new StandingsRepositoryNHibernate();
        }
    }
}
