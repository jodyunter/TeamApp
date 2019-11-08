using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games.Actions
{
    public class PostPeriod : Action
    {
        public override ActionType ActionType => throw new NotImplementedException();

        public override Action GetNextAction()
        {
            if (Game.CurrentPeriod > NewGame.GAME_PERIODS)
            {
                return GetAction(ActionType.GameOver, Game);
            }
            else
            {                
                return GetAction(ActionType.PrePeriod, Game);
            }
        }

        public override void PostProcess()
        {
            //do nothing
            Game.CurrentPeriod++;
            Game.CurrentTime = 0;
        }

        public override void PreProcess()
        {            
            Game.WriteToLog("Period " + Game.CurrentPeriod + " is over.");
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
            //do nothing
        }

        public override void ProcessSuccess()
        {
            //do nothing
        }
    }
}
