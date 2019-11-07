using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamApp.Domain.Games.Actions
{
    public class Pass : Action
    {
        GamePlayer attacker = null;
        GamePlayer defender = null;
        GamePlayer target = null;

        public override ActionType ActionType { get { return ActionType.Pass; } }

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
         
            var list = new List<GamePlayer>() { Game.OffenseLine.Centre, Game.OffenseLine.LeftWing, Game.OffenseLine.RightWing, Game.OffenseLine.LeftDefense, Game.OffenseLine.RightDefense };
            var count = list.Count;
            list = list.Where(x => !x.Name.Equals(attacker.Name)).ToList();

            defender = Game.PickPlayer(new List<GamePlayer>() { Game.DefenseLine.LeftWing, Game.DefenseLine.RightWing, Game.DefenseLine.LeftDefense, Game.DefenseLine.RightDefense });

            if (list.Count > (count - 1)) throw new ApplicationException("What the heck?");

            target = Game.PickPlayer(list);

        }

        public override bool Process()
        {
            Result = Game.Success(attacker.Offense + Game.ControlPoints, defender.Defense + Game.DefenseBonus);
            return Result;
        }

        public override void ProcessFailure()
        {
            Game.WriteToLog(target.Name + " misses the pass from " + attacker.Name);
            Game.WriteToLog(defender.Name + " intercepts it.");

            Game.PuckCarrier = defender;
            Game.SwitchOffense();

        }

        public override void ProcessStat()
        {
            if (Result)
            {
                attacker.PassSuccess++;
                target.PassReceived++;
                defender.InterceptionFail++;
                Game.AddAssist(target);
            }
            else
            {
                attacker.PassFail++;
                target.PassMissed++;
                defender.InterceptionSuccess++;
            }
        }

        public override void ProcessSuccess()
        {
            Game.WriteToLog(attacker.Name + " passes to " + target.Name);
            Game.PuckCarrier = target;
            Game.ControlPoints++;
        }
    }
}
