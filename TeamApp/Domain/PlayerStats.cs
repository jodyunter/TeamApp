using System;
using System.Collections.Generic;
using System.Text;

namespace TeamApp.Domain
{
    public class PlayerStats : BaseDataObject
    {        
        public virtual int FaceOffsWon { get; set; } = 0;
        public virtual int FaceOffsLoses { get; set; } = 0;

        public virtual int CarrySuccess { get; set; } = 0;
        public virtual int CarryFail { get; set; } = 0;
        public virtual int CheckingSuccess { get; set; } = 0;
        public virtual int CheckingFail { get; set; } = 0;
        public virtual int ShotsOnGoal { get; set; } = 0;
        public virtual int ShotsBlocked { get; set; } = 0;
        public virtual int BlockingSuccess { get; set; } = 0;
        public virtual int BlockingFail { get; set; } = 0;
        public virtual int Goals { get; set; } = 0;
        public virtual int Assists { get; set; } = 0;
        public virtual int Saves { get; set; } = 0;
        public virtual int GoalsAgainst { get; set; } = 0;
        public virtual int PassSuccess { get; set; } = 0;
        public virtual int PassFail { get; set; } = 0;
        public virtual int PassReceived { get; set; } = 0;
        public virtual int PassMissed { get; set; } = 0;

        public virtual int InterceptionSuccess { get; set; } = 0;
        public virtual int InterceptionFail { get; set; } = 0;
        public virtual int CoverSuccess { get; set; } = 0;
        public virtual int CoverFail { get; set; } = 0;
        public virtual int Rebounds { get; set; } = 0;

        public virtual int GamesPlayed { get; set; } = 0;
        public virtual int Wins { get; set; } = 0;
        public virtual int Loses { get; set; } = 0;
        public virtual int Ties { get; set; } = 0;        
    }
}
