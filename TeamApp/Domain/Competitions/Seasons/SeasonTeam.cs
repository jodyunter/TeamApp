using System;

namespace TeamApp.Domain.Competitions.Seasons
{
    public class SeasonTeam:SingleYearTeam,IComparable<SeasonTeam>
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string ShortName { get; set; }
        public int Skill { get; set; }        
        public Team Parent { get; set; }
        public Competition Competition { get; set; }

        public SeasonDivision Division { get; set; }
        public SeasonTeamStats Stats { get; set; }
        public string Owner { get; set; }
        public int? FirstYear { get; set; }
        public int? LastYear { get; set; }

        public SeasonTeam() { }
        public SeasonTeam(Competition competition, Team parent, string name, string nickName, string shortName, int skill, string owner, int? year, SeasonTeamStats stats, SeasonDivision division)
            :base(competition, parent, name, nickName, shortName, skill, owner, year)
        {
        }


        public int CompareTo(SeasonTeam other)
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
