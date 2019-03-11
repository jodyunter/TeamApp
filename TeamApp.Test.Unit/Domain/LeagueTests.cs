using static Xunit.Assert;
using Xunit;
using TeamApp.Domain;
using TeamApp.Domain.Competitions.Config.Seasons;

namespace TeamApp.Test.Domain
{
    public class LeagueTests
    {
        [Fact]
        public void ShouldTestGetCurrentCompetitionConfig()
        {
            var league = new League("League 1", 1, null);

            var seasonConfig1 = new SeasonCompetitionConfig("SeasonConfig 1", league, 1, 1, null, 1, null, null, null, null, null);
            var seasonConfig2 = new SeasonCompetitionConfig("SeasonConfig 2", league, 2, 1, 11, 6, null, null, null, null, null);
            var seasonConfig3 = new SeasonCompetitionConfig("SeasonConfig 3", league, 5, 1, 12, 15, null, null, null, null, null);
            var seasonConfig4 = new SeasonCompetitionConfig("SeasonConfig 4", league, 10, 1, 15, 55, null, null, null, null, null);

            league.CompetitionConfigs.Add(seasonConfig1);
            league.CompetitionConfigs.Add(seasonConfig2);
            league.CompetitionConfigs.Add(seasonConfig3);
            league.CompetitionConfigs.Add(seasonConfig4);

            True(seasonConfig1.IsActive(1), null);
            True(seasonConfig1.IsActive(2), null);
            Equal(seasonConfig1.Name, league.GetNextCompetitionConfig(null, 1).Name);
            Equal(seasonConfig1.Name, league.GetNextCompetitionConfig(null, 55).Name);
            
            Null(league.GetNextCompetitionConfig(seasonConfig1, 55));

            Equal(seasonConfig1.Name, league.GetNextCompetitionConfig(null, 10).Name);
            Equal(seasonConfig2.Name, league.GetNextCompetitionConfig(seasonConfig1, 10).Name);
            Equal(seasonConfig3.Name, league.GetNextCompetitionConfig(seasonConfig2, 10).Name);
            Equal(seasonConfig3.Name, league.GetNextCompetitionConfig(seasonConfig2, 10).Name);

            Equal(seasonConfig3.Name, league.GetNextCompetitionConfig(seasonConfig1, 12).Name);
            Equal(seasonConfig4.Name, league.GetNextCompetitionConfig(seasonConfig1, 13).Name);
            Null(league.GetNextCompetitionConfig(seasonConfig4, 13));



        }
    }
}
