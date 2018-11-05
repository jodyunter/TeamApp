namespace TeamApp.Domain
{
    //this should hold a seperate table for current game state and data
    public class GameData:BaseDataObject
    {
        public virtual int CurrentYear { get; set; }
        public virtual int CurrentDay { get; set; }        
        //Current Year
        //List of Leagues
        //List of Current Year Competitions
        //List of Teams as of This Year and their status                       
    }
}
