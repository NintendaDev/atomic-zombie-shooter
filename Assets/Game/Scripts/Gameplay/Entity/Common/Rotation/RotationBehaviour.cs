using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    public sealed class RotationBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            if (entity.GetRotateCondition().Value == false)
                return;
            
            entity.MoveRotation(deltaTime);
        }
    }
}