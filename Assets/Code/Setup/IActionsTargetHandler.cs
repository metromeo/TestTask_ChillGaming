namespace CGTest
{
    public interface IActionsTargetHandler
    {
	    void SetPlayers(PlayerController[] players);
        PlayerController GetTargetFor(PlayerController playerController);
    }
}
