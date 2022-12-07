using ChessServerApp.Pages;
using ChessServerApp.Data;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace ChessServerApp.Hubs
{
    public class GameHub : Hub
    {
        
        public async Task SendMove(string selectedpiece, string selectedtile, int move, string Id, string LobbyName )
        {

            if(Lobbies.LobbyDictionary[LobbyName].player1 == Id)
            {
                await Clients.Client(Lobbies.LobbyDictionary[LobbyName].player2).SendAsync("ReceiveMove", selectedpiece, selectedtile, move);
            }
            else if(Lobbies.LobbyDictionary[LobbyName].player2 == Id) 
            {
                await Clients.Client(Lobbies.LobbyDictionary[LobbyName].player1).SendAsync("ReceiveMove", selectedpiece, selectedtile, move);
            }
        }

        public async Task ConnectionInfo(string Id)
        {
            var test1 = Lobbies.LobbyList.Find(x => x.player1 == Id);
            var test2 = Lobbies.LobbyList.Find(x => x.player2 == Id);

            if (test2 == null)
                await Clients.Caller.SendAsync("ConnectionInfo", 0, test1.LobbyName);
            else
                await Clients.Caller.SendAsync("ConnectionInfo", 1, test2.LobbyName);
            

        }




        public async Task CreateLobby(string connectionid, string lobbyid, string LobbyName)
        {
            if (Lobbies.LobbyDictionary.ContainsKey(LobbyName))
            {
                await Clients.Caller.SendAsync("LobbyExists", false);

            }
            else
            {
                Lobbies.Lobby lobbyinstance = new()
                {
                    player1 = connectionid,
                    LobbyID = lobbyid,
                    LobbyName = LobbyName

                };

                lobbyinstance.count++;

                Lobbies.LobbyList.Add(lobbyinstance);
                Lobbies.LobbyDictionary.Add(LobbyName, lobbyinstance);
                await Clients.Caller.SendAsync("JoinGame", true);
            }


        }

        public async Task JoinLobby(string connectionid, string LobbyName)
        {
            if (!(Lobbies.LobbyDictionary.ContainsKey(LobbyName)) || Lobbies.LobbyDictionary[LobbyName].count>=2)
                {
                    await Clients.Caller.SendAsync("NoLobbyFoundOrFull", false);
                    return;

                }
          

            else if (Lobbies.LobbyDictionary[LobbyName].count<2)
            {
                Lobbies.LobbyDictionary[LobbyName].player2 = connectionid;

                await Clients.Caller.SendAsync("JoinGame", true);
                Lobbies.LobbyDictionary[LobbyName].count++;
            }




        }
    }
}
