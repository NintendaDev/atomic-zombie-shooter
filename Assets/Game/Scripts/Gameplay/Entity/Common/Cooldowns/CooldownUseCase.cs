using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    public static class CooldownUseCase
    {
        public static bool IsExpiredCooldown(this IEntity entity) => entity.GetCooldown().IsExpired();
        
        public static void ResetCooldown(this IEntity entity) => entity.GetCooldown().Reset();
        
        public static void CooldownTick(this IEntity entity, float deltaTime) => entity.GetCooldown().Tick(deltaTime);
    }
}