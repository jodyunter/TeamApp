using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;
using TeamApp.Domain.Competitions;
using TeamApp.Domain.Competitions.Playoffs;
using TeamApp.Domain.Competitions.Seasons;

namespace TeamApp.Data.Repositories.Relational.NHibernate.Mappers
{
    public class CompetitionPlayerMap : BaseTimePeriod<CompetitionPlayer>
    {

        public CompetitionPlayerMap()
        {
            HasOne(x => x.Parent);
            HasOne(x => x.CompetitionTeam);
            HasOne(x => x.Competition);
            Map(x => x.Name);
            Map(x => x.Age);
            Map(x => x.Offense);
            Map(x => x.Defense);
            Map(x => x.Goaltending);
            Not.Map(x => x.Team);

        }
    }

    public class CompetitionTeamMap : BaseTimePeriod<CompetitionTeam>
    {

        public CompetitionTeamMap()
        {
            HasOne(x => x.Competition);
            HasOne(x => x.Parent);
            Map(x => x.Name);
            Map(x => x.NickName);
            Map(x => x.ShortName);
            Map(x => x.Skill);
            Map(x => x.Owner);


            DiscriminateSubClassesOnColumn<string>("Type").AlwaysSelectWithValue();
        }

    }

    public class SeasonTeamMap : SubclassMap<SeasonTeam>
    {
        public SeasonTeamMap()
        {
            DiscriminatorValue("Season");
            HasOne(x => x.Division);
            HasOne(x => x.Stats);
        }
    }

    public class PlayoffTeamMap : SubclassMap<PlayoffTeam>
    {
        public PlayoffTeamMap()
        {
            DiscriminatorValue("Playoff");
        }
    }
}
