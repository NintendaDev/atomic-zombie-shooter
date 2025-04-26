using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public sealed class DeathObjectDisableBehaviour : IEntityInit, IEntityDispose
    {
        private readonly Transform[] _transforms;
        private IReactiveVariable<TakeDamageArgs> _deathEvent;

        public DeathObjectDisableBehaviour(params Transform[] transforms)
        {
            _transforms = transforms;
        }
        
        public void Init(in IEntity entity)
        {
            _deathEvent = entity.GetDeathEvent();

            _deathEvent.Subscribe(OnDie);
        }

        public void Dispose(in IEntity entity)
        {
            _deathEvent.Unsubscribe(OnDie);
        }

        private void OnDie(TakeDamageArgs _)
        {
            foreach (Transform transform in _transforms)
                transform.gameObject.SetActive(false);
        }
    }
}