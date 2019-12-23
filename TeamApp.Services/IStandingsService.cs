using System.Threading.Tasks;
using TeamApp.ViewModels.Views.Standings;

namespace TeamApp.Services
{
    public interface IStandingsService
    {
        Task<StandingsViewModel> GetStandings(long competitionId, int sortingLevel);
        Task<StandingsViewModel> GetStandings(long competitionConfigId, int year, int sortingLevel);
    }
}