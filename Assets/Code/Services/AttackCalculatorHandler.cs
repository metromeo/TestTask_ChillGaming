using System;
using System.Collections.Generic;
using UnityEngine;

namespace CGTest
{
	public static class AttackCalculatorHandler
    {
        private static float maxArmor = 100f;

        public static AttackResult CalculateAttackResult(Dictionary<Type, float> initiatorStats, Dictionary<Type, float> targetStats)
        {
            float damage = CalcDamage(initiatorStats[typeof(PlayerStat_Damage)], targetStats[typeof(PlayerStat_Armor)]);
            
            float appliedDamage = CalcAppliedDamage(damage, targetStats[typeof(PlayerStat_Health)]);
            float stolenHP = CalcVampHP(appliedDamage, initiatorStats[typeof(PlayerStat_Vampirism)]);

            Dictionary<Type, float> initiatorStatsDelta = new Dictionary<Type, float>();
            Dictionary<Type, float> targetStatsDelta = new Dictionary<Type, float>();
            initiatorStatsDelta.Add(typeof(PlayerStat_Health), stolenHP);
            targetStatsDelta.Add(typeof(PlayerStat_Health), -appliedDamage);
            return new AttackResult(initiatorStatsDelta, targetStatsDelta);
        }

        public static float CalcDamage(float damage, float armor)
        {
            return damage * (1f - Math.Clamp(armor / maxArmor, 0f, 1f));
        }
        
        public static float CalcAppliedDamage(float damage, float targetHP)
        {
            return Mathf.Min(damage, targetHP);
        }
        
        public static float CalcVampHP(float appliedDamage, float vamp)
        {
            return appliedDamage * (vamp / 100f);
        }
    }
}
