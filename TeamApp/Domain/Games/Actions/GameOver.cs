using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games.Actions
{
    public class GameOver : Action
    {
        public override ActionType ActionType { get { return ActionType.GameOver; } } 

        public override Action NextAction()
        {
            return null;
        }

        public override void PostProcess()
        {
            //do nothing
        }

        public override void PreProcess()
        {
            //do nothing
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
            if (Game.HomeScore > Game.AwayScore)
            {
                Game.HomeLine.Goalie.Wins++;
                Game.AwayLine.Goalie.Loses++;
                Game.Home.Wins++;
                Game.Away.Loses++;
            }
            else if (Game.HomeScore < Game.AwayScore)
            {
                Game.HomeLine.Goalie.Loses++;
                Game.AwayLine.Goalie.Wins++;
                Game.Home.Loses++;
                Game.Away.Wins++;
            }
            else
            {
                Game.HomeLine.Goalie.Ties++;
                Game.AwayLine.Goalie.Ties++;
                Game.Home.Ties++;
                Game.Away.Ties++;
            }

            Game.Home.GoalsFor += Game.HomeScore;
            Game.Home.GoalsAgainst += Game.AwayScore;
            Game.Away.GoalsFor += Game.AwayScore;
            Game.Away.GoalsAgainst += Game.HomeScore;
        }

        public override void ProcessSuccess()
        {
            //do nothing
        }
    }
}
