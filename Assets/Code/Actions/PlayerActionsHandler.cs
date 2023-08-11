using System;
using System.Collections.Generic;

namespace CGTest
{
	public class PlayerActionsHandler
    {
        public void HandlePlayerAction<T>(T action)
        {
	        if (action is Attack attack)
	        {
	            AttackResult attackResult = AttackCalculatorHandler.CalculateAttackResult(attack.Initiator.Data.CurrentStats, attack.Target.Data.CurrentStats);

	            foreach (KeyValuePair<Type,float> pair in attackResult.InitiatorStatsDelta)
		            attack.Initiator.SetStatValue(pair.Key, pair.Value);
	            
	            foreach (KeyValuePair<Type,float> pair in attackResult.TargetStatsDelta)
		            attack.Target.SetStatValue(pair.Key, pair.Value);
	        }
        }
    }
}
