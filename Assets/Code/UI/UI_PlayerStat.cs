using UnityEngine;
using UnityEngine.UI;

namespace CGTest
{
    public class UI_PlayerStat : MonoBehaviour
    {
        [SerializeField]
        private Image _icon;

        [SerializeField]
        private Text value;

        public void Init(string iconName)
        {
            _icon.sprite = Resources.Load<Sprite>("Icons/" + iconName);
        }

        public void SetStatValue(string v)
        {
            value.text = v;
        }
    }
}
