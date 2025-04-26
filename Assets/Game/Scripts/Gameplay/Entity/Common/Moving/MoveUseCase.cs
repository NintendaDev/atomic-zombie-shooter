using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Gameplay.Entity.Common
{
    public static class MoveUseCase
    {
        private const float SpeedDivider = 10f;
        
        public static bool IsMoving(this IEntity entity)
        {
            return entity.HasMovableTag() && entity.GetMoveDirection().Value != Vector3.zero 
                                          && entity.GetMoveCondition().Invoke();
        }
        
        public static void MovePosition(this IEntity entity, in float deltaTime) =>
            MovePosition(entity, entity.GetMoveDirection().Value, deltaTime);
        
        public static void MovePosition(this IEntity entity, in Vector3 direction, in float deltaTime)
        {
            if (CanMove(entity) == false)
                return;
            
            Rigidbody rigidbody = entity.GetRigidbody();
            Vector3 targetPosition = rigidbody.position + direction * entity.GetMoveSpeed().Value 
                / SpeedDivider * deltaTime;
            
            rigidbody.MovePosition(targetPosition);
        }

        public static void MovePositionByAnimator(this IEntity entity, in int animatorMoveParameterHash)
        {
            if (entity.GetMoveDirection().Value.sqrMagnitude == 0)
            {
                if (entity.GetAnimator().GetBool(animatorMoveParameterHash))
                    entity.GetAnimator().SetBool(animatorMoveParameterHash, false);

                return;
            }
            
            if (CanMove(entity) == false)
                return;
            
            entity.GetAnimator().SetBool(animatorMoveParameterHash, true);
        }

        private static bool CanMove(this IEntity entity)
        {
            if (entity.HasMovableTag() == false)
                return false;
            
            if ( entity.TryGetMoveCondition(out IExpression<bool> condition) == false)
                return false;

            if (condition.Value == false)
                return false;

            return true;
        }
    }
}