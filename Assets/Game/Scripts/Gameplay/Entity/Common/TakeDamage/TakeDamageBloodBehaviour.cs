using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class TakeDamageBloodBehaviour : IEntityInit, IEntityDispose
    {
        private readonly ParticleSystem _bulletBlood;
        private readonly ParticleSystem _meleeBlood;
        private readonly Transform _originTransform;
        private IReactive<TakeDamageArgs> _damageEvent;
        private IReactive<TakeDamageArgs> _deathEvent;

        public TakeDamageBloodBehaviour(ParticleSystem bulletBlood, ParticleSystem meleeBlood, 
            Transform originTransform)
        {
            _bulletBlood = bulletBlood;
            _meleeBlood = meleeBlood;
            _originTransform = originTransform;
        }

        public void Init(in IEntity entity)
        {
            _damageEvent = entity.GetTakeDamageEvent();
            _deathEvent = entity.GetDeathEvent();

            _damageEvent.Subscribe(OnDamageTaken);
            _deathEvent.Subscribe(OnDamageTaken);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Subscribe(OnDamageTaken);
            _deathEvent.Subscribe(OnDamageTaken);
        }

        private void OnDamageTaken(TakeDamageArgs args)
        {
            IEntity source = args.Source;
            
            if (source == null)
                return;

            if (source.HasProjectileTag())
                source.PlayProjectileDamageEffect(_originTransform, _bulletBlood);
            
            if (source.HasMeleeTag() && _meleeBlood != null)
                _meleeBlood.Play(withChildren: true);
        }
    }
}