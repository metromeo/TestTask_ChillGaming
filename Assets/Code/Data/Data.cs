using System;

namespace CGTest
{
    [Serializable]
    public class Data
    {
        public GameSettingsData settings;
        public StatData[] stats;
        public BuffData[] buffs;
    }

    [Serializable]
    public class GameSettingsData
    {
        public int playersCount;
        public int buffCountMin;
        public int buffCountMax;
        public bool allowDuplicateBuffs;
    }

    [Serializable]
    public class StatData
    {
        public int id;
        public string title;
        public string icon;
        public float value;
    }

    [Serializable]
    public class BuffEffectOnStatData
    {
        public float value;
        public int statId;
    }

    [Serializable]
    public class BuffData
    {
        public string icon;
        public int id;
        public string title;
        public BuffEffectOnStatData[] stats;
    }
}