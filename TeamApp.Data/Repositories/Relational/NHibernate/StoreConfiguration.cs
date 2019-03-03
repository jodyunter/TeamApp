using System;
using System.Linq;
using TeamApp.Domain;
using FluentNHibernate.Automapping;
using System.Collections.Generic;
using FluentNHibernate;

namespace TeamApp.Data.Repositories.Relational.NHibernate
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().ToList().Contains(typeof(IDataObject));
        }

        private static readonly IList<string> IgnoredMembers = new List<string> { "Schedule", "Self" };
        private static readonly IList<string> IgnoreMembersWithDeclaryingType
            = new List<string> { "SeasonTeamStats.Points", "SeasonTeamStats.Games", "SeasonTeamStats.GoalDifference"  };
        private static readonly IList<string> DiscriminatedSubClasses
            = new List<string> { "BestOfSeries", "TotalGoalsSeries" };
            
        public override bool ShouldMap(Member member)
        {
            var shouldMap = true;

            IgnoreMembersWithDeclaryingType.ToList().ForEach(str =>
            {
                shouldMap = shouldMap && !(member.DeclaringType + "." + member.Name).Contains(str);
            });

            return base.ShouldMap(member) && !IgnoredMembers.Contains(member.Name) && shouldMap;       
        }

        public override bool IsDiscriminated(Type type)
        {
            return DiscriminatedSubClasses.Contains(type.Name);            
        }

    }
}
