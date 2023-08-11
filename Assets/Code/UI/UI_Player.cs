using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CGTest
{
    public class UI_Player : MonoBehaviour
    {
        public Button attackButton;
        public Transform statsPanel;
        public UI_PlayerStat UIPlayerStatPrefab;
        public UI_PlayerBuff UIPlayerBuffPrefab;

        private Dictionary<Type, UI_PlayerStat> _uiPlayerStats = new Dictionary<Type, UI_PlayerStat>();
        private UI_PlayerBuff[] _uiPlayerBuffs;

        private void ClearStats()
        {
	        foreach (KeyValuePair<Type,UI_PlayerStat> pair in _uiPlayerStats)
		        Destroy(pair.Value.gameObject);
	        _uiPlayerStats.Clear();
        }
        
        private void ClearBuffs()
        {
            if (_uiPlayerBuffs != null)
            {
                for (int i = 0; i < _uiPlayerBuffs.Length; i++)
                {
                    Destroy(_uiPlayerBuffs[i].gameObject);
                }

                _uiPlayerBuffs = null;
            }
        }

        public void SetStats(Dictionary<Type, IPlayerStat> stats)
        {
            ClearStats();

            foreach (KeyValuePair<Type,IPlayerStat> stat in stats)
            {
	            UI_PlayerStat uiPlayerStat = Instantiate(UIPlayerStatPrefab, statsPanel);
	            uiPlayerStat.Init(stat.Value.Icon);
	            _uiPlayerStats.Add(stat.Key, uiPlayerStat);
	            UpdateStatValue(stat.Key, stat.Value.Value);
            }
        }

        public void UpdateStatsValues(Dictionary<Type, float> stats)
        {
	        foreach (KeyValuePair<Type,float> stat in stats)
		        UpdateStatValue(stat.Key, stat.Value);
        }

        public void UpdateStatValue(Type statID, float value)
        {
	        string sValue = statID == typeof(PlayerStat_Health) ? $"{value:F2}" : $"{value:F0}";
            _uiPlayerStats[statID].SetStatValue(sValue);
        }
        
        public void SetBuffs(BuffData[] buffs)
        {
            ClearBuffs();
     
            _uiPlayerBuffs = new UI_PlayerBuff[buffs.Length];
            for (var i = 0; i < buffs.Length; i++)
            {
                BuffData buffData = buffs[i];
                _uiPlayerBuffs[i] = Instantiate(UIPlayerBuffPrefab, statsPanel);
                _uiPlayerBuffs[i].Init(buffData.icon, buffData.title);
            }
        }
    }
}
