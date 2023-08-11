namespace CGTest
{
	public abstract class PlayerStat
	{
		public float Value { get; set; }
		public string Icon { get; private set; }
		public string Title { get; private set; }

		public PlayerStat(StatData statData)
		{
			Value = statData.value;
			Icon = statData.icon;
			Title = statData.title;
		}
	}
}