﻿using System.Collections.Generic;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Services
{
    public interface ICompetitionService
    {
        IEnumerable<CompetitionSimpleViewModel> GetCompetitionListByLeagueAndYear(int leagueId, int year);
        IEnumerable<CompetitionSimpleViewModel> GetCompetitionListLeaugeAndYear(int leagueId, int year, bool started, bool finished);
        IEnumerable<CompetitionSimpleViewModel> GetActiveCompetitions(int year);
        IEnumerable<CompetitionSimpleViewModel> GetCompetitionsByYear(int year);
        CompetitionSimpleViewModel GetCompetition(long id);
    }
}