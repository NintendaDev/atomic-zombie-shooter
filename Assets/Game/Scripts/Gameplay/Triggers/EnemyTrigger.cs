using Atomic.Entities;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;
using UnityEngine;

namespace Game.Gameplay.Triggers
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField]
        private SceneEntity[] _enemies;

        private IEntity _player;

        private void OnDestroy()
        {
            if (_player != null)
                _player.GetDeathEvent().Unsubscribe(OnPlayerDeath);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) == false || entity.HasPlayerTag() == false)
                return;

            _player = entity;
            _player.GetDeathEvent().Subscribe(OnPlayerDeath);

            SetTarget(_player);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) == false || entity.HasPlayerTag() == false)
                return;
            
            entity.GetDeathEvent().Unsubscribe(OnPlayerDeath);
            _player = null;

            ResetTarget();
        }

        private void OnPlayerDeath(TakeDamageArgs _)
        {
            ResetTarget();
            _player.GetDeathEvent().Unsubscribe(OnPlayerDeath);
            _player = null;
        }

        private void SetTarget(IEntity entity)
        {
            foreach (IEntity enemy in _enemies)
                enemy.GetTarget().Value = entity.GetTransform();
        }

        private void ResetTarget()
        {
            foreach (IEntity enemy in _enemies)
                enemy.GetTarget().Value = null;
        }
    }
}