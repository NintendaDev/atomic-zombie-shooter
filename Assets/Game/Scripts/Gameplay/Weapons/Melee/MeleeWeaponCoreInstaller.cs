using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;
using Modules.Gameplay;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Weapons
{
    public sealed class MeleeWeaponCoreInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField, Required] private Transform _damagePoint;
        [SerializeField, Required] private int _damage = 1;
        [SerializeField, Required, MinValue(0)] private float _damageRadius = 1f;
        [SerializeField, MinValue(0), Unit(Units.Second)] private int _attackCooldown = 1;

        protected override void Install(IWeaponEntity entity)
        {
            entity.AddMeleeTag();
            entity.AddTransform(_damagePoint);
            entity.AddDamageRadius(new Const<float>(_damageRadius));
            entity.AddDamage(new Const<int>(_damage));

            InstallAttack(entity);

            entity.WhenUpdate((deltaTime) =>
            {
                if (entity.GetCooldown().IsExpired())
                    return;
                
                entity.CooldownTick(deltaTime);
            });
        }

        private void InstallAttack(IWeaponEntity entity)
        {
            entity.AddCooldown(new Cooldown(_attackCooldown));
            entity.AddAttackCondition(new AndExpression(entity.IsExpiredCooldown));
            
            entity.AddAttackAction(new BaseAction(() =>
            {
                if (entity.GetAttackCondition().Invoke() == false)
                    return;
                
                MeleeUseCase.AttackBy(entity);
            }));
            
            entity.AddAttackEvent(new BaseEvent());
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(_damagePoint.position, _damageRadius);
        }
    }
}