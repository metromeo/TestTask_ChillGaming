using UnityEngine;

namespace CGTest
{
	public class SessionInitializer
	{
		private readonly PlayerFactory _playerFactory;
		private readonly BuffsSelector _buffsSelector;
		private readonly IDataProvider _dataProvider;
		private readonly IActionsTargetHandler _actionsTargetHandler;

		private Session _currentSession;

		public SessionInitializer(
			PlayerFactory playerFactory,
			BuffsSelector buffsSelector,
			IDataProvider dataProvider,
			
			IActionsTargetHandler actionsTargetHandler
		)
		{
			_playerFactory = playerFactory;
			_buffsSelector = buffsSelector;
			_dataProvider = dataProvider;
			_actionsTargetHandler = actionsTargetHandler;
		}

		public void NewGame(bool withBuffs)
		{
			if (_currentSession == null)
				_currentSession = CreateSession();
			else
				ResetSession();

			_actionsTargetHandler.SetPlayers(_currentSession.Players);
			//assign target
			foreach (PlayerController playerController in _currentSession.Players)
				playerController.SetTarget(_actionsTargetHandler.GetTargetFor(playerController));
			
			if (!withBuffs) return;
			foreach (PlayerController playerController in _currentSession.Players)
			{
				BuffData[] randomBuffs = _buffsSelector.GetRandomBuffs(
					_dataProvider.Data.buffs,
					Random.Range(_dataProvider.Data.settings.buffCountMin, _dataProvider.Data.settings.buffCountMax + 1),
					_dataProvider.Data.settings.allowDuplicateBuffs);
			    playerController.ApplyBuffs(randomBuffs);
			}
		}

		private Session CreateSession()
		{
			return new Session(_playerFactory.CreateFromFile(_dataProvider));
		}

		private void ResetSession()
		{
			foreach (PlayerController playerController in _currentSession.Players)
			{
				playerController.ResetAnimation();
				playerController.ResetData();
			}
		}
	}
}