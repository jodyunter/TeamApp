using System;
using System.Linq;
using System.Collections.Generic;
using TeamApp.Domain.Games.Actions;

namespace TeamApp.Domain.Games
{
    public class NewGame
    {

        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
        public virtual int HomeScore { get; set; } = 0;
        public virtual int AwayScore { get; set; } = 0;
        public virtual bool Complete { get; set; } = false;
        
        public virtual int CurrentPeriod { get; set; }
        public virtual int CurrentTime { get; set; }

        public virtual GameRules Rules { get; set; }

        public Team Offense { get; set; }
        public Team Defense { get; set; }

        public Line OffenseLine { get; set; } = new Line();
        public Line DefenseLine { get; set; } = new Line();

        public Line HomeLine { get; set; } = new Line();
        public Line AwayLine { get; set; } = new Line();
        
        public GamePlayer PuckCarrier { get; set; }


        public GamePlayer Assist1 { get; set; } = null;

        public GamePlayer Assist2 { get; set; } = null;

        public Random Random { get; set; } = null;

        public int ControlPoints { get; set; } = 0;
        public int ControlPointMax { get; set; } = 8;
        public int DefenseBonus { get; set; } = 0;
        public int GoalieBonus { get; set; } = 20;

        //replace with rules
        public const int GAME_PERIOD_LENGTH = 120;
        public const int GAME_PERIODS = 3;

        public bool OutputPlayByPlay { get; set; } = true;

        public void Play()
        {
            Play(Random);

        }


        public void Play(Random random)
        {
            Random = random;

            var action = Actions.Action.GetAction(ActionType.PreGame, this);
            while (!Complete) 
                action = ProcessAction(action);

            
            
            //need to copy the game stats to the player's main stats?

        }


        public void AddAssist(GamePlayer assister)
        {
            if (assister.Team.Name != PuckCarrier.Team.Name) throw new Exception("What the heck is with this goal!?");
            if (Assist1 != null) Assist2 = Assist1;
            Assist1 = assister;
        }

        public void WriteToLog(string logEntry)
        {
            if (OutputPlayByPlay)
                Console.WriteLine(logEntry);
        }

        public Actions.Action ProcessAction(Actions.Action action)
        {
            action.PreProcess();
            if (!action.Process())
            {
                action.ProcessFailure();
            }
            else
            {
                action.ProcessSuccess();
            }

            action.ProcessStat();
            action.PostProcess();

            return action.NextAction();
        }

        //remove to actions
        public Actions.Action PassCarryShoot(int passOdds, int carryOdds, int shootOdds)
        {
            return NextAction(new List<ActionType>() { ActionType.Pass, ActionType.Carry, ActionType.Shoot }, new List<int>() { passOdds, carryOdds, shootOdds });
        }
        //remove to actions
        public Actions.Action PassCarryShoot()
        {
            var passOdds = 10;
            var carryOdds = 10;
            var shootOdds = 10;

            return PassCarryShoot(passOdds, carryOdds, shootOdds);

        }
        //remove to actions
        public Actions.Action NextAction(List<ActionType> possibleActions, List<int> odds)
        {
            return NextAction(possibleActions, odds, Random);
        }
        //remove to actions
        public Actions.Action NextAction(List<ActionType> possibleActions, List<int> odds, Random random)
        {
            odds.ForEach(o =>
            {
                if (o == 0) o = 1;
            });

            int total = odds.Sum();

            for (int i = 1; i < odds.Count; i++)
            {
                odds[i] = odds[i] + odds[i - 1];
            }

            var score = random.Next(total);

            for (int i = 0; i < possibleActions.Count; i++)
            {
                if (score < odds[i])
                {
                    return Actions.Action.GetAction(possibleActions[i], this);
                }

            }

            return null;
        }

        public void SwitchOffense()
        {
            if (Offense.Name.Equals(Home.Name))
            {
                Offense = Away;
                Defense = Home;

                OffenseLine = AwayLine;
                DefenseLine = HomeLine;

            }
            else
            {
                Offense = Home;
                Defense = Away;

                OffenseLine = HomeLine;
                DefenseLine = AwayLine;

            }

            ClearAssists();
            ClearControlPoints();
        }


        public void AddControlPoint()
        {
            ControlPoints++;
            if (ControlPoints > ControlPointMax) ControlPoints = ControlPointMax;


        }
        public void ClearControlPoints()
        {
            ControlPoints = 0;
        }
        public void ClearAssists()
        {
            Assist1 = null;
            Assist2 = null;
        }

        public bool Success(int offenseSkill, int defenseSkill)
        {
            return Success(Offense, Defense, offenseSkill, defenseSkill, Random);

        }
        public bool Success(Team offense, Team defense, int offenseSkill, int defenseSkill, Random random)
        {
            int teamDifferential = offense.Skill - defense.Skill;
            int playerDifferential = offenseSkill - defenseSkill;

            int roll = random.Next(-25, 26);

            int calculatedValue = roll + teamDifferential + playerDifferential;

            return calculatedValue >= 0;
        }


        public GamePlayer PickPlayer(List<GamePlayer> playerList)
        {
            return PickPlayer(playerList, Random);
        }
        public GamePlayer PickPlayer(List<GamePlayer> playerList, Random random)
        {
            return playerList[random.Next(playerList.Count)];
        }

    }
}
