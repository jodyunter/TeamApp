using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain.Games.Actions
{
    public class Carry : Action
    {
        public override ActionType ActionType { get { return ActionType.Carry; } }

        GamePlayer attacker = null;
        GamePlayer defender = null;        

        public override Action NextAction()
        {
            return Game.PassCarryShoot();
        }

        public override void PostProcess()
        {
            //do nothing
        }

        public override void PreProcess()
        {
            attacker = Game.PuckCarrier;
            defender = Game.PickPlayer(new List<GamePlayer>() { Game.DefenseLine.Centre, Game.DefenseLine.LeftWing, Game.DefenseLine.RightWing });

            Game.WriteToLog(Game.PuckCarrier.Name + " tries to carry the puck past " + defender.Name);
        }

        public override bool Process()
        {
            Result = Game.Success(attacker.Offense + Game.ControlPoints, defender.Defense + Game.DefenseBonus);

            return Result;
        }

        public override void ProcessFailure()
        {
            Game.PuckCarrier = Game.PickPlayer(new List<GamePlayer> { Game.DefenseLine.Centre, Game.DefenseLine.LeftWing, Game.DefenseLine.RightWing });
            Game.SwitchOffense();
        }

        public override void ProcessStat()
        {
            if (Result)
            {
                attacker.CarrySuccess++;
                defender.CheckingFail++;
            }
            else
            {
                attacker.CarryFail++;
                defender.CheckingSuccess++;
            }
        }

        public override void ProcessSuccess()
        {
            Game.WriteToLog("What a move!");
            Game.ControlPoints++;

        }
    }
}
