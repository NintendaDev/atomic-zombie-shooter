using Atomic.Entities;
using Game.Gameplay.Contexts.Game;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class BodyFallUseCase
    {
        public static void CreateGroundBlood(this IEntity entity, in IGameContext gameContext, 
            in Transform rootTransform, in SceneEntity bloodEffectEntity)
        {
            if (entity.TryRaycastGround(rootTransform, out Vector3 groundPoint) == false)
                return;
            
            IEntity effect = gameContext.GetEntityPool().Rent(bloodEffectEntity);
            effect.GetTransform().position = groundPoint;
            effect.GetStartVisualEffectAction().Invoke();
        }
    }
}