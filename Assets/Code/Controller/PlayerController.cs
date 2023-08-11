using System;

namespace CGTest
{
    public class PlayerController
    {
        public PlayerData Data { get; private set; }
        private UI_Player _uiPlayer;

        private BuffsApplier _buffsApplier;
        private PlayerActionsHandler _playerActionsHandler;
        private PlayerAnimationController _playerAnimationController;

        private PlayerController _target;

        public bool IsAlive => Data.CurrentStats[typeof(PlayerStat_Health)] > 0;
        
        public PlayerController(
	        PlayerData data,
            UI_Player uiPlayer,
            BuffsApplier buffsApplier,
            PlayerActionsHandler playerActionsHandler,
            PlayerAnimationController playerAnimationController
        )
        {
            Data = data;
            _uiPlayer = uiPlayer;
            _buffsApplier = buffsApplier;
            _playerActionsHandler = playerActionsHandler;
            _playerAnimationController = playerAnimationController;

            _uiPlayer.attackButton.onClick.AddListener(OnPlayerAttack);
            _uiPlayer.SetStats(Data.DefaultStats);
            
            ResetData();
        }

        public void SetTarget(PlayerController target) => _target = target;
        public void ResetData()
        {
	        Data.ResetData();
	        _uiPlayer.UpdateStatsValues(Data.CurrentStats);
	        _uiPlayer.SetBuffs(Array.Empty<BuffData>());
        }
        
        public void ResetAnimation()
        {
            _playerAnimationController.SetNextState(PlayerState.Idle);
        }
        public void ApplyBuffs(BuffData[] buffs)
        {
	        _buffsApplier.ApplyBuffsToStats(ref Data.CurrentStats, buffs);
	        _uiPlayer.UpdateStatsValues(Data.CurrentStats);
            _uiPlayer.SetBuffs(buffs);
        }

        public void SetStatValue(Type statType, float value)
        {
	        Data.CurrentStats[statType] += value;
            if (statType == typeof(PlayerStat_Health))
                CheckHP();
            _uiPlayer.UpdateStatValue(statType, Data.CurrentStats[statType]);
        }

        private void CheckHP()
        {
            if (!IsAlive)
                OnDie();
        }

        private void OnDie()
        {
            _playerAnimationController.SetNextState(PlayerState.Death);
        }

        private void OnPlayerAttack()
        {
            if (!IsAlive)
                return;
            
            _playerActionsHandler.HandlePlayerAction(new Attack() {Initiator = this, Target = _target});
            _playerAnimationController.SetNextState(PlayerState.Attack);
        }
    }
}
