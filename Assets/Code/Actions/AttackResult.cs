using System;
using System.Collections.Generic;

namespace CGTest
{
	public struct AttackResult
	{
		public Dictionary<Type, float> InitiatorStatsDelta { get; private set; }
		public Dictionary<Type, float> TargetStatsDelta { get; private set; }
	
		public AttackResult(Dictionary<Type, float> initiatorStatsDelta, Dictionary<Type, float> targetStatsDelta)
		{
			InitiatorStatsDelta = initiatorStatsDelta;
			TargetStatsDelta = targetStatsDelta;
		}
	}
}