using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class CompetitionMap:BaseMap<Competition>
    {
        public CompetitionMap()
        {
            References(x => x.CompetitionConfig).Cascade.All();
            Map(x => x.Name);
            Map(x => x.Year);
            HasMany(x => x.Teams).Cascade.All();
            HasMany(x => x.Rankings).Cascade.All();            
            Map(x => x.Started);
            Map(x => x.Finished);
            Map(x => x.StartDay);
            Map(x => x.EndDay);
            HasMany(x => x.Games).Cascade.All();

            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();

        }
    }

       
    public class CompetitionPlayerMap : BaseTimePeriod<CompetitionPlayer>
    {

        public CompetitionPlayerMap()
        {
            References(x => x.Parent);
            References(x => x.CompetitionTeam);
            References(x => x.Competition);
            Map(x => x.Name);
            Map(x => x.Age);
            Map(x => x.Offense);
            Map(x => x.Defense);
            Map(x => x.Goaltending);
            //Not.Map(x => x.Team);

        }
    }

    public class CompetitionTeamMap : BaseTimePeriod<CompetitionTeam>
    {

        public CompetitionTeamMap()
        {
            References(x => x.Competition);
            References(x => x.Parent);
            Map(x => x.Name);
            Map(x => x.NickName);
            Map(x => x.ShortName);
            Map(x => x.Skill);
            Map(x => x.Owner);
            HasMany(x => x.Players);


            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }

    }

    public class CompetitionGamePlayerMap : SubclassMap<CompetitionGamePlayer>
    {
        public CompetitionGamePlayerMap()
        {
            DiscriminatorValue("Competition");

            References(x => x.CompetitionParent);
            References(x => x.CompetitionTeam);
        }
    }

    public class TeamRankingMap:BaseMap<TeamRanking>
    {
        public TeamRankingMap()
        {
            Map(x => x.Rank);
            Map(x => x.GroupLevel);
            Map(x => x.GroupName);
            References(x => x.CompetitionTeam);
        }
    }
}
