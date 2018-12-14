using TeamApp.ViewModels.Views;

namespace TeamApp.Services
{
    public interface IStandingsService
    {
        StandingsViewModel GetStandings(int competitionId);
        StandingsViewModel GetStandings(int league, int year, int competitionId);
    }
}