
namespace TeamApp.Domain.Games.Actions
{
    public class PreGame : Action
    {
        public override ActionType ActionType { get { return ActionType.PreGame; } }

        public override Action NextAction()
        {
            return GetAction(ActionType.FaceOff, Game);
        }

        public override void PostProcess()
        {
            Game.OffenseLine = Game.HomeLine;
            Game.DefenseLine = Game.AwayLine;
        }

        public override void PreProcess()
        {
            var Home = Game.Home;
            var Away = Game.Away;

            Game.Offense = Home;
            Game.Defense = Away;

            Game.HomeLine = new Line()
            {
                Centre = new GamePlayer(Game, Home.Players[0], Home, Home.Players[0].FirstYear),
                LeftWing = new GamePlayer(Game, Home.Players[1], Home, Home.Players[1].FirstYear),
                RightWing = new GamePlayer(Game, Home.Players[2], Home, Home.Players[2].FirstYear),
                LeftDefense = new GamePlayer(Game, Home.Players[3], Home, Home.Players[3].FirstYear),
                RightDefense = new GamePlayer(Game, Home.Players[4], Home, Home.Players[4].FirstYear),
                Goalie = new GamePlayer(Game, Home.Players[5], Home, Home.Players[5].FirstYear),
            };
            Game.AwayLine = new Line()
            {
                Centre = new GamePlayer(Game, Away.Players[0], Away, Away.Players[0].FirstYear),
                LeftWing = new GamePlayer(Game, Away.Players[1], Away, Away.Players[1].FirstYear),
                RightWing = new GamePlayer(Game, Away.Players[2], Away, Away.Players[2].FirstYear),
                LeftDefense = new GamePlayer(Game, Away.Players[3], Away, Away.Players[3].FirstYear),
                RightDefense = new GamePlayer(Game, Away.Players[4], Away, Away.Players[4].FirstYear),
                Goalie = new GamePlayer(Game, Away.Players[5], Away, Away.Players[5].FirstYear),
            };
        }

        public override bool Process()
        {
            return true;
        }

        public override void ProcessFailure()
        {
            //do nothing
        }

        public override void ProcessStat()
        {
            var HomeLine = Game.HomeLine;
            var AwayLine = Game.AwayLine;

            HomeLine.Centre.Stats.GamesPlayed++;
            HomeLine.LeftWing.Stats.GamesPlayed++;
            HomeLine.RightWing.Stats.GamesPlayed++;
            HomeLine.LeftDefense.Stats.GamesPlayed++;
            HomeLine.RightDefense.Stats.GamesPlayed++;
            HomeLine.Goalie.Stats.GamesPlayed++;

            AwayLine.Centre.Stats.GamesPlayed++;
            AwayLine.LeftWing.Stats.GamesPlayed++;
            AwayLine.RightWing.Stats.GamesPlayed++;
            AwayLine.LeftDefense.Stats.GamesPlayed++;
            AwayLine.RightDefense.Stats.GamesPlayed++;
            AwayLine.Goalie.Stats.GamesPlayed++;

        }

        public override void ProcessSuccess()
        {
            //do nothing
        }
    }
}
