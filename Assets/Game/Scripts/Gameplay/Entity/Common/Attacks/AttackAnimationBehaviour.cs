using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class AttackAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private readonly int _attackTriggerName;
        private IEvent _attackEvent;
        private IEntity _entity;

        public AttackAnimationBehaviour(string attackTriggerName)
        {
            _attackTriggerName = Animator.StringToHash(attackTriggerName);
        }
        
        public void Init(in IEntity entity)
        {
            _entity = entity;
            _attackEvent = entity.GetAttackEvent();
            _attackEvent.Subscribe(OnAttack);
        }

        public void Dispose(in IEntity entity) => _attackEvent.Unsubscribe(OnAttack);
        
        private void OnAttack() => _entity.SetAnimatorTrigger(_attackTriggerName);
    }
}