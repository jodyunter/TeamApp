using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games.Actions
{
    public class PrePeriod : Action
    {
        public override ActionType ActionType => throw new NotImplementedException();

        public override Action GetNextAction()
        {
            return GetAction(ActionType.FaceOff, Game);
        }

        public override void PostProcess()
        {
            //do nothing                           
        }

        public override void PreProcess()
        {
            if (Game.CurrentPeriod > Game.Rules.MinimumPeriods)
            {
                Game.WriteToLog("Over Time Begin! Period Number " + Game.CurrentPeriod);
            }
            else
            {
                Game.WriteToLog("Period " + Game.CurrentPeriod + " is starting.");       
                if (Game.PauseBetweenPeriods)
                {
                    Console.ReadLine();
                }
            }
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
