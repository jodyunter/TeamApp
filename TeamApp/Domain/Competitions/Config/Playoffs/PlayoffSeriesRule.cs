using TeamApp.Domain.Games;

namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffSeriesRule : BaseDataObject, ITimePeriod
    {
        private int[] homeGameProgression;

        public enum Type { BestOf, TotalGoals };
        public enum Result { Winner, Loser };        

        public virtual PlayoffCompetitionConfig PlayoffConfig { get; set; }
        public virtual string Name { get; set; }
        public virtual int Round { get; set; }
        public virtual Type SeriesType { get; set; }
        public virtual int SeriesNumber { get; set; } //total games for total goals, or required wins
        public virtual GameRules GameRules { get; set; } //can be different!
        
        public virtual string HomeFromName { get; set; } //ranking group name
        public virtual int HomeFromValue { get; set; } //ranking number, or winner or loser        
        public virtual string AwayFromName { get; set; }
        public virtual int AwayFromValue { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual int[] HomeGameProgression
        {
            get
            {
                if (homeGameProgression == null) return homeGameProgression;
                else
                {
                    var splitString = HomeGameProgressionString.Split(",");
                    var result = new int[splitString.Length];
                    for (int i = 0; i < splitString.Length; i++)
                    {
                        result[i] = int.Parse(splitString[i]);
                    }
                    return result;
                }
            }
            set
            {
                homeGameProgression = value;
                HomeGameProgressionString = "";
                for (int i = 0; i < value.Length; i++)
                {
                    if (i != 0) HomeGameProgressionString += ",";
                    HomeGameProgressionString += value[i];
                }
            }
        }
        public virtual string WinnerGroupName { get; set; } //this is where the winner goes to after the series is done
        public virtual string WinnerRankFrom { get; set; }  //this is the group from where the ranking number will be taken
        public virtual string LoserGroupName { get; set; }
        public virtual string LoserRankFrom { get; set; }

        public string HomeGameProgressionString { get; set; }

        public PlayoffSeriesRule()
        {
        }

        public PlayoffSeriesRule(PlayoffCompetitionConfig config, string name, int round, Type seriesType, int seriesNumber, GameRules gameRules, string homeFromName, int homeFromValue, string awayFromName, int awayFromValue, int? firstYear, int? lastYear, int[] homeGameProgression, string winnerGroupName, string winnerRankFrom, string loserGroupName, string loserRankFrom)
        {
            PlayoffConfig = config;
            Name = name;
            Round = round;
            SeriesType = seriesType;
            SeriesNumber = seriesNumber;
            GameRules = gameRules;            
            HomeFromName = homeFromName;
            HomeFromValue = homeFromValue;            
            AwayFromName = awayFromName;
            AwayFromValue = awayFromValue;
            FirstYear = firstYear;
            LastYear = lastYear;
            HomeGameProgression = homeGameProgression;
            WinnerGroupName = winnerGroupName;
            WinnerRankFrom = winnerRankFrom;
            LoserGroupName = loserGroupName;
            LoserRankFrom = loserRankFrom;
        }

        public static PlayoffSeriesRule CreateBestOfSeries(PlayoffCompetitionConfig config, string name, int round, int seriesNumber, GameRules gameRules, int? firstYear, int? lastYear)
        {
            return new PlayoffSeriesRule()
            {
                PlayoffConfig = config,
                Name = name,
                Round = round,
                SeriesType = Type.BestOf,
                SeriesNumber = seriesNumber,
                GameRules = gameRules,
                FirstYear = firstYear,
                LastYear = lastYear
            };
        }

        public static PlayoffSeriesRule CreateTotalGoalsSeries(PlayoffCompetitionConfig config, string name, int round, int seriesNumber, GameRules gameRules, int? firstYear, int? lastYear)
        {
            return new PlayoffSeriesRule()
            {
                PlayoffConfig = config,
                Name = name,
                Round = round,
                SeriesType = Type.TotalGoals,
                SeriesNumber = seriesNumber,
                GameRules = gameRules,
                FirstYear = firstYear,
                LastYear = lastYear
            };
        }
    }
}