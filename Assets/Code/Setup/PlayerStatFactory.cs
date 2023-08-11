using System;

namespace CGTest
{
	public class PlayerStatFactory
	{
		public IPlayerStat CreateStat(StatData statData)
		{
			object[] args = new object[] { statData };
			return (IPlayerStat)Activator.CreateInstance(PlayerStatID.GetStatType(statData.id), args);
		}
	}
}