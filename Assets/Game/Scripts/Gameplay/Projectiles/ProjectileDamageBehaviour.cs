using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;
using Game.Gameplay.Weapons;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Projectiles
{
    public sealed class ProjectileDamageBehaviour : IEntityInit<IProjectileEntity>, IEntityDispose<IProjectileEntity>
    {
        private readonly IGameContext _gameContext;
        private CollisionEventReceiver _collisionEventReceiver;
        private IProjectileEntity _projectile;

        public ProjectileDamageBehaviour(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void Init(IProjectileEntity entity)
        {
            _projectile = entity;
            _collisionEventReceiver = entity.GetCollisionEventReceiver();
            _collisionEventReceiver.Entered += OnColissionEnter;
        }

        public void Dispose(IProjectileEntity entity)
        {
            _collisionEventReceiver.Entered -= OnColissionEnter;
        }

        private void OnColissionEnter(Collision collision)
        {
            if (collision.TryGetEntity(out IEntity entity))
                entity.TakeDamage(new TakeDamageArgs(_projectile, _projectile.GetDamage().Value));
            
            ShootUseCase.DestroyBullet(_gameContext, _projectile);
        }
    }
}