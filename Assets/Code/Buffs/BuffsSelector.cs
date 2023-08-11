using System.Collections.Generic;
using UnityEngine;

namespace CGTest
{
    public class BuffsSelector
    {
        public BuffData[] GetRandomBuffs(BuffData[] buffs, int count, bool allowDuplicates)
        {
            BuffData[] result = new BuffData[count];
            List<int> available = new List<int>(buffs.Length);
            HashSet<int> selected = new HashSet<int>(count);
            
            for (int i = 0; i < buffs.Length; i++)
            {
	            available.Add(i);
            }

            for (int i = 0; i < count; i++)
            {
                int randomIndex = Random.Range(0, available.Count);
                result[i] = buffs[available[randomIndex]];

                if (!allowDuplicates && !selected.Contains(randomIndex))
                {
	                selected.Add(randomIndex);
	                available.Remove(randomIndex);
                }
            }

            return result;
        }
    }
}
