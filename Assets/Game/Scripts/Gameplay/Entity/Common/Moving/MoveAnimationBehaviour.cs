using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class MoveAnimationBehaviour : IEntityInit, IEntityUpdate
    {
        private readonly int _moveParameterHash;
        private IEntity _entity;

        public MoveAnimationBehaviour(string moveParameterName)
        {
            _moveParameterHash = Animator.StringToHash(moveParameterName);
        }

        public void Init(in IEntity entity)
        {
            _entity = entity;
        }

        public void OnUpdate(in IEntity entity, in float deltaTime) =>
            _entity.SetAnimatorBool(_moveParameterHash, _entity.IsMoving());
    }
}