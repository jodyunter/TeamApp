namespace TeamApp.Domain.Competitions.Config.Playoffs
{
    public class PlayoffSeriesRule : BaseDataObject, ITimePeriod
    {
        //convert these into seperate eums!
        public const int FROM_SERIES = 0;
        public const int FROM_RANKING = 1;

        public const int BEST_OF_SERIES = 0;
        public const int TOTAL_GOALS = 1;

        public const int GET_WINNER = 0;
        public const int GET_LOSER = 1;

        public virtual PlayoffCompetitionConfig PlayoffConfig { get; set; }
        public virtual string Name { get; set; }
        public virtual int Round { get; set; }
        public virtual int SeriesType { get; set; }
        public virtual int SeriesNumber { get; set; } //total games for total goals, or required wins
        public virtual GameRules GameRules { get; set; } //can be different!

        public virtual int HomeFromType { get; set; }
        public virtual string HomeFromName { get; set; } //ranking group name
        public virtual int HomeFromValue { get; set; } //ranking number, or winner or loser
        public virtual int AwayFromType { get; set; }
        public virtual string AwayFromName { get; set; }
        public virtual int AwayFromValue { get; set; }
        public virtual int? FirstYear { get; set; }
        public virtual int? LastYear { get; set; }
        public virtual int[] HomeGameProgression { get; set; }
        public virtual string WinnerGroupName { get; set; } //this is where the winner goes to after the series is done
        public virtual string WinnerRankFrom { get; set; }  //this is the group from where the ranking number will be taken
        public virtual string LoserGroupName { get; set; }
        public virtual string LoserRankFrom { get; set; }

        public PlayoffSeriesRule()
        {
        }

        public PlayoffSeriesRule(PlayoffCompetitionConfig config, string name, int round, int seriesType, int seriesNumber, GameRules gameRules, int homeFromType, string homeFromName, int homeFromValue, int awayFromType, string awayFromName, int awayFromValue, int? firstYear, int? lastYear, int[] homeGameProgression, string winnerGroupName, string winnerRankFrom, string loserGroupName, string loserRankFrom)
        {
            PlayoffConfig = config;
            Name = name;
            Round = round;
            SeriesType = seriesType;
            SeriesNumber = seriesNumber;
            GameRules = gameRules;
            HomeFromType = homeFromType;
            HomeFromName = homeFromName;
            HomeFromValue = homeFromValue;
            AwayFromType = awayFromType;
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
                SeriesType = BEST_OF_SERIES,
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
                SeriesType = TOTAL_GOALS,
                SeriesNumber = seriesNumber,
                GameRules = gameRules,
                FirstYear = firstYear,
                LastYear = lastYear
            };
        }
    }
}