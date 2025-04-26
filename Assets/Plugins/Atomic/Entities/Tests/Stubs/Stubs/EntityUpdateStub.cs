namespace Atomic.Entities
{
    public sealed class EntityUpdateStub : IEntityUpdate
    {
        public void OnUpdate(in IEntity entity, in float deltaTime)
        {
        }
    }
}