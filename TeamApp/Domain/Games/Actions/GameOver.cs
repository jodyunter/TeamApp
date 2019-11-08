using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games.Actions
{
    public class GameOver : Action
    {
        public override ActionType ActionType { get { return ActionType.GameOver; } } 

        public override Action GetNextAction()
        {
            return null;
        }

        public override void PostProcess()
        {
            Game.WriteToLog("Game is over!");
            Game.WriteToLog("Final score is:");
            Game.WriteToLog(Game.Home.Name + " - " + Game.HomeScore);
            Game.WriteToLog(Game.Away.Name + " - " + Game.AwayScore);
            Game.Complete = true;
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
                Game.HomeLine.Goalie.Stats.Wins++;
                Game.AwayLine.Goalie.Stats.Loses++;
                Game.Home.Wins++;
                Game.Away.Loses++;
            }
            else if (Game.HomeScore < Game.AwayScore)
            {
                Game.HomeLine.Goalie.Stats.Loses++;
                Game.AwayLine.Goalie.Stats.Wins++;
                Game.Home.Loses++;
                Game.Away.Wins++;
            }
            else
            {
                Game.HomeLine.Goalie.Stats.Ties++;
                Game.AwayLine.Goalie.Stats.Ties++;
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
