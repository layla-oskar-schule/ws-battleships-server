using Server.Game.Entities;

namespace Server.Game.Chat
{
    public class BattleshipsGameChat
    {

        private readonly BattleshipsGame game;

        public BattleshipsGameChat(BattleshipsGame game) 
        {
            this.game = game;
        }

        private void Send(string message)
        {
            foreach (Player player in game.Players)
            {
                player.Chat.SendMessage(message);
            }
        }

        public void SendGameMessage(string message)
        {
            Send("[GAME]" + message);
        }

        public void SendJoinMessage(Player player)
        {
            string message = $"{player.Name} just joined. ({game.Players.Count}/{BattleshipsGame.s_gamePlayerSize})";
            SendGameMessage(message);
        }

        public void SendStartMessage()
        {
            SendGameMessage("Game is starting now!");
        }

        public void SendGameOverMessage(Player winner)
        {
            SendGameMessage(winner.Name + " won the game!");
        }
    }
}
