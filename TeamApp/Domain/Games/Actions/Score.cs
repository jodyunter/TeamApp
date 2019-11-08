namespace TeamApp.Domain.Games.Actions
{
    public class Score : Action
    {
        GamePlayer attacker = null;
        GamePlayer defender = null;

        public override ActionType ActionType { get { return ActionType.ScoreAttempt; } }

        public override Action NextAction()
        {
            if (Result)
            {
                return GetAction(ActionType.FaceOff, Game);
            }
            else
            {
                return GetAction(ActionType.CoverAttempt, Game);
            }
            
        }

        public override void PostProcess()
        {
            //nothing to do
        }

        public override void PreProcess()
        {
            attacker = Game.PuckCarrier;
            defender = Game.DefenseLine.Goalie;
        }

        public override bool Process()
        {
            Result = Game.Success(attacker.Offense + Game.ControlPoints, defender.Goaltending + Game.GoalieBonus);
            return Result;
        }

        public override void ProcessFailure()
        {
            Game.WriteToLog(defender.Name + " makes the save.");            
        }

        public override void ProcessStat()
        {
            if (Result)
            {
                attacker.Stats.Goals++;
                if (Game.Assist1 != null) Game.Assist1.Stats.Assists++;
                if (Game.Assist2 != null) Game.Assist2.Stats.Assists++;
                defender.Stats.GoalsAgainst++;
                //change to methods like Game.HomeGoal
                if (attacker.Team.Name.Equals(Game.Home.Name))
                {
                    Game.HomeScore++;
                }
                else
                {
                    Game.AwayScore++;
                }
            }
            else
            {
                defender.Stats.Saves++;
            }
        }

        public override void ProcessSuccess()
        {
            Game.WriteToLog(attacker.Name + " scores!");
        }
    }
}
