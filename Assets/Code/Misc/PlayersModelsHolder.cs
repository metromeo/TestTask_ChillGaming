using UnityEngine;

namespace CGTest
{
    public class PlayersModelsHolder : MonoBehaviour
    {
        [SerializeField]
        private PlayerAnimationController[] _playerAnimationControllers;
        
        public PlayerAnimationController[] PlayerAnimationControllers => _playerAnimationControllers;
    }
}
