using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class CollisionUseCase
    {
        public static bool IsPlayerCollision(this Collision other)
        {
            if (other.transform.TryGetComponent(out IEntity entity) && entity.HasPlayerTag())
                return true;

            return false;
        }
    }
}