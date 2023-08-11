using UnityEngine;

namespace CGTest
{
	public class IdleState : State<PlayerAnimationController>
	{
		public override void EnterState(PlayerAnimationController _owner)
		{
			AnimationClip clip = _owner.GetAnimationClip(PlayerAnimation.Idle);
			_owner.PlayAnimation(clip);
		}

		public override void ExitState(PlayerAnimationController _owner)
		{
		}

		public override void UpdateState(PlayerAnimationController _owner)
		{
			if(_owner.NextPlayerState == PlayerState.Death)
			{
				_owner.StateMachine.ChangeState(new DeathState());
			}
        
			if(_owner.NextPlayerState == PlayerState.Attack)
			{
				_owner.StateMachine.ChangeState(new AttackState());
			}
		}
	}
}