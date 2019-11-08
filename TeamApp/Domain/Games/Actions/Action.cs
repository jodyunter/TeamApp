using System;

namespace TeamApp.Domain.Games.Actions
{
    public abstract class Action
    {
        public virtual NewGame Game { get; set; }
        public virtual bool Result { get; set; }
        public virtual int TimeIncrement { get; set; }
        public abstract void PreProcess();
        public abstract bool Process();
        public abstract void ProcessSuccess();
        public abstract void ProcessFailure();
        public abstract void ProcessStat();
        public abstract void PostProcess();
        public abstract Action GetNextAction();
        public abstract ActionType ActionType { get; }

        public virtual Action NextAction()
        {
            Game.CurrentTime += TimeIncrement;

            if (Game.CurrentTime >= Game.Rules.TimePerPeriod)
            {
                return GetAction(ActionType.PostPeriod, Game);
            }
            {
                return GetNextAction();
            }
        }

        public virtual int OverTimePeriodsPlayed()
        {
            int overTimePeriods = Game.CurrentPeriod - Game.Rules.MinimumPeriods;
            return overTimePeriods < 0 ? 0 : overTimePeriods;

        }
        public virtual bool IsInOverTime()
        {

            return OverTimePeriodsPlayed() > 0;
        }

        public static Action GetAction(ActionType actionType, NewGame game)
        {
            switch (actionType)
            {
                case ActionType.FaceOff:
                    return new FaceOff() { Game = game, TimeIncrement = 1 };
                case ActionType.Carry:
                    return new Carry() { Game = game, TimeIncrement = 1 };
                case ActionType.Shoot:
                    return new Shoot() { Game = game, TimeIncrement = 1 };
                case ActionType.Pass:
                    return new Pass() { Game = game, TimeIncrement = 1 };
                case ActionType.CoverAttempt:
                    return new Cover() { Game = game, TimeIncrement = 1 };
                case ActionType.ScoreAttempt:
                    return new Score() { Game = game, TimeIncrement = 1 };
                case ActionType.Rebound:
                    return new Rebound() { Game = game, TimeIncrement = 1 };
                case ActionType.GameOver:
                    return new GameOver() { Game = game, TimeIncrement = 0 };
                case ActionType.PreGame:
                    return new PreGame() { Game = game, TimeIncrement = 0 };
                case ActionType.PostPeriod:
                    return new PostPeriod() { Game = game, TimeIncrement = 0 };
                case ActionType.PrePeriod:
                    return new PrePeriod() { Game = game, TimeIncrement = 0 };
                default:
                    throw new ApplicationException("Cannot find the given action type: " + actionType);
            }
        }
    }

    public enum ActionType
    {
        FaceOff = 0,
        Carry = 1,
        Pass = 2,
        Shoot = 3,
        ScoreAttempt = 4,
        CoverAttempt = 5,
        Rebound = 6,
        GameOver = 7,
        PreGame = 8,
        PostPeriod = 9,
        PrePeriod = 10
    }




}
