using UnityEngine;

namespace CGTest
{
    public class PlayersViewHolder : MonoBehaviour
    {
        [SerializeField]
        private UI_Player[] _playerViews;

        public UI_Player[] PlayerViews => _playerViews;
    }
}
