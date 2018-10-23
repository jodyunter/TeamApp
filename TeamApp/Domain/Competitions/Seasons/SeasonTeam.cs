using System;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonTeam:SingleYearTeam,IComparable<SeasonTeam>
    {
        public virtual SeasonDivision Division { get; set; }
        public virtual SeasonTeamStats Stats { get; set; }

        public SeasonTeam() { }
        public SeasonTeam(Competition competition, Team parent, string name, string nickName, string shortName, int skill, string owner, int? year, SeasonTeamStats stats, SeasonDivision division)
            :base(competition, parent, name, nickName, shortName, skill, owner, year)
        {
            Stats = stats;
            if (Stats == null) Stats = new SeasonTeamStats(this);
            Division = division;
        }


        public virtual int CompareTo(SeasonTeam other)
        {
            var thisStat = Stats;
            var thatStats = other.Stats;

            int statCompare = Stats.CompareTo(other.Stats);

            if (statCompare == 0)
            {
                return Name.CompareTo(other.Name);
            }
            else
                return statCompare;
        }
    }
}
