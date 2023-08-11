namespace CGTest
{
	public class PlayerFactory
	{
		private readonly PlayerStatFactory _playerStatFactory;
		private readonly PlayersViewHolder _playersViewHolder;
		private readonly BuffsApplier _buffsApplier;
		private readonly PlayerActionsHandler _playerActionsHandler;
		private readonly PlayersModelsHolder _playersModelsHolder;

		public PlayerFactory(
			PlayerStatFactory playerStatFactory,
			PlayersViewHolder playersViewHolder,
			BuffsApplier buffsApplier,
			PlayerActionsHandler playerActionsHandler,
			PlayersModelsHolder playersModelsHolder)
		{
			_playerStatFactory = playerStatFactory;
			_playersViewHolder = playersViewHolder;
			_buffsApplier = buffsApplier;
			_playerActionsHandler = playerActionsHandler;
			_playersModelsHolder = playersModelsHolder;
		}

		public PlayerController[] CreateFromFile(IDataProvider dataProvider)
		{
			PlayerController[] players = new PlayerController[dataProvider.Data.settings.playersCount];
			for (int i = 0; i < dataProvider.Data.settings.playersCount; i++)
			{
				PlayerController playerController = CreatePlayer(dataProvider.Data.stats, i);
				players[i] = playerController;
			}
			return players;
		}

		private PlayerController CreatePlayer(StatData[] stats, int index)
		{
			PlayerData playerData = CreatePlayerData(stats);
			PlayerController playerController = new PlayerController(
				playerData,
				_playersViewHolder.PlayerViews[index],
				_buffsApplier,
				_playerActionsHandler,
				_playersModelsHolder.PlayerAnimationControllers[index]);
			return playerController;
		}
		
		private PlayerData CreatePlayerData(StatData[] stats)
		{
			IPlayerStat[] createdStats = new IPlayerStat[stats.Length];
			for (int i = 0; i < stats.Length; i++)
				createdStats[i] = _playerStatFactory.CreateStat(stats[i]);
			PlayerData playerData = new PlayerData(createdStats);
			return playerData;
		}
	}
}