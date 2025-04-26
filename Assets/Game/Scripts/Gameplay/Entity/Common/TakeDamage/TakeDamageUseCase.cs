using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class TakeDamageUseCase
    {
        public static void TakeDamage(this IEntity target, TakeDamageArgs args)
        {
            if (target.HasDamageableTag() == false)
                return;
            
            Health health = target.GetHealth();

            if (health.IsEmpty())
                return;

            if (health.Reduce(args.Damage) == false)
                return;
            
            if (health.IsEmpty())
                target.GetDeathEvent().Invoke(args);
            else
                target.GetTakeDamageEvent().Invoke(args);
        }
    }
}