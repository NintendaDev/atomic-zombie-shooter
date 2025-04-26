using Atomic.Entities;
using Game.Gameplay.Entity;
using Game.Gameplay.Entity.Common;
using UnityEngine;

namespace Game.Gameplay.Weapons
{
    public static class MeleeUseCase
    {
        public static void AttackBy(in IWeaponEntity weapon)
        {
            if (weapon == null || weapon.HasMeleeTag() == false)
                return;
            
            Transform attackPoint = weapon.GetTransform();
            float damageRadius = weapon.GetDamageRadius().Value;
            
            if (attackPoint.TryRaycastPlayer(damageRadius, out IEntity player))
                player.TakeDamage(new TakeDamageArgs(weapon, weapon.GetDamage().Value));
                
            weapon.ResetCooldown();
            weapon.GetAttackEvent().Invoke();
        }
    }
}