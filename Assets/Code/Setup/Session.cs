namespace CGTest
{
	public class Session
	{
		public PlayerController[] Players { get; private set; }

		public Session(PlayerController[] players)
		{
			Players = players;
		}
	}
}