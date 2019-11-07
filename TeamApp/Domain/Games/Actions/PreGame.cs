﻿
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

            Game.HomeLine = Home.SetDefaultLine();
            Game.AwayLine = Away.SetDefaultLine();
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

            HomeLine.Centre.GamesPlayed++;
            HomeLine.LeftWing.GamesPlayed++;
            HomeLine.RightWing.GamesPlayed++;
            HomeLine.LeftDefense.GamesPlayed++;
            HomeLine.RightDefense.GamesPlayed++;
            HomeLine.Goalie.GamesPlayed++;

            AwayLine.Centre.GamesPlayed++;
            AwayLine.LeftWing.GamesPlayed++;
            AwayLine.RightWing.GamesPlayed++;
            AwayLine.LeftDefense.GamesPlayed++;
            AwayLine.RightDefense.GamesPlayed++;
            AwayLine.Goalie.GamesPlayed++;

        }

        public override void ProcessSuccess()
        {
            //do nothing
        }
    }
}