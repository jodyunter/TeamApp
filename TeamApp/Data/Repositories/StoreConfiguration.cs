﻿using System;
using System.Linq;
using TeamApp.Domain;
using FluentNHibernate.Automapping;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Seasons.Config;
using System.Collections.Generic;
using FluentNHibernate;

namespace TeamApp.Data.Repositories
{
    public class StoreConfiguration : DefaultAutomappingConfiguration
    {
        public override bool ShouldMap(Type type)
        {
            return type.GetInterfaces().ToList().Contains(typeof(IDataObject));
        }

        private static readonly IList<string> IgnoredMembers = new List<string> { "Schedule" };
        private static readonly IList<string> IgnoreMembersWithDeclaryingType
            = new List<string> { "SeasonTeamStats.Points", "SeasonTeamStats.Games", "SeasonTeamStats.GoalDifference"  };
        public override bool ShouldMap(Member member)
        {
            var shouldMap = true;

            IgnoreMembersWithDeclaryingType.ToList().ForEach(str =>
            {
                shouldMap = shouldMap && !(member.DeclaringType + "." + member.Name).Contains(str);
            });

            return base.ShouldMap(member) && !IgnoredMembers.Contains(member.Name) && shouldMap;       
        }

    }
}
