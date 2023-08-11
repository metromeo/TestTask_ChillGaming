using System;
using System.Collections.Generic;

namespace CGTest
{
    public class PlayerData
    {
	    public Dictionary<Type, IPlayerStat> DefaultStats = new Dictionary<Type, IPlayerStat>();
        public Dictionary<Type, float> CurrentStats = new Dictionary<Type, float>();

        public PlayerData(IPlayerStat[] stats)
        {
	        for (int i = 0; i < stats.Length; i++)
		        DefaultStats.Add(stats[i].GetType(), stats[i]);
        }

        public void ResetData()
        {
	        CurrentStats.Clear();
	        foreach (KeyValuePair<Type,IPlayerStat> defaultStat in DefaultStats)
		        CurrentStats.Add(defaultStat.Key, defaultStat.Value.Value);
        }
    }
}
