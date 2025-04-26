using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class FollowUseCase
    {
        public static void Follow(this IEntity follower, Transform target)
        {
            if (target == null)
            {
                if (follower.GetMoveDirection().Value != Vector3.zero)
                    follower.GetMoveDirection().Value = Vector3.zero;
                
                return;
            }
            
            Vector3 direction = target.position - follower.GetTransform().position;
            direction.y = 0.0f;
            direction = direction.normalized;

            follower.GetMoveDirection().Value = direction;
            follower.GetRotateDirection().Value = direction;
        }
    }
}