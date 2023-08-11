using UnityEngine;

namespace CGTest
{
    public enum PlayerAnimation
    {
        Idle, Attack, Death
    }
    
    [RequireComponent(typeof(Animation))]
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField]
        private AnimationClip[] _animationClips;
        
        private Animation _animation;

        public PlayerState NextPlayerState { get; private set; }
        public StateMachine<PlayerAnimationController> StateMachine { get; private set; }

        public Animation Animation => _animation;

        private void Start()
        {
            _animation = GetComponent<Animation>();
            foreach (AnimationClip clip in _animationClips)
                _animation.AddClip(clip, clip.name);
            
            StateMachine = new StateMachine<PlayerAnimationController>(this);
            StateMachine.ChangeState(new IdleState());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                SetNextState(PlayerState.Attack);
            if (Input.GetKeyDown(KeyCode.Alpha2))
                SetNextState(PlayerState.Idle);

            StateMachine.Update();
        }

        public void SetNextState(PlayerState playerState)
        {
            NextPlayerState = playerState;
        }

        public void PlayAnimation(AnimationClip animationClip)
        {
            _animation.Stop();
            _animation.Play(animationClip.name);
        }

        public AnimationClip GetAnimationClip(PlayerAnimation playerAnimation)
        {
            return _animationClips[(int) playerAnimation];
        }
    }
}
