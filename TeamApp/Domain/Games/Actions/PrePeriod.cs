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
            Game.WriteToLog("Period " + Game.CurrentPeriod + " is starting.");            
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
