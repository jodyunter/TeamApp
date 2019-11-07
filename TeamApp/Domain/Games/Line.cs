

namespace TeamApp.Domain.Games
{
    public class Line
    {
        const int POSITION_CENTRE = 0;
        const int POSITION_GOALIE = 1;
        const int POSITION_LEFTWING = 2;
        const int POSITION_RIGHTWING = 3;
        const int POSITION_LEFTDEFENSE = 4;
        const int POSITION_RIGHTDEFENSE = 5;

        GamePlayer[] line = new GamePlayer[6];

        public GamePlayer Centre { get { return GetPositionInLine(POSITION_CENTRE); } set { SetPositionInLine(value, POSITION_CENTRE); } }
        public GamePlayer RightWing { get { return GetPositionInLine(POSITION_RIGHTWING); } set { SetPositionInLine(value, POSITION_RIGHTWING); } }
        public GamePlayer LeftWing { get { return GetPositionInLine(POSITION_LEFTWING); } set { SetPositionInLine(value, POSITION_LEFTWING); } }
        public GamePlayer RightDefense { get { return GetPositionInLine(POSITION_RIGHTDEFENSE); } set { SetPositionInLine(value, POSITION_RIGHTDEFENSE); } }
        public GamePlayer LeftDefense { get { return GetPositionInLine(POSITION_LEFTDEFENSE); } set { SetPositionInLine(value, POSITION_LEFTDEFENSE); } }
        public GamePlayer Goalie { get { return GetPositionInLine(POSITION_GOALIE); } set { SetPositionInLine(value, POSITION_GOALIE); } }


        public void SetLine(GamePlayer centre, GamePlayer rightWing, GamePlayer leftWing, GamePlayer rightDefense, GamePlayer leftDefense, GamePlayer goalie)
        {
            Centre = centre;
            LeftWing = leftWing;
            RightWing = rightWing;
            LeftDefense = leftDefense;
            RightDefense = rightDefense;
            Goalie = goalie;
        }

        private void SetPositionInLine(GamePlayer player, int position)
        {
            line[position] = player;
        }

        private GamePlayer GetPositionInLine(int position)
        {
            return line[position];
        }
    }
}
