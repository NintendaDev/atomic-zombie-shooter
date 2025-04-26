using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;
using Game.Gameplay.Projectiles;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Weapons
{
    public sealed class ShootWeaponCoreInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [Title("Weapon Settings")]
        [SerializeField] private Transform _firePoint;
        [SerializeField, MinValue(0), Unit(Units.Degree)] private float _spread = 0.25f;
        [SerializeField, MinValue(0), Unit(Units.Second)] private int _attackCooldown = 1;
        [SerializeField, MinValue(0)] private int _startBulletsCount = 8;

        [Title("Bullet Settings")]
        [SerializeField, Required, AssetsOnly] private ProjectileEntity _projectilePrefab;
        
        protected override void Install(IWeaponEntity entity)
        {
            IGameContext gameContext = GameContext.Instance;
            
            InstallAmmo(entity);
            InstallAttack(entity, gameContext);
            
            entity.WhenUpdate((deltaTime) =>
            {
                if (entity.GetCooldown().IsExpired())
                    return;
                
                CooldownUseCase.CooldownTick(entity, deltaTime);
            });
        }

        private void InstallAmmo(IWeaponEntity entity)
        {
            entity.AddAmmo(new Ammo(_startBulletsCount));
        }

        private void InstallAttack(IWeaponEntity entity, IGameContext gameContext)
        {
            entity.AddBulletArgs(new BulletArgs(_projectilePrefab, _spread));
            entity.AddCooldown(new Cooldown(_attackCooldown));
            
            entity.AddAttackCondition(new AndExpression(() => entity.IsExpiredCooldown(), 
                () => entity.IsExistsAmmo()));
            
            entity.AddAttackEvent(new BaseEvent());
                
            entity.AddAttackAction(new BaseAction(() =>
            {
                if (entity.GetAttackCondition().Invoke() == false)
                    return;
                
                ShootUseCase.ShootBullet(gameContext, _firePoint, entity.GetBulletArgs());
                entity.ResetCooldown();
                entity.SpendAmmo();
                entity.GetAttackEvent().Invoke();
            }));
        }
    }
}