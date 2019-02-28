using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.ViewModels.Views.Competition
{
    public class CompetitionSimpleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public bool Started { get; set; }
        public bool Complete { get; set; }
        public string LeagueName { get; set; }
        public string Type
        {
            get
            {
                if (GetType() == typeof(Playoff))
                {
                    return CompetitionViewModel.PLAYOFF_TYPE;
                }
                else if (GetType() == typeof(Season))
                {
                    return CompetitionViewModel.SEASON_TYPE;
                }

                return "NONE";
            }
        }

        public CompetitionSimpleViewModel()
        {

        }
        public CompetitionSimpleViewModel(long id, string name, int year, bool started, bool complete, string leagueName)
        {
            Id = id;
            Name = name;
            Year = year;
            Started = started;
            Complete = complete;
            LeagueName = leagueName;            
        }
    }
}
