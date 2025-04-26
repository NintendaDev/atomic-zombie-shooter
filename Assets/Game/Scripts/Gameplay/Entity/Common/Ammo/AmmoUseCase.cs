using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay.Weapons;
using Modules.Gameplay;

namespace Game.Gameplay.Entity.Common
{
    public static class AmmoUseCase
    {
        public static bool IsExistsAmmo(this IWeaponEntity weapon)
        {
            if (weapon.TryGetAmmo(out Ammo ammo) == false)
                return false;

            return ammo.IsExists();
        }
        
        public static bool TryAddAmmo(this IEntity entity, int count)
        {
            if (entity.TryGetCurrentWeapon(out IReactiveVariable<IWeaponEntity> weapon) == false)
                return false;

            if (weapon.Value == null)
                return false;

            return TryAddAmmo(weapon.Value, count);
        }

        public static bool TryAddAmmo(this IWeaponEntity weapon, int count)
        {
            if (weapon.TryGetAmmo(out Ammo ammo) == false)
                return false;
            
            ammo.Add(count);

            return true;
        }

        public static void SpendAmmo(this IWeaponEntity weapon)
        {
            if (weapon.TryGetAmmo(out Ammo ammo) == false)
                return;
            
            ammo.TrySpend();
        }
    }
}