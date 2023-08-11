using System.Collections.Generic;

namespace CGTest
{
    public class ActionsTargetHandlerDuel : IActionsTargetHandler
    {
        private Dictionary<PlayerController, PlayerController> playerTarget = new Dictionary<PlayerController, PlayerController>();

        public void SetPlayers(PlayerController[] players)
        {
	        playerTarget.Clear();
            playerTarget.Add(players[0], players[1]);
            playerTarget.Add(players[1], players[0]);
        }

        public PlayerController GetTargetFor(PlayerController playerController) => playerTarget[playerController];
    }
}
