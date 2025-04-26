using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class FireVfxBehaviour : IEntityInit, IEntityDispose
    {
        private readonly ParticleSystem _particles;
        private IEvent _attackEvent;

        public FireVfxBehaviour(ParticleSystem particles)
        {
            _particles = particles;
        }
        
        public void Init(in IEntity entity)
        {
            _attackEvent = entity.GetAttackEvent();
            _attackEvent.Subscribe(OnAttack);
        }

        public void Dispose(in IEntity entity)
        {
            _attackEvent.Unsubscribe(OnAttack);
        }

        private void OnAttack()
        {
            _particles.Play();
        }
    }
}