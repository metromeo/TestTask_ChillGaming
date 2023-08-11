namespace CGTest.Tests
{
    public class FakeDataProvider : IDataProvider
    {
        private Data _data;
        public Data Data => _data;

        public FakeDataProvider()
        {
            _data = new Data()
            {
                settings =
                    new GameSettingsData()
                    {
                        allowDuplicateBuffs = false, buffCountMax = 2, buffCountMin = 0, playersCount = 2
                    },
                stats = new StatData[2]
                {
                    new StatData() {icon = "", id = 0, title = "fakeStat1", value = 10},
                    new StatData() {icon = "", id = 1, title = "fakeStat2", value = 20}
                },
                buffs = new BuffData[2]
                {
                    new BuffData()
                    {
                        icon = "",
                        id = 0,
                        title = "fakeBuff1",
                        stats = new BuffEffectOnStatData[1] {new BuffEffectOnStatData() {statId = 0, value = 5}}
                    },
                    new BuffData()
                    {
                        icon = "",
                        id = 0,
                        title = "fakeBuff2",
                        stats = new BuffEffectOnStatData[1] {new BuffEffectOnStatData() {statId = 1, value = -5}}
                    }
                }
            };
        }
    }
}
