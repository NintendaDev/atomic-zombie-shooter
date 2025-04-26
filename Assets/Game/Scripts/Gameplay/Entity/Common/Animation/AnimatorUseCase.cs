using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    public static class AnimatorUseCase
    {
        public static void SetAnimatorTrigger(this IEntity entity, int triggerHash)
        {
            entity.GetAnimator().SetTrigger(triggerHash);
        }

        public static void SetAnimatorBool(this IEntity entity, int parameterHash, bool value)
        {
            entity.GetAnimator().SetBool(parameterHash, value);
        }
    }
}