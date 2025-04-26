using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    public static class HealthUseCase
    {
        public static bool IsAlive(this IEntity entity)
        {
            if (entity.HasDamageableTag() == false)
                return false;
            
            return entity.GetHealth().IsEmpty() == false;
        }

        public static bool IsFullHealth(this IEntity entity)
        {
            if (entity.HasDamageableTag() == false)
                return false;
            
            return entity.GetHealth().IsFull();
        }

        public static bool TryHeal(this IEntity entity, int count)
        {
            if (entity.HasDamageableTag() == false)
                return false;

            return entity.GetHealth().Add(count);
        }
    }
}