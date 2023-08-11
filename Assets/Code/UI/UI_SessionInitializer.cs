using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CGTest
{
    public class UI_SessionInitializer : MonoBehaviour
    {
        [SerializeField]
        private Button _buttonNewGame;
        
        [SerializeField]
        private Button _buttonNewGameWithBuffs;
        
        [Inject]
        public void Init(SessionInitializer sessionInitializer)
        {
	        _buttonNewGame.onClick.AddListener(() => sessionInitializer.NewGame(false));
	        _buttonNewGameWithBuffs.onClick.AddListener(() => sessionInitializer.NewGame(true));
        }
    }
}
