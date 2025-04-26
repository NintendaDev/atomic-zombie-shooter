using Atomic.Entities;

namespace Game.Gameplay.Entity.Common
{
    public sealed class RigidbodyMoveBehaviour : IEntityFixedUpdate
    {
        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            entity.MovePosition(deltaTime);
        }
    }
}