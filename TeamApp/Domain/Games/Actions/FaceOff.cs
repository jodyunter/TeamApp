using System.Collections.Generic;

namespace TeamApp.Domain.Games.Actions
{
    public class FaceOff:Action
    {
        GamePlayer attacker = null;
        GamePlayer defender = null;   

        public override ActionType ActionType { get { return ActionType.FaceOff; } }
        
        public override void PreProcess()
        {            
            Game.ClearAssists();
            Game.ClearControlPoints();
            attacker = Game.OffenseLine.Centre;
            defender = Game.DefenseLine.Centre;

        }

        public override bool Process()
        {
            
            Game.WriteToLog(attacker.Name + " Faces off against " + defender.Name);
            Result = Game.Success(attacker.Offense + defender.Defense, attacker.Offense + defender.Defense);
            return Result;
        }

        public override void ProcessSuccess()
        { 

            Game.WriteToLog(attacker.Name + " Wins the Face off");
        }

        public override void ProcessFailure()
        {
            Game.SwitchOffense();

            Game.WriteToLog(defender.Name + " Wins the Face off");
        }

        public override void ProcessStat()
        {
            if (Result)
            {
                attacker.Stats.FaceOffsWon++;
                defender.Stats.FaceOffsLoses++;
            }
            else
            {
                attacker.Stats.FaceOffsLoses++;
                defender.Stats.FaceOffsWon++;
            }
        }

        public override void PostProcess()
        {
            Game.PuckCarrier = Game.PickPlayer(new List<GamePlayer>() { Game.OffenseLine.LeftWing, Game.OffenseLine.RightWing, Game.OffenseLine.RightDefense, Game.OffenseLine.LeftDefense });
        }

        public override Action GetNextAction()
        {
            return Game.PassCarryShoot();
        }
    }
}
