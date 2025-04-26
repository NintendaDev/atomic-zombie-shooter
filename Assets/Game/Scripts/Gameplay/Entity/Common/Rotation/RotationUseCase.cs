using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class RotationUseCase
    {
        public static void MoveRotation(this IEntity entity, in float deltaTime)
        {
            Vector3 direction = entity.GetRotateDirection().Value;
            
            if (direction == Vector3.zero)
                return;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            MoveRotation(entity, targetRotation, deltaTime);
        }
        
        public static void MoveRotation(this IEntity entity, in Quaternion targetRotation, in float deltaTime)
        {
            Transform transform = entity.GetTransform();
            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 
                entity.GetAngularSpeed().Value * deltaTime);
        }
    }
}