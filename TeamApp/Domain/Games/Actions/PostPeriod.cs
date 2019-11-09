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
            bool isTied = Game.IsTied();
            bool canTie = Game.Rules.CanTie;                                               

            if ((IsInOverTime() && !isTied) //game over because someone scored in overtime or we ended the game not tied||
                || ((OverTimePeriodsPlayed() > Game.Rules.MaxOverTimePeriods) && canTie) //game over because we have played the max overtime periods we're allowed to
                )
                
            {                
                return GetAction(ActionType.GameOver, Game);
            }
            else 
            {
                if (Game.PauseBetweenPeriods)
                {
                    Game.WriteToLog(Game.ToString());
                    Game.WriteToLog("Press enter to start period " + Game.CurrentPeriod);                    
                    Console.ReadLine();
                }
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
