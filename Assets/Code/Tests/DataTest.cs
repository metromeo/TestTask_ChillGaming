using System.IO;
using NUnit.Framework;
using Zenject;

namespace CGTest.Tests
{
    [TestFixture]
    public class DataTest : ZenjectUnitTestFixture
    {
        private string settingsPath = "Settings/GameSettings";
    
        [SetUp]
        public void Bind()
        {
            GameSettingsInstaller.InstallFromResource(settingsPath, Container);
            GameBaseInstaller.Install(Container);
        }
        
        [Test]
        public void JsonDataProviderSettingsResolve()
        {
            DataSettings settings = Container.Resolve<DataSettings>();

            Assert.NotNull(settings);
        }
    
        [Test]
        public void JsonDataProviderResolve()
        {
            JsonDataProvider jsonDataProvider = Container.Resolve<JsonDataProvider>();

            Assert.NotNull(jsonDataProvider);
        }
    
        [Test]
        public void DataJsonExists()
        {
	        DataSettings settings = Container.Resolve<DataSettings>();
        
            using (StreamReader stream = new StreamReader(settings.PathToFile))
            {
                Assert.NotNull(stream);
            }
        }
    
        [Test]
        public void DataIsProvided()
        {
            IDataProvider dataProvider = Container.Resolve<IDataProvider>();
            Assert.NotNull(dataProvider.Data);
        }
    
        [Test]
        public void BuffsAndStatsIsValid()
        {
            IDataProvider dataProvider = Container.Resolve<IDataProvider>();
            Assert.AreNotEqual(dataProvider.Data.stats.Length, 0);
            Assert.AreNotEqual(dataProvider.Data.buffs.Length, 0);
            foreach (var buff in dataProvider.Data.buffs)
            {
                if (buff.stats != null)
                {
                    foreach (var buffStat in buff.stats)
                    {
                        Assert.LessOrEqual(buffStat.statId, dataProvider.Data.stats.Length);
                    }
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            Container.UnbindAll();
        }
    }
}