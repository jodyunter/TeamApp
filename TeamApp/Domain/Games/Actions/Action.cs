using System;

namespace TeamApp.Domain.Games.Actions
{
    public abstract class Action
    {
        public NewGame Game { get; set; }
        public bool Result { get; set; }
        public abstract void PreProcess();
        public abstract bool Process();
        public abstract void ProcessSuccess();
        public abstract void ProcessFailure();
        public abstract void ProcessStat();
        public abstract void PostProcess();
        public abstract Action NextAction();
        public abstract ActionType ActionType { get; }

        public static Action GetAction(ActionType actionType, NewGame game)
        {
            switch (actionType)
            {
                case ActionType.FaceOff:
                    return new FaceOff() { Game = game };
                case ActionType.Carry:
                    return new Carry() { Game = game };
                case ActionType.Shoot:
                    return new Shoot() { Game = game };
                case ActionType.Pass:
                    return new Pass() { Game = game};
                case ActionType.CoverAttempt:
                    return new Cover() { Game = game };
                case ActionType.ScoreAttempt:
                    return new Score() { Game = game };
                case ActionType.Rebound:
                    return new Rebound() { Game = game };
                case ActionType.GameOver:
                    return new GameOver() { Game = game };
                case ActionType.PreGame:
                    return new PreGame() { Game = game };
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
        PreGame = 8
    }




}
