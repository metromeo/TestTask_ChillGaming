using UnityEngine;

namespace CGTest
{
    public class DeathState : State<PlayerAnimationController>
    {
        public override void EnterState(PlayerAnimationController _owner)
        {
            AnimationClip clip = _owner.GetAnimationClip(PlayerAnimation.Death);
            _owner.PlayAnimation(clip);
        }

        public override void ExitState(PlayerAnimationController _owner)
        {
        }

        public override void UpdateState(PlayerAnimationController _owner)
        {
            if(_owner.NextPlayerState == PlayerState.Idle)
            {
                _owner.StateMachine.ChangeState(new IdleState());
            }
        }
    }
}
