using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Entity.Items
{
    public sealed class ItemTakeBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEventReceiver _triggerEventReceiver;
        private IEntity _itemEntity;

        public void Init(in IEntity entity)
        {
            _itemEntity = entity;
            _triggerEventReceiver = entity.GetTriggerEventReceiver();
            _triggerEventReceiver.Entered += OnTriggerEnter;
        }

        public void Dispose(in IEntity entity)
        {
            _triggerEventReceiver.Entered -= OnTriggerEnter;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity target) == false)
                return;

            _itemEntity.GetItemUseAction().Invoke();
        }
    }
}