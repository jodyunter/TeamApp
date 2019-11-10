using System;
using System.Collections.Generic;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonTeam:CompetitionTeam,IComparable<SeasonTeam>
    {
        public virtual SeasonDivision Division { get; set; }
        public virtual SeasonTeamStats Stats { get; set; }

        public SeasonTeam() { }

        public SeasonTeam(Competition competition, Team parent, int year, SeasonTeamStats stats, SeasonDivision division)
            :this(competition, parent, parent.Name, parent.NickName, parent.ShortName, parent.Skill, parent.Owner, year, stats, division, null)
        {

        }
        public SeasonTeam(Competition competition, Team parent, string name, string nickName, string shortName, int skill, string owner, int? year, SeasonTeamStats stats, SeasonDivision division, IList<CompetitionPlayer> players)
            :base(competition, parent, name, nickName, shortName, skill, owner, year, players)
        {
            Stats = stats;
            if (Stats == null) Stats = new SeasonTeamStats();
            Division = division;
        }


        public virtual int CompareTo(SeasonTeam other)
        {
            var thisStat = Stats;
            var thatStats = other.Stats;

            int statCompare = Stats.CompareTo(other.Stats);

            if (statCompare == 0)
            {
                return Id.CompareTo(other.Id);
            }
            else
                return statCompare;
        }
    }
}
