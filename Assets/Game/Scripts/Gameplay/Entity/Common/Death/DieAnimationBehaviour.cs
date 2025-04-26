using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class DieAnimationBehaviour : IEntityInit, IEntityDispose
    {
        private IReactiveVariable<TakeDamageArgs> _deathEvent;
        private readonly int _dieTriggerHash;
        private IEntity _entity;

        public DieAnimationBehaviour(string dieTriggerName)
        {
            _dieTriggerHash = Animator.StringToHash(dieTriggerName);
        }
        
        public void Init(in IEntity entity)
        {
            _entity = entity;
            _deathEvent = entity.GetDeathEvent();
            _deathEvent.Subscribe(OnDie);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDie);
        }

        private void OnDie(TakeDamageArgs _) => _entity.SetAnimatorTrigger(_dieTriggerHash);
    }
}