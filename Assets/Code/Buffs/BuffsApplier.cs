using System;
using System.Collections.Generic;

namespace CGTest
{
    public class BuffsApplier
    {
        public void ApplyBuffsToStats(ref Dictionary<Type, float> stats, BuffData[] buffs)
        {
            foreach (BuffData buff in buffs)
            {
                for (int i = 0; i < buff.stats.Length; i++)
                {
                    BuffEffectOnStatData buffEffectOnStatData = buff.stats[i];
                    stats[PlayerStatID.GetStatType(buffEffectOnStatData.statId)] += buffEffectOnStatData.value;
                }
            }
        }
    }
}
