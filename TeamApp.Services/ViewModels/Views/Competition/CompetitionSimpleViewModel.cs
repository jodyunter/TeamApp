using System;
using System.Collections.Generic;
using System.Text;

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
        public string Type { get; set; }

        public CompetitionSimpleViewModel(long id, string name, int year, bool started, bool complete, string leagueName, string type)
        {
            Id = id;
            Name = name;
            Year = year;
            Started = started;
            Complete = complete;
            LeagueName = leagueName;
            Type = type;
        }
    }
}
