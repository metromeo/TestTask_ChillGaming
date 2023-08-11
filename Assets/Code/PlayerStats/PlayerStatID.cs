using System;
using System.Collections.Generic;

namespace CGTest
{
	public static class PlayerStatID
	{
		private static Dictionary<int, Type> _playerStatsByID = new Dictionary<int, Type>();
		private static Dictionary<Type, int> _playerStatsIDByType = new Dictionary<Type, int>();
		
		static PlayerStatID()
		{
			_playerStatsByID.Add(0, typeof(PlayerStat_Health));
			_playerStatsByID.Add(1, typeof(PlayerStat_Armor));
			_playerStatsByID.Add(2, typeof(PlayerStat_Damage));
			_playerStatsByID.Add(3, typeof(PlayerStat_Vampirism));

			foreach (KeyValuePair<int,Type> pair in _playerStatsByID)
				_playerStatsIDByType.Add(pair.Value, pair.Key);
		}

		public static Type GetStatType(int statID) => _playerStatsByID[statID];
	}
}