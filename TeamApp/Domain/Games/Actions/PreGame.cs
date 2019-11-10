using System.Linq;
using System.Collections.Generic;

namespace TeamApp.Domain.Games.Actions
{
    public class PreGame : Action
    {
        public override ActionType ActionType { get { return ActionType.PreGame; } }

        public override Action GetNextAction()
        {
            return GetAction(ActionType.PrePeriod, Game);
        }

        public override void PostProcess()
        {
            Game.OffenseLine = Game.HomeLine;
            Game.DefenseLine = Game.AwayLine;
            Game.CurrentPeriod = 1;
        }

        
        public override void PreProcess()
        {
            var Home = Game.Home;
            var Away = Game.Away;

            Game.Offense = Home;
            Game.Defense = Away;

            Game.SetupGamePlayers();

            var HomePlayers = Game.HomePlayers;
            var AwayPlayers = Game.AwayPlayers;


            Game.HomeLine = new Line()
            {
                Centre = HomePlayers[0],
                LeftWing = HomePlayers[1],
                RightWing = HomePlayers[2],
                LeftDefense = HomePlayers[3],
                RightDefense = HomePlayers[4],
                Goalie = HomePlayers[5]
            };
            Game.AwayLine = new Line()
            {
                Centre = AwayPlayers[0],
                LeftWing = AwayPlayers[1],
                RightWing = AwayPlayers[2],
                LeftDefense = AwayPlayers[3],
                RightDefense = AwayPlayers[4],
                Goalie = AwayPlayers[5]
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
