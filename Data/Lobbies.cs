using ChessBlazor.Client.Pages;

namespace ChessServerApp.Data
{
    public class Lobbies
    {
        static public int NumberOfPlayers { get; set; } = 0;

        static public List<Lobby> LobbyList = new List<Lobby>();
        static public Dictionary<string,Lobby> LobbyDictionary = new Dictionary<string, Lobby>();


        public class Lobby
        {
            public string LobbyName   { get; set; }
            public string player1 { get; set; }
            public string player2 { get; set; }
            public string LobbyID { get; set; }
            public int count { get; set; }
        }

















    }
}
