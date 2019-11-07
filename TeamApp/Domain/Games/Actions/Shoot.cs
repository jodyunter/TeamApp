using System;
using System.Collections.Generic;

namespace TeamApp.Domain.Games.Actions
{
    public class Shoot : Action
    {
        public override ActionType ActionType { get { return ActionType.Shoot; } }
        GamePlayer attacker = null;
        GamePlayer defender = null;        
        public override Action NextAction()
        {
            if (Result)
            {
                return GetAction(ActionType.ScoreAttempt, Game);
            }
            else
            {
                return Game.PassCarryShoot();
            }
        }

        public override void PostProcess()
        {
            //do nothing
        }

        public override void PreProcess()
        {
            defender = Game.PickPlayer(new List<GamePlayer>() { Game.DefenseLine.Centre, Game.DefenseLine.LeftDefense, Game.DefenseLine.RightDefense });
            attacker = Game.PuckCarrier;

            Game.WriteToLog(attacker.Name + " takes a shot!");
        }

        public override bool Process()
        {
            Result = Game.Success(attacker.Offense + Game.ControlPoints, defender.Defense + Game.DefenseBonus);
            return Result;
        }

        public override void ProcessFailure()
        {            
            Game.WriteToLog(defender.Name + " blocks it and takes it up the ice.");
            Game.PuckCarrier = defender;
            Game.SwitchOffense();
        }

        public override void ProcessStat()
        {
            if (Result)
            {
                attacker.Stats.ShotsOnGoal++;
                defender.Stats.BlockingFail++;
            }
            else
            {
                attacker.Stats.ShotsBlocked++;
                defender.Stats.BlockingSuccess++;
            }
        }

        public override void ProcessSuccess()
        {
            //do nothing special, same puck carrier
        }
    }
}
