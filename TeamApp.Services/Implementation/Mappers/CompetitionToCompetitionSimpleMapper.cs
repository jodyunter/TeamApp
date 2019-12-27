using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;
using TeamApp.ViewModels.Views.Competition;

namespace TeamApp.Services.Implementation.Mappers
{
    public class CompetitionToCompetitionSimpleMapper:BaseDomainModelMapper<Competition, CompetitionSimpleViewModel>
    {
        public override CompetitionSimpleViewModel MapDomainToModel(Competition obj)
        {
            string type = "NONE";
            if (obj.GetType() == typeof(Season))
            {
                type = CompetitionViewModel.SEASON_TYPE;
            }
            else if (obj.GetType() == typeof(Playoff))
            {
                type = CompetitionViewModel.PLAYOFF_TYPE;
            }


            var model = new CompetitionSimpleViewModel();
            model.Complete = obj.Finished;
            model.Id = obj.Id;
            model.LeagueName = obj.CompetitionConfig.League.Name;
            model.Started = obj.Started;
            model.Year = obj.Year;            
            model.Type = type;
            model.Name = obj.Name;

            return model;
        }
    }
}
