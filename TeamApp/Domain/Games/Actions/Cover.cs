using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games.Actions
{
    public class Cover : Action
    {
        GamePlayer defender = null;

        public override ActionType ActionType { get { return ActionType.CoverAttempt; } }

        public override Action NextAction()
        {
            if (Result)
            {
                return GetAction(ActionType.FaceOff, Game);
            }
            else
            {
                return GetAction(ActionType.Rebound, Game);
            }
        }

        public override void PostProcess()
        {
            //do nothing
        }

        public override void PreProcess()
        {            
            defender = Game.DefenseLine.Goalie;
        }

        public override bool Process()
        {
            Result = Game.Success(defender.Goaltending + Game.GoalieBonus, Game.Offense.Skill + Game.ControlPoints);
            return Result;
        }

        public override void ProcessFailure()
        {
            Game.WriteToLog("Rebound!");            
        }

        public override void ProcessStat()
        {
            if (Result)
            {
                defender.CoverSuccess++;
            }
            else
            {
                defender.CoverFail++;
            }
        }

        public override void ProcessSuccess()
        {
            Game.WriteToLog("He covers it for a faceoff");            
        }
    }
}
