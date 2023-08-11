using UnityEngine;

namespace CGTest
{
    public class AttackState : State<PlayerAnimationController>
    {
        private float animTime = 0f;
        private float animTimeElapsed = 0f;

        public override void EnterState(PlayerAnimationController _owner)
        {
            _owner.SetNextState(PlayerState.None);
            
            AnimationClip clip = _owner.GetAnimationClip(PlayerAnimation.Attack);
            _owner.PlayAnimation(clip);
            animTimeElapsed = 0f;
            animTime = clip.length;
        }

        public override void ExitState(PlayerAnimationController _owner) { }

        public override void UpdateState(PlayerAnimationController _owner)
        {
            animTimeElapsed += Time.deltaTime;

            if(_owner.NextPlayerState == PlayerState.Death)
            {
                _owner.StateMachine.ChangeState(new DeathState());
            }
            
            if (_owner.NextPlayerState == PlayerState.Attack)
            {
                _owner.StateMachine.ChangeState(new AttackState());
            }
            
            if (animTimeElapsed >= animTime)
            {
                _owner.StateMachine.ChangeState(new IdleState());
            }
        }
    }
}
