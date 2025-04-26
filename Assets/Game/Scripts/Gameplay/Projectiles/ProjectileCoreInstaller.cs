using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Entity;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Projectiles
{
    public sealed class ProjectileCoreInstaller : SceneEntityInstaller<IProjectileEntity>
    {
        [SerializeField, Required] private Rigidbody _rigidbody;
        [SerializeField, Required] private CollisionEventReceiver _collisionEventReceiver;
        [SerializeField, MinValue(0)] private float _speed = 40;
        [SerializeField, MinValue(0)] private int _damage = 1;
        [SerializeField, MinValue(0), Unit(Units.Second)] private int _lifeTime = 3;
        
        protected override void Install(IProjectileEntity entity)
        {
            entity.AddProjectileTag();
            entity.AddRigidbody(_rigidbody);
            entity.AddTransform(_rigidbody.transform);
            entity.AddCollisionEventReceiver(_collisionEventReceiver);
            entity.AddDamage(new Const<int>(_damage));
            entity.AddLifeTimer(new Cooldown(_lifeTime, _lifeTime));
            entity.AddMoveSpeed(new ReactiveFloat(_speed));
            entity.AddBehaviour(new ProjectileDamageBehaviour(GameContext.Instance));

            entity.WhenUpdate(deltaTime =>
            {
                entity.GetLifeTimer().Tick(deltaTime);

                if (entity.GetLifeTimer().IsExpired())
                    GameContext.Instance.GetEntityPool().Return(entity);
            });
        }
    }
}