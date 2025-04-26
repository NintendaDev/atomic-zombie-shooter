using Atomic.Entities;
using Game.Gameplay.Weapons;

namespace Game.Gameplay.Entity.Common
{
    public static class WeaponUseCase
    {
        public static bool IsExistsWeapon(this IEntity entity, out IWeaponEntity weapon)
        {
            weapon = null;
            
            if (entity.HasCurrentWeapon() == false)
                return false;
            
            weapon = entity.GetCurrentWeapon().Value;

            return weapon != null;
        }
    }
}