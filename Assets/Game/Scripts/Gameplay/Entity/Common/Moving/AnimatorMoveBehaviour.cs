using Atomic.Entities;
using Game.Animation;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class AnimatorMoveBehaviour : IEntityInit, IEntityUpdate
    {
        private readonly int _isMoveParameterHash;
        private readonly int _moveSpeedParameterHash;

        public AnimatorMoveBehaviour()
        {
            _isMoveParameterHash = Animator.StringToHash(AnimatorParameters.IsMovingFlagName);
            _moveSpeedParameterHash = Animator.StringToHash(AnimatorParameters.MoveSpeedParameterName);
        }

        public void Init(in IEntity entity)
        {
            Animator animator = entity.GetAnimator();
            animator.SetFloat(_moveSpeedParameterHash, entity.GetMoveSpeed().Value);
        }

        public void OnUpdate(in IEntity entity, in float deltaTime) =>
            entity.MovePositionByAnimator(_isMoveParameterHash);
    }
}