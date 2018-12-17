using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services
{
    public interface IStandingsService
    {
        StandingsViewModel GetStandings(int competitionId);        
    }
}