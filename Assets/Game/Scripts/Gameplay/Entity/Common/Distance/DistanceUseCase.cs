using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class DistanceUseCase
    {
        public static float CalculateDistanceToEntity(this IEntity entity, in Transform target)
        {
            return Vector3.Distance(entity.GetTransform().position, target.position);
        }
    }
}