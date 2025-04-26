using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class TakeDamageAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private readonly int _takeDamageTriggerName;
        private IEvent<TakeDamageArgs> _takeDamageEvent;
        private IEntity _entity;

        public TakeDamageAnimationBehaviour(string takeDamageTriggerName) 
        {
            _takeDamageTriggerName = Animator.StringToHash(takeDamageTriggerName);
        }

        public void Init(in IEntity entity)
        {
            _entity = entity;
            _takeDamageEvent = entity.GetTakeDamageEvent();
            _takeDamageEvent.Subscribe(OnTakeDamage);
        }
        
        public void Dispose(in IEntity entity) => _takeDamageEvent.Unsubscribe(OnTakeDamage);

        private void OnTakeDamage(TakeDamageArgs _) => _entity.SetAnimatorTrigger(_takeDamageTriggerName);
    }
}