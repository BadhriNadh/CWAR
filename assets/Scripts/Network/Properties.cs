
namespace com.hash.cwar.network
{
    public class GameProperties
    {
        public const string gameVersion = "1";

        public const byte maxPlayers = 6;

        public const int playerTimeout = 30000;

        // Change array for multiple scenes
        public const string gameScene = "PortScene";

        public const string mainScene = "MainScene";

        public const float gameTime = 300.0f;

        public const float gameInitFloat = 0.0f;

        public const int gameInitInt = 0;
    }

    public class CustomProperties 
    {
        // Room
        public const string roomKillsA = "A_Kills";
        public const string roomKillsB = "B_Kills";
        public const string roomCoin = "Coin";
        public const string roomLevelPlayers = "PlayersInScene";
        public const string roomStartTime = "Time";

        // Player
        public const string playerID = "ID";
        public const string playerKills = "Kills";
        public const string playerTeam = "Team";
        public const string playerDeaths = "deaths";
        public const string playerCoin = "Coin";
        public const string playerCarType = "CarType";
    }

    public class Team 
    {
        public const string A = "A";
        public const string B = "B";
        public const string N = "N";
    }  
    
    public class EventCodes
    {
        public const byte readyPlayerEventCode = 1;
    }
}
