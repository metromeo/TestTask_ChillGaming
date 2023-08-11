using UnityEngine;
using UnityEngine.UI;

namespace CGTest 
{
	public class UI_PlayerBuff : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Text _name;

		public void Init(string iconName, string buffName)
		{
			_icon.sprite = Resources.Load<Sprite>("Icons/" + iconName);
			_name.text = buffName;
		}
	}
}