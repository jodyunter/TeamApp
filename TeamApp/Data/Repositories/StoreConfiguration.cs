using System;
using System.Linq;
using TeamApp.Domain;
using FluentNHibernate.Automapping;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons.Config;

namespace TeamApp.Data.Repositories
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().ToList().Contains(typeof(IDataObject));
        }

    }
}
