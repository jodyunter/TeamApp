using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Services.ViewModels.Views.Competition.Playoff;

namespace TeamApp.Services.Implementation.Mappers
{
    public class PlayoffToPlayoffSummaryMapper:BaseDomainModelMapper<Playoff, PlayoffSummaryViewModel>
    {
        public override PlayoffSummaryViewModel MapDomainToModel(Playoff objs)
        {
            var model = new PlayoffSummaryViewModel();
            model.Id = objs.Id;
            model.Name = objs.Name;
        }
    }
}
