using System.Collections.Generic;

namespace TeamApp.Domain.Games.Actions
{
    public class Rebound : Action
    {
        GamePlayer player = null;
        public override ActionType ActionType { get { return ActionType.Rebound; } }

        public override Action NextAction()
        {
            return Game.PassCarryShoot();
        }

        public override void PostProcess()
        {
            Game.PuckCarrier = player;
        }

        public override void PreProcess()
        {
            //do nothing
        }

        public override bool Process()
        {
            Result = Game.Success(Game.Offense.Skill, Game.Defense.Skill);

            return Result;
        }

        public override void ProcessFailure()
        {
            Game.SwitchOffense();
        }

        public override void ProcessStat()
        {
            player = Game.PickPlayer(new List<GamePlayer>() { Game.OffenseLine.Centre, Game.OffenseLine.LeftWing, Game.OffenseLine.RightWing, Game.OffenseLine.LeftDefense, Game.OffenseLine.RightDefense });
            player.Stats.Rebounds++;
            //this relies on the offense switching            
            Game.WriteToLog(player.Name + " gets the rebound!");            
        }

        public override void ProcessSuccess()
        {            
            //do nothing
        }
    }
}
